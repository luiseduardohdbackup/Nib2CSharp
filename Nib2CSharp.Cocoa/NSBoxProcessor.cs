using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSBoxProcessor : NSViewProcessor
    {
        public override string Name { get { return "NSBox"; } set { } }
        public override string Handles
        {
            get { return "NSBox"; }
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
                                           
                                              
                                                         
                                                          {"borderColor", (new ProcessedObject() {Processor = "Color", OutputName="BorderColor" })},    
                                                 {"borderType", (new ProcessedObject() {Processor = "Enum", OutputName="BorderType",Options = "NSBorderType"})},                  
                                             
                                                  {"borderWidth", (new ProcessedObject() {Processor = "Float", OutputName="BorderWidth"})},
                                                   {"boxType", (new ProcessedObject() {Processor = "Enum", OutputName="BoxType",Options = "NSBoxType"})},
                                                    {"contentViewMargins", (new ProcessedObject() {Processor = "Size", OutputName="ContentViewMargins"})},
                                                      {"cornerRadius", (new ProcessedObject() {Processor = "Float", OutputName="CornerRadius"})},
                                                       
                                                              {"fillColor", (new ProcessedObject() {Processor = "Color", OutputName="FillColor"})},
                                                             
                                                                   {"title", (new ProcessedObject() {Processor = "String", OutputName="Title"})},
                                              {"titleFont", (new ProcessedObject() {Processor = "Font", OutputName="TitleFont"})},
                                                 {"titlePosition", (new ProcessedObject() {Processor = "Enum", OutputName="TitlePosition",Options = "NSTitlePosition"})},
                                                  {"transparent", (new ProcessedObject() {Processor = "Bool", OutputName="Transparent"})},
                                                    
                                           };



                return objectProcessors;
            }
            set
            {
                throw new NotImplementedException();
            }
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
