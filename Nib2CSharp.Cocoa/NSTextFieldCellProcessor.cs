using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSTextFieldCellProcessor : NSCellProcessor
    {
        public override string Name
        {
            get { return "NSTextFieldCell"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSTextFieldCell"; }
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
                                               {"backgroundColor", (new ProcessedObject() {Processor = "Color", OutputName="BackgroundColor" })},
                                                {"drawsBackground", (new ProcessedObject() {Processor = "Bool", OutputName="DrawsBackground" })},
                                                 {"textColor", (new ProcessedObject() {Processor = "Color", OutputName="TextColor" })},

                                                  {"bezelStyle", (new ProcessedObject() {Processor = "Enum", OutputName="BezelStyle", Options = "NSTextFieldBezelStyle" })},
                                                {"placeholderString", (new ProcessedObject() {Processor = "String", OutputName="PlaceholderString" })},
                                                 {"placeholderAttributedString", (new ProcessedObject() {Processor = "AttributedString", OutputName="PlaceholderAttributedString" })},
                                                  {"allowedInputSourceLocales", (new ProcessedObject() {Processor = "StringList", OutputName="AllowedInputSourceLocales" })},
                                                   {"objectValue", (new ProcessedObject() {Processor = "Object", OutputName="ObjectValue", Options = "NSString"})},
                                             
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

