using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsScrollViewProcessor : NSViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "NSScrollView";
            }
            set
            {
                base.Name = value;
            }
        }

        public override string Handles
        {
            get
            {
                return Name;
            }
            set
            {
                base.Handles = value;
            }
        }




        public new List<string> Hidden
        {
            get { return new List<string>() { "frameOrigin", "frameSize", "ibExternalIdentityShowNotesWithSelection" }; }
            set { ; }

        }

        public new virtual Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {
                                               {"backgroundColor", (new ProcessedObject() {Processor = "Color", OutputName="BackgroundColor" })},
                                                {"borderType", (new ProcessedObject() {Processor = "Enum", OutputName="BorderType",Options = "NSBorderType"})},
                                                 {"controlSize", (new ProcessedObject() {Processor = "Enum", OutputName="ControlSize",Options = "NSControlSize"})},
                                                   {"contentView.copiesOnScroll", (new ProcessedObject() {Processor = "Bool", OutputName="ContentView.CopiesOnScroll"})},
                                                   {"drawsBackground", (new ProcessedObject() {Processor = "Bool", OutputName="DrawsBackground"})},
                                                  {"controlTint", (new ProcessedObject() {Processor = "ControlTint", OutputName="ControlTint" })},
                                                {"knobProportion", (new ProcessedObject() {Processor = "Float", OutputName="KnobProportion" })},
                                               {"doubleValue", (new ProcessedObject() {Processor = "Float", OutputName="DoubleValue" })},
                                                {"floatValue", (new ProcessedObject() {Processor = "Float", OutputName="FloatValue" })},
                                                    {"hasHorizontalRuler", (new ProcessedObject() {Processor = "Bool", OutputName="HasHorizontalRuler" })},
                                                        {"hasHorizontalScroller", (new ProcessedObject() {Processor = "Bool", OutputName="HasHorizontalScroller" })},
                                                            {"hasVerticalRuler", (new ProcessedObject() {Processor = "Bool", OutputName="HasVerticalRuler" })},
                                                                  {"hasVerticalScroller", (new ProcessedObject() {Processor = "Bool", OutputName="HasVerticalScroller" })},
                                                                      

     {"horizontalPageScroll", (new ProcessedObject() {Processor = "Float", OutputName="HorizontalPageScroll" })},
          {"horizontalLineScroll", (new ProcessedObject() {Processor = "Float", OutputName="HorizontalLineScroll" })},

                                                      {"verticalLineScroll", (new ProcessedObject() {Processor = "Float", OutputName="VerticalLineScroll" })},
                                                       {"verticalPageScroll", (new ProcessedObject() {Processor = "Float", OutputName="VerticalPageScroll" })},

                                             
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
                var processedObject = MainNIBProcessor.processObject(item, objectProcessor.Processor, objectProcessor.Options);
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


        }
    }
}
