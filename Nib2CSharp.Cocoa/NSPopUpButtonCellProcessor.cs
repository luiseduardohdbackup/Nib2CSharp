using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSPopUpButtonCellProcessor : NSMenuItemCellProcessor
    {
        public override string Name
        {
            get { return "NSPopUpButtonCell"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSPopUpButtonCell"; }
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
                                               {"pullsDown", (new ProcessedObject() {Processor = "Bool", OutputName="PullsDown" })},
                                                {"altersStateOfSelectedItem", (new ProcessedObject() {Processor = "Bool", OutputName="AltersStateOfSelectedItem" })},
                                                 {"arrowPosition", (new ProcessedObject() {Processor = "Enum", OutputName="ArrowPosition", Options = "NSPopUpArrowPosition"})},
                                                  {"autoenablesItems", (new ProcessedObject() {Processor = "Bool", OutputName="AutoenablesItems" })},
                                                     {"preferredEdge", (new ProcessedObject() {Processor = "Enum", OutputName="PreferredEdge", Options = "NSRectEdge"})},
                                                 
                                              
                                                   
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
                return String.Format("{0}.Menu={1}", parentName, childname);
            }
            return base.AddChild(parentName, childname);
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

