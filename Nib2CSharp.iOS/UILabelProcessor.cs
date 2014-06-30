using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;
namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UILabelProcessor : UIViewProcessor
    {
        public override string Name
        {
            get { return "UILabel"; }


            set {  }
        }

        public override string Handles
        {
            get { return "IBUILabel"; }


            set { }
        }

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "text")
            {
                output["Text"] = item.Parent.GetElementForKey("text").Value.QuotedAsCodeString();
            }

            else if (item.Value == "textAlignment")
            {
                output["TextAlignment"] = item.Parent.GetElementForKey("text").Value.TextAlignmentString();
            }


            else if (item.Value == "textColor")
            {
                output["TextColor"] = item.Parent.GetElementForKey("textColor").Value.ColorString();
            }

            else if (item.Value == "font")
            {
                output["font"] = item.Parent.GetElementForKey("font").FontString();
            }


            else if (item.Value == "adjustsFontSizeToFitWidth")
            {
                output["AdjustsFontSizeToFitWidth"] = item.Parent.GetElementForKey("adjustsFontSizeToFitWidth").Value.BooleanString();
            }

            else if (item.Value == "minimumFontSize")
            {
                output["MinimumFontSize"] = item.Parent.GetElementForKey("minimumFontSize").Value;
            }


            else if (item.Value == "enabled")
            {
                output["AdjustsFontSizeToFitWidth"] = item.Parent.GetElementForKey("enabled").Value.BooleanString();
            }


            else if (item.Value == "baselineAdjustment")
            {
                output["BaselineAdjustment"] = item.Parent.GetElementForKey("baselineAdjustment").Value;
            }


            else if (item.Value == "lineBreakMode")
            {
                output["LineBreakMode"] = item.Parent.GetElementForKey("lineBreakMode").Value;
            }


            else if (item.Value == "shadowOffset")
            {
                output["ShadowOffset"] = item.Parent.GetElementForKey("shadowOffset").Value.SizeString();
            }

            else if (item.Value == "shadowColor")
            {
                output["ShadowColor"] = item.Parent.GetElementForKey("shadowColor").Value.ColorString();
            }
            else if (item.Value == "highlightedColor")
            {
                output["HighlightedColor"] = item.Parent.GetElementForKey("highlightedColor").Value.ColorString();
            }

            else
            base.ProcessKey(item);
        }
        
    }
}
