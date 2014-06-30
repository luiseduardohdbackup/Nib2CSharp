using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSTableColumnProcessor : IClassProcessor
    {
       

        public new string Name { get { return "NSTableColumn"; } set { } }
        public override string Handles
        {
            get { return "NSTableColumn"; }
            set { }


        }

        

        
        public new  List<string> Hidden
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
                                               {"headerCell.alignment", (new ProcessedObject() {Processor = "Enum", OutputName="HeaderCell.Alignment",Options ="NSTextAlignment" })},
                                                {"headerCell.baseWritingDirection", (new ProcessedObject() {Processor = "Enum", OutputName="HeaderCell.BaseWritingDirection", Options = "NSWritingDirection"})},
                                                 {"headerCell.font", (new ProcessedObject() {Processor = "Font", OutputName="HeaderCell.Font" })},
                                                  {"headerCell.title", (new ProcessedObject() {Processor = "String", OutputName="HeaderCell.Title" })},
                                                  {"hidden", (new ProcessedObject() {Processor = "Bool", OutputName="Hidden" })},
                                                    {"editable", (new ProcessedObject() {Processor = "Bool", OutputName="Editable" })},
                                                      {"maxWidth", (new ProcessedObject() {Processor = "Float", OutputName="MaxWidth" })},
                                                    {"minWidth", (new ProcessedObject() {Processor = "Float", OutputName="MinWidth" })},
                                                      {"width", (new ProcessedObject() {Processor = "Float", OutputName="Width" })},
                                                
                                               {"resizingMask", (new ProcessedObject() {Processor = "Enum", OutputName="ResizingMask", Options = "NSTableColumnResizingMask" })},
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
            return String.Format("{0}.DataCell={1}", parentName, childname);
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
