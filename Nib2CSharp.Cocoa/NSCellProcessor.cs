using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSCellProcessor : IClassProcessor
    {
        public override string Name
        {
            get { return "NSCell"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSCell"; }
            set { }
        }
        public new List<string> Hidden
        {
            get { return new List<string>() {  "allowsMixedState" }; }
            set { ; }

        }

        public new virtual Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                {
                      {"tag", (new ProcessedObject() {Processor = "Integer", OutputName="Tag" })},
                                               {"title", (new ProcessedObject() {Processor = "String", OutputName="Title" })},
                                               {"isOpaque", (new ProcessedObject() {Processor = "Bool", OutputName="IsOpaque" })},
                                               {"enabled", (new ProcessedObject() {Processor = "Bool", OutputName="Enabled" })},
                                               {"continuous", (new ProcessedObject() {Processor = "Bool", OutputName="IsContinuous" })},
                                                  {"selectable", (new ProcessedObject() {Processor = "Bool", OutputName="Selectable" })},
                                               {"bordered", (new ProcessedObject() {Processor = "Bool", OutputName="Bordered" })},
                                                 {"bezeled", (new ProcessedObject() {Processor = "Bool", OutputName="Bezeled" })},
                                               {"editable", (new ProcessedObject() {Processor = "Bool", OutputName="Editable" })},
                                               {"highlighted", (new ProcessedObject() {Processor = "Bool", OutputName="Highlighted" })},
                                                    {"alignment", (new ProcessedObject() {Processor = "Enum", OutputName="Alignment",Options = "NSTextAlignment"})},
                                                  {"scrollable", (new ProcessedObject() {Processor = "Bool", OutputName="Scrollable" })},
                                               {"wraps", (new ProcessedObject() {Processor = "Bool", OutputName="Wraps" })},  
                                                 {"font", (new ProcessedObject() {Processor =  "Font", OutputName="Font" })},  
                                                   {"keyEquivalent", (new ProcessedObject() {Processor = "string", OutputName="KeyEquivalent" })},  
                                                     {"hasValidObjectValue", (new ProcessedObject() {Processor = "Bool", OutputName="HasValidObjectValue" })}, 
                                                      {"baseWritingDirection", (new ProcessedObject() {Processor = "Enum", OutputName="BaseWritingDirection", Options = "NSWritingDirection"})}, 
                                                       {"lineBreakMode", (new ProcessedObject() {Processor = "Enum", OutputName="LineBreakMode",Options = "NSLineBreakMode"})}, 
                                                         {"allowsUndo", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsUndo" })}, 
                                                          {"truncatesLastVisibleLine", (new ProcessedObject() {Processor = "Bool", OutputName="TruncatesLastVisibleLine" })}, 
                                                           {"userInterfaceLayoutDirection", (new ProcessedObject() {Processor = "Enum", OutputName="UserInterfaceLayoutDirection",Options ="NSUserInterfaceLayoutDirection" })}, 
                                                            {"usesSingleLineMode", (new ProcessedObject() {Processor = "Bool", OutputName="UsesSingleLineMode" })},
                                                              {"mnemonicLocation", (new ProcessedObject() {Processor = "Integer", OutputName="MnemonicLocation" })}, 
                                                                {"focusRingType", (new ProcessedObject() {Processor = "Enum", OutputName="FocusRingType", Options = "NSFocusRingType" })}, 
                                                                 {"allowsEditingTextAttributes", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsEditingTextAttributes" })},
                                                                   {"importsGraphics", (new ProcessedObject() {Processor = "Bool", OutputName="ImportsGraphics" })},
                                                                     //{"allowsMixedState", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsMixedState" })},
                                                                       {"backgroundStyle", (new ProcessedObject() {Processor = "BackgroundStyle", OutputName="BackgroundStyle" })},
                                                                         {"interiorBackgroundStyle", (new ProcessedObject() {Processor = "BackgroundStyle", OutputName="InteriorBackgroundStyle" })},
                                                                          {"controlSize", (new ProcessedObject() {Processor = "Enum", OutputName="ControlSize",Options = "NSControlSize"})},
                                                                          {"state", (new ProcessedObject() {Processor = "Enum", OutputName="State",Options = "NSCellStateValue"})},   
                                                                           {"refusesFirstResponder", (new ProcessedObject() {Processor = "Bool", OutputName="ShowsFirstResponder" })}, 
                                                                              {"sendsActionOnEndEditing", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsEditingTextAttributes" })}, 
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

