using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
       [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSViewProcessor : IClassProcessor
    {
        public override string Name
        {
               get { return "NSView"; }
               set { }
        }

        public override string Handles
        {
            get { return "NSView"; }
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
                                               {"autoresizesSubviews", (new ProcessedObject() {Processor = "Bool", OutputName="AutoresizesSubviews" })},
                                               {"contentStretch", (new ProcessedObject() {Processor = "Rect", OutputName="ContentStretch" })},
                                               {"tag", (new ProcessedObject() {Processor = "Integer", OutputName="Tag" })},
                                               {"alpha", (new ProcessedObject() {Processor = "Float", OutputName="Alpha" })},
                                               {"alphaValue", (new ProcessedObject() {Processor = "Float", OutputName="AlphaValue" })},
                                               {"hidden", (new ProcessedObject() {Processor = "Bool", OutputName="Hidden" })},
                                               {"opaqueForDevice", (new ProcessedObject() {Processor = "Bool",  OutputName="Opaque" })},
                                               {"clipsSubviews", (new ProcessedObject() {Processor = "Bool", OutputName="ClipsToBounds" })},
                                               {"clearsContextBeforeDrawing", (new ProcessedObject() {Processor = "Bool", OutputName="ClearsContextBeforeDrawing" })},
                                               {"postsFrameChangedNotifications", (new ProcessedObject() {Processor = "Bool", OutputName="PostsFrameChangedNotifications"} )},
                                               {"autoresizingMask", (new ProcessedObject() {Processor = "Enum", OutputName="AutoresizingMask", Options = "NSViewResizingMask"})},
                                               {"frame", (new ProcessedObject() {Processor = "Rect", OutputName="Frame" })},
                                               {"wraps", (new ProcessedObject() {Processor = "Float", OutputName="Wraps"})},
                                               {"frameRotation", (new ProcessedObject() {Processor = "Float", OutputName="FrameRotation"})},
                                               {"frameCenterRotation", (new ProcessedObject() {Processor = "Float", OutputName="FrameCenterRotation"})},
                                                 {"boundsRotation", (new ProcessedObject() {Processor = "Float", OutputName="BoundsRotation"})},
                                               {"bounds", (new ProcessedObject() {Processor = "Rect", OutputName="Bounds"})},
                                                 {"needsDisplay", (new ProcessedObject() {Processor = "Bool", OutputName="NeedsDisplay"})},
                                                 {"canDrawConcurrently", (new ProcessedObject() {Processor = "Bool", OutputName="CanDrawConcurrently"})},
                                               {"acceptsTouchEvents", (new ProcessedObject() {Processor = "Bool", OutputName="AcceptsTouchEvents"})},
                                                  {"WantsRestingTouches", (new ProcessedObject() {Processor = "Bool", OutputName="WantsRestingTouches"})},
                                               {"wantsLayer", (new ProcessedObject() {Processor = "Bool", OutputName="WantsLayer"})},
                                                {"toolTip", (new ProcessedObject() {Processor = "String", OutputName="ToolTip"})},
                                                {"animations", (new ProcessedObject() {Processor = "Animation", OutputName="Animations"})},
                                                 {"backgroundFilters", (new ProcessedObject() {Processor = "BackgroundFilter", OutputName="BackgroundFilters"})},
                                                  {"contentFilters", (new ProcessedObject() {Processor = "ContentFilter", OutputName="ContentFilters"})},
                                                  //{"focusRingType", (new ProcessedObject() {Processor = "FocusRingType", OutputName="FocusRingType"})},
                                                  
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
