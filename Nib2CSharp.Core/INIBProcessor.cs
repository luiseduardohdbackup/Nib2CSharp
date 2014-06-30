using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Nib2CSharp.Core
{
    public class ProcessedObject
    {
        public object Options { get; set; }
        public string Processor { get; set; }
        public string OutputName { get; set; }
    }

    public abstract class INIBProcessor
    {
        private readonly Dictionary<string, Dictionary<string, string>> Objects =
            new Dictionary<string, Dictionary<string, string>>();

        public abstract string Name { get; }

        public string Output = "";

        [ImportMany("ClassProcessor", typeof (IClassProcessor))]
        private IEnumerable<IClassProcessor> Classes { get; set; }

        [ImportMany("ObjectProcessor", typeof(IObjectProcessor))]
        public IEnumerable<IObjectProcessor> ObjectProcessors { get; set; }


        public IObjectProcessor ProcessorForObject(string anObject, string style="")
        {
            IObjectProcessor processor = (ObjectProcessors.Where(m => m.Name == anObject)).FirstOrDefault();
            if (processor == null)
            {
                processor = new DumbObjectProcessor();
            
            }
            return processor;
        }

        public string processObject(XElement item, string processor, object options=null)
        {
      
          IObjectProcessor objectProcessor =    ProcessorForObject(processor, "");
         
           return objectProcessor.ProcessObject(item,options);
        }

        public string ProcessorPlatform { get; set; }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetAssembly(GetType()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }


        private static string InstanceNameForObject(Dictionary<string, string> obj)
        {
            if (obj != null)
            {
                string klass = obj["__Helper__Name__"];
                //  string instanceName = klass.ToLower().Substring(2);

                //if(obj.ContainsKey("identifier"))
                //{
                //    klass = obj["identifier"] + instanceName;
                //    instanceName = klass;
                //}

                //if (obj.ContainsKey("ibExternalExplicitLabel"))
                //{
                //    klass = obj["ibExternalExplicitLabel"];
                //    instanceName = klass;
                //}

                //instanceName = instanceName.Replace(" ", "");



                return klass;
            }
            else
                return "UnNamed";
        }


        public string Run(string path)
        {
            Compose();

            if (Path.GetExtension(path) != ".plist")
            {
                string arguments = "--objects " + "--hierarchy " + "--connections " + "--classes ";


                // sets up our process, the first argument is the command 
                // and the second holds the arguments passed to the command
                ProcessStartInfo ps = new ProcessStartInfo("/usr/bin/ibtool", arguments + " " + path);
                ps.UseShellExecute = false;

                // we need to redirect the standard output so we read it
                // internally in out program
                ps.RedirectStandardOutput = true;

                // starts the process
                Process process = Process.Start(ps);

                // we read the output to a string
                Output = process.StandardOutput.ReadToEnd();

                // waits for the process to exit
                // Must come *after* StandardOutput is "empty"
                // so that we don't deadlock because the intermediate
                // kernel pipe is full.
                process.WaitForExit();

                // finally output the string
            }
            else
            {
                TextReader textReader = new StreamReader(path);
                Output = textReader.ReadToEnd();
            }
            XDocument doc = XDocument.Parse(Output.SanitizeXmlString());

            Output = "";

            XElement mainElement = doc.Descendants("key")
                .Where(m => m.Value == "com.apple.ibtool.document.objects")
                .FirstOrDefault();
            if (mainElement != null)
            {
                XElement dict = mainElement.ElementsAfterSelf().FirstOrDefault();
                if (dict != null)
                {
                    if (dict.Name == "dict")
                    {
                        foreach (XElement element in dict.Elements("key").OrderBy(o => o.Value))
                        {
                

                            XElement dict2 = element.ElementsAfterSelf().FirstOrDefault();
                            if (dict2.Name == "dict")
                            {
                                Objects[element.Value] = ProcessDict(dict2, "  ");
                            }
                      
                        }
                    }
                }

                foreach (string key in Objects.Keys.OrderBy(o => o))
                {
                    Dictionary<string, string> anObject = Objects[key];

                    if (anObject["__Helper__Class__"] == "__Invalid__")
                    {
                        continue;
                    }
                    // First, output any helper functions, ordered alphabetically
                    foreach (var avalue in anObject.Where(o => o.Key.StartsWith("__helper__")).OrderBy(o => o))
                    {
                        Output += avalue.Value + "\n";
                    }
                    // Then, output the constructor and the frame

                    string instanceName = anObject["__Helper__Name__"];
                    string frame = anObject["__Helper__Frame__"];
                    string objectClass = anObject["__Helper__Class__"];
                    string constructor = anObject["__Helper__Constructor__"];
                    Output += string.Format("{0} {1}{2} = {3};\n", objectClass, instanceName, key, constructor);

                    if (frame != null)
                        Output += string.Format("{0}{1}.Frame = {2};\n", instanceName, key, frame);

                    // Then, output the properties only, ordered alphabetically
                    foreach (
                        var avalue in
                            anObject.Where(
                                o =>
                                !(o.Key.StartsWith("__helper__") ||o.Key.StartsWith("__Helper__")|| o.Key.StartsWith("__method__") || o.Key == ("class") ||
                                  o.Key == ("constructor") || o.Key == ("Frame"))).OrderBy(o => o.Key))
                    {
                        Output += string.Format("{0}{1}.{2} = {3};\n", instanceName, key, avalue.Key, avalue.Value);
                    }


                    // Finally, output the method calls, ordered alphabetically

                    //foreach (var avalue in anObject.Where(o => o.Key.StartsWith("__method__")).OrderBy(o => o))
                    //{
                    //    output += string.Format("{0}{1}.{2}();\n", instanceName, key, avalue.Value);
                    //}

                    Output += "\n";
                }

                // Now that the objects are created, recreate the hierarchy of the NIB
                XElement HierarchyElement = doc.Descendants("key")
                    .Where(m => m.Value == "com.apple.ibtool.document.hierarchy")
                    .FirstOrDefault();

                if (HierarchyElement != null)
                {
                    XElement dict3 = HierarchyElement.ElementsAfterSelf().FirstOrDefault();
                    if (dict3 != null)
                    {
                        if (dict3.Name == "array")
                        {
                            foreach (XElement element in dict3.Elements("dict"))
                            {
                                string objectid = element.GetElementForKey("object-id").Value;

                                ParseChildren(element, objectid);

                                Output +="\n\n\n\n\n//Next Parent\n";
                            }
                        }
                    }
                }
           

            }
            return "\n\n//Final Code: \n \n \n" + Output;
        }

       public string[] ignoredClasses =  new string[ ]{"NSObject","NSCustomObject"};

        public IClassProcessor ProcessorForClass(string aclass)
        {
            if (!ignoredClasses.Contains(aclass))
            {
                IClassProcessor processor = (Classes.Where(m => m.Handles == aclass)).FirstOrDefault();
                if (processor == null)
                {
                    processor = (Classes.Where(m => m.Name == aclass)).FirstOrDefault();
                    if (processor == null)
                    {
                        processor = new DumbClassProcessor();
                        processor.Name = aclass;
                    }

                }

                return processor;
            }
            return new InvalidClassProcessor();
        }

        private void ParseChildren(XElement element, string currentView)
        {
            XElement Children = element.ElementsAfterSelf().FirstOrDefault();
            IEnumerable<XElement> keys = element.Elements("key");

            if (element.GetElementForKey("children").Value != "")
            {
                XElement children =
                    keys.Where(o => o.Value == "children").FirstOrDefault().ElementsAfterSelf().FirstOrDefault();
                foreach (XElement child in children.Elements())
                {
                    string subInstanceName = "";
                    string subView = child.GetElementForKey("object-id").Value;
                    Dictionary<string, string> subViewObject = Objects[subView];
                    subInstanceName = InstanceNameForObject(subViewObject);


                    Dictionary<string, string> currentViewObject = Objects[currentView];

                    IClassProcessor classProcessor = ProcessorForClass(currentViewObject["__Helper__Class__"]);


                    string instanceName =
                        InstanceNameForObject(currentViewObject);


                    ParseChildren(child, subView);



                    Output += classProcessor.AddChild(String.Format("{0}{1}", instanceName,
                                                          currentView), String.Format("{0}{1}", subInstanceName,
                                                                                      subView), subViewObject["__Helper__Class__"]) + ";\n";
                }
            }
        }


        public Dictionary<string, string> ProcessDict(XElement dict2, string tabSpace)
        {
            IClassProcessor processor = ProcessorForClass(dict2.GetElementForKey("class").Value);
            return processor.ProcessObject(dict2);
        }
    }
}