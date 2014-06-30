using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSButtonCellProcessor : NSActionCellProcessor
    {
        public override string Name
        {
            get { return "NSButtonCell"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSButtonCell"; }
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
                                               {"title", (new ProcessedObject() {Processor = "String", OutputName="Title" })},
                                                {"alternateTitle", (new ProcessedObject() {Processor = "String", OutputName="AlternateTitle" })},
                                                 {"imagePosition", (new ProcessedObject() {Processor = "Enum", OutputName="ImagePosition",Options = "NSCellImagePosition"})},
                                                  {"imageScaling", (new ProcessedObject() {Processor = "Enum", OutputName="ImageScale",Options = "NSImageScale"})},
                                                  {"highlightsBy", (new ProcessedObject() {Processor = "Integer", OutputName="HighlightsBy" })},
                                                    {"showsStateBy", (new ProcessedObject() {Processor = "Integer", OutputName="ShowsStateBy" })},
                                                      {"isOpaque", (new ProcessedObject() {Processor = "Bool", OutputName="IsOpaque" })},
                                                    {"transparent", (new ProcessedObject() {Processor = "Bool", OutputName="Transparent" })},
                                                      {"keyEquivalent", (new ProcessedObject() {Processor = "String", OutputName="KeyEquivalent" })},
                                                    {"keyEquivalentModifierMask", (new ProcessedObject() {Processor = "Enum", OutputName="KeyEquivalentModifierMask",Options = "NSEventModifierMask"})},
                                                    {"keyEquivalentFont", (new ProcessedObject() {Processor = "Font", OutputName="KeyEquivalentFont" })},

                                                     {"alternateMnemonicLocation", (new ProcessedObject() {Processor = "Integer", OutputName="AlternateMnemonicLocation" })},
                                                {"alternateMnemonic", (new ProcessedObject() {Processor = "String", OutputName="AlternateMnemonic" })},
                                                 {"imageDimsWhenDisabled", (new ProcessedObject() {Processor = "Bool", OutputName="ImageDimsWhenDisabled" })},
                                                  {"showsBorderOnlyWhileMouseInside", (new ProcessedObject() {Processor = "Bool", OutputName="ShowsBorderOnlyWhileMouseInside" })},
                                                  {"backgroundColor", (new ProcessedObject() {Processor = "Color", OutputName="BackgroundColor" })},
                                                    {"attributedTitle", (new ProcessedObject() {Processor = "AttributedString", OutputName="AttributedTitle" })},
                                                      {"attributedAlternateTitle", (new ProcessedObject() {Processor = "AttributedString", OutputName="AttributedAlternateTitle" })},
                                                    {"bezelStyle", (new ProcessedObject() {Processor = "Enum", OutputName="BezelStyle",Options = "NSBezelStyle"})},
                                                      {"sound", (new ProcessedObject() {Processor = "Enum", OutputName="Sound",Options = "NSSound"})},
                                             
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

