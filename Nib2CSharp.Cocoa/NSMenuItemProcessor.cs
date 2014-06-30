using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{

    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSMenuItemProcessor : IClassProcessor
    {
        public override string Name
        {
            get { return "NSMenuItem"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSMenuItem"; }
            set { }
        }
        public new List<string> Hidden
        {
            get { return new List<string>() { "contentBorderThicknessMaxXEdge", "contentBorderThicknessMaxYEdge", "contentBorderThicknessMinXEdge",
                "contentBorderThicknessMinYEdge", "autorecalculatesContentBorderThicknessMaxXEdge", "autorecalculatesContentBorderThicknessMaxYEdge",
                "autorecalculatesContentBorderThicknessMinXEdge","onStateImage", "autorecalculatesContentBorderThicknessMinYEdge", "contentRectOrigin", "contentRectSize","oneShot","wantsToBeColor","deferred","mixedStateImage"            };
            }
            set { ; }

        }

        public new virtual Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {
                                               {"alternate", (new ProcessedObject() {Processor = "Bool", OutputName="Alternate" })},
                                                {"enabled", (new ProcessedObject() {Processor = "Bool", OutputName="Enabled" })},
                                                 {"hidden", (new ProcessedObject() {Processor = "Bool", OutputName="Hidden" })},
                                                   {"highlighted", (new ProcessedObject() {Processor = "Bool", OutputName="Highlighted" })},
                                                  {"indentationLevel", (new ProcessedObject() {Processor = "Integer", OutputName="IndentationLevel" })},
                                                {"keyEquivalent", (new ProcessedObject() {Processor = "String", OutputName="KeyEquivalent" })},

                                                  //{"deferred", (new ProcessedObject() {Processor = "Bool", OutputName="Deferred" })},
                                                {"keyEquivalentModifierMask", (new ProcessedObject() {Processor = "Enum", OutputName="KeyEquivalentModifierMask", Options = "NSEventModifierMask" })},
                                                 {"state", (new ProcessedObject() {Processor = "Enum", OutputName="State", Options = "NSCellStateValue"})},
                                               //{"oneShot", (new ProcessedObject() {Processor = "Bool", OutputName="IsOneShot" })},
                                                    {"tag", (new ProcessedObject() {Processor = "State", OutputName="Tag" })},

                                                     {"title", (new ProcessedObject() {Processor = "String", OutputName="Title" })},
                                                 
                                                    
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
            if (s == "NSMenu")
            {
                return String.Format("{0}.Submenu={1}", parentName, childname);
            }
            return base.AddChild(parentName, childname);
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

