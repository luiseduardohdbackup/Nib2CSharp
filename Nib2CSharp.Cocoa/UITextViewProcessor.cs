using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsTextViewProcessor : NsScrollViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UITextView";
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




        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "text")
            {
                output["text"] = item.Parent.GetElementForKey("text").Value.QuotedAsCodeString();
            }
            else if (item.Value == "textAlignment")
            {
                output["textAlignment"] = item.Parent.GetElementForKey("textAlignment").Value.TextAlignmentString();
            }
            else if (item.Value == "font")
            {
                output["font"] = item.Parent.GetElementForKey("font").FontString();
            }
            else if (item.Value == "textColor")
            {
                output["textColor"] = item.Parent.GetElementForKey("textColor").Value.TextAlignmentString();
            }
            else if (item.Value == "editable")
            {
                output["editable"] = item.Parent.GetElementForKey("editable").Value.BooleanString();
            }
            else
                base.ProcessKey(item);
        }
    }
}
