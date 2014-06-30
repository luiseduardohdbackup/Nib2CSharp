using System;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsTableViewCellProcessor : NSViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UITableViewCell";
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
                return "IB"+Name;
            }
            set
            {
                base.Handles = value;
            }
        }


        public override string ConstructorString()
        {


            string reuseIdentifier = input.GetElementForKey("reuseIdentifier").Value.QuotedAsCodeString();

            if(String.IsNullOrEmpty(reuseIdentifier))
            {
                reuseIdentifier = "\"UITableViewCellReuseIdentifier\"";
            }

            return String.Format("new {0}(){{ reuseIdentifier = {1} }}", Name, reuseIdentifier);

        }



        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "textAlignment")
            {
                output["textLabel.textAlignment"] = item.Parent.GetElementForKey("textAlignment").Value;
                output["detailTextLabel.textAlignment"] = item.Parent.GetElementForKey("textAlignment").Value;
            }

            else if (item.Value == "lineBreakMode")
            {
                output["textLabel.lineBreakMode"] = item.Parent.GetElementForKey("lineBreakMode").Value;
                output["detailTextLabel.lineBreakMode"] = item.Parent.GetElementForKey("lineBreakMode").Value;
            }

            else if (item.Value == "textColor")
            {
                output["textLabel.textColor"] = item.Parent.GetElementForKey("textColor").Value;
                output["detailTextLabel.textColor"] = item.Parent.GetElementForKey("textColor").Value;
            }
            else if (item.Value == "selectedTextColor")
            {
                output["textLabel.selectedTextColor"] = item.Parent.GetElementForKey("selectedTextColor").Value;
                output["detailTextLabel.selectedTextColor"] = item.Parent.GetElementForKey("selectedTextColor").Value;
            }
            else if (item.Value == "highlightedTextColor")
            {
                output["textLabel.highlightedTextColor"] = item.Parent.GetElementForKey("highlightedTextColor").Value;
                output["detailTextLabel.highlightedTextColor"] = item.Parent.GetElementForKey("highlightedTextColor").Value;
            }
            else if (item.Value == "showsReorderControl")
            {
                output["showsReorderControl"] = item.Parent.GetElementForKey("showsReorderControl").Value.BooleanString();
            
            }

            else if (item.Value == "shouldIndentWhileEditing")
            {
                output["shouldIndentWhileEditing"] = item.Parent.GetElementForKey("shouldIndentWhileEditing").Value.BooleanString();

            }

            else if (item.Value == "indentationWidth")
            {
                output["indentationWidth"] = item.Parent.GetElementForKey("indentationWidth").Value.BooleanString();

            }

            else if (item.Value == "indentationLevel")
            {
                output["indentationLevel"] = item.Parent.GetElementForKey("indentationLevel").Value.BooleanString();

            }

            else if (item.Value == "accessoryType")
            {
                output["accessoryType"] = item.Parent.GetElementForKey("accessoryType").Value.BooleanString();

            }

            else if (item.Value == "editingAccessoryType")
            {
                output["editingAccessoryType"] = item.Parent.GetElementForKey("editingAccessoryType").Value.BooleanString();

            }

            else if (item.Value == "selectionStyle")
            {
                output["selectionStyle"] = item.Parent.GetElementForKey("selectionStyle").Value.BooleanString();

            }
        
            else
                base.ProcessKey(item);
        }
    }
}
