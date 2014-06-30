using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UITextFieldProcessor : UIViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UITextField";
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
            if (item.Value == "placeholder")
            {
                output["placeholder"] = item.Parent.GetElementForKey("placeholder").Value.QuotedAsCodeString();
            }
            else if (item.Value == "textAlignment")
            {
                output["textAlignment"] = item.Parent.GetElementForKey("textAlignment").Value.TextAlignmentString();
            }
            else if (item.Value == "textColor")
            {
                output["textColor"] = item.Parent.GetElementForKey("textColor").Value.ColorString();
            }
            else if (item.Value == "clearsOnBeginEditing")
            {
                output["clearsOnBeginEditing"] = item.Parent.GetElementForKey("clearsOnBeginEditing").Value.BooleanString();
            }
            else if (item.Value == "adjustsFontSizeToFitWidth")
            {
                output["adjustsFontSizeToFitWidth"] = item.Parent.GetElementForKey("adjustsFontSizeToFitWidth").Value.BooleanString();
            }
            else if (item.Value == "minimumFontSize")
            {
                output["minimumFontSize"] = item.Parent.GetElementForKey("minimumFontSize").Value;
            }


            else if (item.Value == "textInputTraits.enablesReturnKeyAutomatically")
            {
                output["textInputTraits.enablesReturnKeyAutomatically"] = item.Parent.GetElementForKey("textInputTraits.enablesReturnKeyAutomatically").Value.BooleanString();
            }

            else if (item.Value == "textInputTraits.secureTextEntry")
            {
                output["secureTextEntry"] = item.Parent.GetElementForKey("textInputTraits.secureTextEntry").Value.BooleanString();
            }

            else if (item.Value == "textInputTraits.keyboardAppearance")
            {
                output["keyboardAppearance"] = item.Parent.GetElementForKey("textInputTraits.keyboardAppearance").Value;
            }
            else if (item.Value == "textInputTraits.returnKeyType")
            {
                output["returnKeyType"] = item.Parent.GetElementForKey("textInputTraits.returnKeyType").Value;
            }
            else if (item.Value == "textInputTraits.autocapitalizationType")
            {
                output["autocapitalizationType"] = item.Parent.GetElementForKey("textInputTraits.autocapitalizationType").Value.TextAlignmentString();
            }
            else if (item.Value == "textInputTraits.autocorrectionType")
            {
                output["autocorrectionType"] = item.Parent.GetElementForKey("textInputTraits.autocorrectionType").Value.TextAlignmentString();
            }
            else if (item.Value == "textInputTraits.keyboardType")
            {
                output["keyboardType"] = item.Parent.GetElementForKey("textInputTraits.keyboardType").Value.TextAlignmentString();
            }
            else if (item.Value == "clearButtonMode")
            {
                output["clearButtonMode"] = item.Parent.GetElementForKey("clearButtonMode").Value.TextAlignmentString();
            }
         
            else
                base.ProcessKey(item);
        }
    }
}
