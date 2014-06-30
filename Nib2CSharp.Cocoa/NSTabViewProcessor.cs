using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSTabViewProcessor : NSViewProcessor
    {
        public override string Name { get { return "NSTabView"; } set { } }
        public override string Handles
        {
            get { return "NSTabView"; }
            set { }


        }

      
        public new List<string> Hidden
        {
            get { return new List<string>() {}; }
            set { ; }

        }

        public new Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {
                                           
                                              
                                  
                                                          {"allowsTruncatedLabels", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsTruncatedLabels" })},    
                                                 {"alphaValue", (new ProcessedObject() {Processor = "Float", OutputName="AlphaValue"})},                  
                                             
                                                  {"drawsBackground", (new ProcessedObject() {Processor = "Bool", OutputName="DrawsBackground"})},
                                                   {"font", (new ProcessedObject() {Processor = "Font", OutputName="Font"})},
                                                    {"contentViewMargins", (new ProcessedObject() {Processor = "Size", OutputName="ContentViewMargins"})},
                                                      {"tabViewType", (new ProcessedObject() {Processor = "Enum", OutputName="TabViewType",Options = "NSTabViewType"})},
                                                       {"controlSize", (new ProcessedObject() {Processor = "Enum", OutputName="ControlSize",Options = "NSControlSize"})},
                                                        
                                                    
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
            if (s == "NSTabViewItem")
            {
                return String.Format("{0}.Add({1})", parentName, childname);
            }
            return base.AddChild(parentName, childname);
        }
        public override void ProcessKey(System.Xml.Linq.XElement item)
        {

            if (ObjectProcessors.ContainsKey(item.Value))
            {
                var objectProcessor = ObjectProcessors[item.Value];
                var processedObject = MainNIBProcessor.processObject(item, objectProcessor.Processor,objectProcessor.Options);
                if (!String.IsNullOrEmpty(processedObject))
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
