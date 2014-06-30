using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSSliderCellProcessor : NSActionCellProcessor
    {
        public override string Name
        {
            get { return "NSSliderCell"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSSliderCell"; }
            set { }
        }
        public new List<string> Hidden
        {
            get { return new List<string>() { "frameOrigin", "frameSize", "ibExternalIdentityShowNotesWithSelection" }; }
            set { ; }

        }

        public new Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {
                                               {"isVertical", (new ProcessedObject() {Processor = "String", OutputName="IsVertical" })},
                                                {"trackRect", (new ProcessedObject() {Processor = "RectString", OutputName="TrackRect" })},
                                                 {"minValue", (new ProcessedObject() {Processor = "float", OutputName="MinValue",})},
                                                  {"maxValue", (new ProcessedObject() {Processor = "float", OutputName="MaxValue"})},
                                                   {"doubleValue", (new ProcessedObject() {Processor = "float", OutputName="DoubleValue"})},

                                                    {"allowsTickMarkValuesOnly", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsTickMarkValuesOnly" })},

                                                       {"sliderType", (new ProcessedObject() {Processor = "Enum", OutputName="SliderType",Options = "NSSliderType"})},
                                            
                                                    
                                                    {"atIncrementLevel", (new ProcessedObject() {Processor = "Integer", OutputName="AtIncrementLevel" })},
                                                      {"titleColor", (new ProcessedObject() {Processor = "Color", OutputName="TitleColor" })},
                                                    {"numberOfTickMarks", (new ProcessedObject() {Processor = "Integer", OutputName="TickMarks" })},

                                                      {"tickMarkPosition", (new ProcessedObject() {Processor = "Enum", OutputName="TickMarkPosition",Options = "NSTickMarkPosition"})},

                                                   
                                             
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

