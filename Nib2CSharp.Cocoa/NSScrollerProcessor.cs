using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSScrollerProcessor : NsControlProcessor
    {
        public override string Name
        {
            get { return "NSScroller"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSScroller"; }
            set { }
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
                                               {"scrollerWidth", (new ProcessedObject() {Processor = "Float", OutputName="ScrollerWidth" })},
                                                {"arrowsPosition", (new ProcessedObject() {Processor = "Enum", OutputName="ArrowsPosition",Options = "NSScrollArrowPosition"})},
                                                 {"controlSize", (new ProcessedObject() {Processor = "Enum", OutputName="ControlSize",Options = "NSControlSize"})},

                                                  {"controlTint", (new ProcessedObject() {Processor = "ControlTint", OutputName="ControlTint" })},
                                                {"knobProportion", (new ProcessedObject() {Processor = "Float", OutputName="KnobProportion" })},
                                               {"doubleValue", (new ProcessedObject() {Processor = "Float", OutputName="DoubleValue" })},
                                                {"floatValue", (new ProcessedObject() {Processor = "Float", OutputName="FloatValue" })},
                                             
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


        }
        
        }
    }

