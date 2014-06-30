using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsTableViewProcessor : NSViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "NSTableView";
            }
            set
            {
                base.Name = value;
            }
        }

        public override string Handles
        {
            get
            {
                return Name;
            }
            set
            {
                base.Handles = value;
            }
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
                                                {"borderType", (new ProcessedObject() {Processor = "Enum", OutputName="BorderType",Options = "NSBorderType"})},
                                              
                                                   {"allowsColumnReordering", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsColumnReordering"})},
                                                     {"enabled", (new ProcessedObject() {Processor = "Bool", OutputName="Enabled"})},

                                                    {"allowsColumnResizing", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsColumnResizing"})},
                                                     {"allowsColumnSelection", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsColumnSelection"})},

                                                      {"allowsEmptySelection", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsEmptySelection"})},
                                                    {"allowsMultipleSelection", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsMultipleSelection"})},
                                                     {"allowsTypeSelect", (new ProcessedObject() {Processor = "Bool", OutputName="AllowsTypeSelect"})},
                                                        {"autosaveTableColumns", (new ProcessedObject() {Processor = "Bool", OutputName="AutosaveTableColumns"})},
                                                         {"columnAutoresizingStyle", (new ProcessedObject() {Processor = "Enum", OutputName="ColumnAutoresizingStyle", Options = "NSTableViewColumnAutoresizingStyle"})},
                                               {"gridColor", (new ProcessedObject() {Processor = "Color", OutputName="GridColor"})},
                                                     {"rowHeight", (new ProcessedObject() {Processor = "Float", OutputName="RowHeight"})},                    
                                                         {"gridStyleMask", (new ProcessedObject() {Processor = "Enum", OutputName="GridStyleMask",Options = "NSTableViewGridStyleMask"})},          
                                                {"selectionHighlightStyle", (new ProcessedObject() {Processor = "Enum", OutputName="SelectionHighlightStyle",Options = "NSTableViewSelectionHighlightStyle"})},        
                                              {"usesAlternatingRowBackgroundColors", (new ProcessedObject() {Processor = "Bool", OutputName="UsesAlternatingRowBackgroundColors"})}, 
                                                
                                           };



                return objectProcessors;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
      
        public override string AddChild(string parentName, string childname, string @class)
        {
            if (@class == "NSTableColumn")
            {
                return String.Format("{0}.AddColumn({1})", parentName, childname);
            }
            else
            {
                return base.AddChild(parentName,childname);
            }
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
