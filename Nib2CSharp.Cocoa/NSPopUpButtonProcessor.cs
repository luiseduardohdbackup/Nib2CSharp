using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSPopUpButtonProcessor : NSButtonProcessor
    {
        public override string Name
        {
            get { return "NSPopUpButton"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSPopUpButton"; }
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

                                                  {"pullsDown", (new ProcessedObject() {Processor = "Bool", OutputName="pullsDown" })},
                                                {"autoEnablesItems", (new ProcessedObject() {Processor = "Bool", OutputName="AutoEnablesItems",
                                               })},
                                                 {"preferredEdge", (new ProcessedObject() {Processor = "Enum", OutputName="PreferredEdge",Options = "NSRectEdge"})},
                                             
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

