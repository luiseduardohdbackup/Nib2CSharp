using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
       [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSTabViewItemProcessor : IClassProcessor
    {
        public override string Name
        {
            get { return "NSTabViewItem"; }
               set { }
        }

        public override string Handles
        {
            get { return "NSTabViewItem"; }
            set { }
        }
        public new  List<string> Hidden
        {
            get { return new List<string>() { "frameOrigin", "frameSize", "ibExternalIdentityShowNotesWithSelection", "focusRingType" }; }
            set { ; }

        }

        public override Dictionary<string, ProcessedObject> ObjectProcessors
           {
               get
               {
                   var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {

                                               {"label", (new ProcessedObject() {Processor = "String", OutputName="Label" })},
                                               {"color", (new ProcessedObject() {Processor = "Color", OutputName="Color" })},
                                              
                                                  //{"focusRingType", (new ProcessedObject() {Processor = "FocusRingType", OutputName="FocusRingType"})},
                                                  
                                           };



                   return objectProcessors;
               }
               set
               {
                   throw new NotImplementedException();
               }
           }

        public override string AddChild(string parentName, string childname, string s)
        {
            if (s == "NSView")
            {
                return String.Format("{0}.View={1}", parentName, childname);
            }
            return base.AddChild(parentName, childname);
        }

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {

            if (ObjectProcessors.ContainsKey(item.Value))
            {
                var objectProcessor = ObjectProcessors[item.Value];
                var processedObject = MainNIBProcessor.processObject(item, objectProcessor.Processor,objectProcessor.Options);
                    if(!String.IsNullOrEmpty(processedObject))
                        output[objectProcessor.OutputName] = processedObject;// + "// " + "NSView";
                    else
                    {
                        Console.WriteLine(@"Skipped: " + item.Value + @" No Data To Process");
                    }
            }
                                 else if (!Hidden.Contains(item.Value))
                                                                {
                                                                     base.ProcessKey(item);
                                                                }

            output["__Helper__Class__"] = Name;
        }

    }
}
