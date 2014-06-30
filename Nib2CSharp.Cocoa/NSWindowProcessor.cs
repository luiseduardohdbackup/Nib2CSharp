using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{

   

    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSWindowProcessor : IClassProcessor
    {
        public override string Name
        {
            get { return "NSWindow"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSWindowTemplate"; }
            set { }
        }
        public new List<string> Hidden
        {
            get { return new List<string>() { "contentBorderThicknessMaxXEdge", "contentBorderThicknessMaxYEdge", "contentBorderThicknessMinXEdge",
                "contentBorderThicknessMinYEdge", "autorecalculatesContentBorderThicknessMaxXEdge", "autorecalculatesContentBorderThicknessMaxYEdge",
                "autorecalculatesContentBorderThicknessMinXEdge", "autorecalculatesContentBorderThicknessMinYEdge", "contentRectOrigin", "contentRectSize","oneShot","wantsToBeColor","deferred"
            }; }
            set { ; }

        }

        public new virtual Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {
                                               {"backingType", (new ProcessedObject() {Processor = "Enum", OutputName="BackingType",Options = "NSBackingStore"})},
                                                {"arrowsPosition", (new ProcessedObject() {Processor = "Enum", OutputName="ArrowsPosition",Options = "NSScrollArrowPosition"})},
                                                 {"controlSize", (new ProcessedObject() {Processor = "Enum", OutputName="ControlSize",Options = "NSControlSize"})},

                                                  {"controlTint", (new ProcessedObject() {Processor = "Enum" ,OutputName="ControlTint",Options ="NSControlTint"})},
                                                {"knobProportion", (new ProcessedObject() {Processor = "Float", OutputName="KnobProportion" })},

                                                   {"frameAutosaveName", (new ProcessedObject() {Processor = "String", OutputName="FrameAutosaveName" })},

                                                  //{"deferred", (new ProcessedObject() {Processor = "Bool", OutputName="Deferred" })},
                                                {"hasShadow", (new ProcessedObject() {Processor = "Bool", OutputName="HasShadow" })},
                                                 {"hidesOnDeactivate", (new ProcessedObject() {Processor = "Bool", OutputName="HidesOnDeactivate" })},
                                               //{"oneShot", (new ProcessedObject() {Processor = "Bool", OutputName="IsOneShot" })},
                                                    {"releasedWhenClosed", (new ProcessedObject() {Processor = "Bool", OutputName="ReleasedWhenClosed" })},
                                                     {"screenRect", (new ProcessedObject() {Processor = "Rect", OutputName="Frame" })},
                                                       {"showsToolbarButton", (new ProcessedObject() {Processor = "Bool", OutputName="ShowsToolbarButton" })},
                                                        {"styleMask", (new ProcessedObject() {Processor = "WindowStyle", OutputName="StyleMask" })},
                                                     {"title", (new ProcessedObject() {Processor = "String", OutputName="Title" })},
                                                          {"allowsToolTipsWhenApplicationIsInactive", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsToolTipsWhenApplicationIsInactive" })},
                                                  {"contentRectOrigin", (new ProcessedObject() {Processor = "ContentRect", OutputName="ContentView.Frame" })}, 
                                                   {"autorecalculatesKeyViewLoop", (new ProcessedObject() {Processor = "Bool", OutputName="AutorecalculatesKeyViewLoop" })},  
                                                    
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
            return String.Format("{0}.ContentView={1}", parentName, childname);
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

            output["__Helper__Class__"] = Name;
        }
        
        }
    }

