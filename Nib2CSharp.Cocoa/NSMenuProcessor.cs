using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{

    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSMenuProcessor : IClassProcessor
    {
        public override string Name
        {
            get { return "NSMenu"; }
            set { }
        }

        public override string Handles
        {
            get { return "NSMenu"; }
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
                                               {"autoenablesItems", (new ProcessedObject() {Processor = "Bool", OutputName="AutoEnablesItems" })},
                                                {"showsStateColumn", (new ProcessedObject() {Processor = "Bool", OutputName="ShowsStateColumn" })},
                                               

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
            if (s == "NSMenuItem")
            {
                return String.Format("{0}.AddItem({1})", parentName, childname);
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

