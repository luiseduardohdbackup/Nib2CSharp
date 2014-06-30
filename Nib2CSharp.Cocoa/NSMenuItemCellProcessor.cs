using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSMenuItemCellProcessor : NSButtonCellProcessor
    {
        public override string Name
        {
            get { return "NSMenuItemCell"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSMenuItemCell"; }
            set { }
        }
        public new List<string> Hidden
        {
            get { return new List<string>() { "frameOrigin", "frameSize", "ibExternalIdentityShowNotesWithSelection","tag" }; }
            set { ; }

        }

        public new Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {
                                               {"imageWidth", (new ProcessedObject() {Processor = "Float", OutputName="imageWidth" })},
                                                {"titleWidth", (new ProcessedObject() {Processor = "Float", OutputName="TitleWidth" })},
                                                 {"keyEquivalentWidth", (new ProcessedObject() {Processor = "Float", OutputName="KeyEquivalentWidth"})},
                                                  //{"tag", (new ProcessedObject() {Processor = "Integer", OutputName="Tag"})},
                                                  {"needsSizing", (new ProcessedObject() {Processor = "Bool", OutputName="NeedsSizing" })},
                                                    {"needsDisplay", (new ProcessedObject() {Processor = "Bool", OutputName="NeedsDisplay" })},
                                                   
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

