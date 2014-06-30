using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIButtonProcessor : UIControlProcessor
    {
          public override string Name
          {
              get
              {
                  return "UIButton";
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
                  return "IBUIButton";
              }
              set
              {
                  base.Handles = value;
              }
          }


          public override string ConstructorString()
          {
        
             
                  string style = input.GetElementForKey("buttonType").Value;
                  return String.Format("new {0}(){{ Type = {1} }}", Name, style);
           

         
          }


          public override void ProcessKey(System.Xml.Linq.XElement item)
          {
              if (item.Value == "adjustsImageWhenDisabled")
              {
                  output["adjustsImageWhenDisabled"] = item.Parent.GetElementForKey("adjustsImageWhenDisabled").Value.BooleanString();
              }
              else if (item.Value == "adjustsImageWhenHighlighted")
              {
                  output["adjustsImageWhenHighlighted"] = item.Parent.GetElementForKey("adjustsImageWhenHighlighted").Value.BooleanString();
              }
              else if (item.Value == "font")
              {
                  output["TitleLabel.Font"] = item.Parent.GetElementForKey("font").FontString();
              }
              else if (item.Value == "lineBreakMode")
              {
                  output["TitleLabel.LineBreakMode"] = item.Parent.GetElementForKey("lineBreakMode").Value.BooleanString();
              }
              else if (item.Value == "reversesTitleShadowWhenHighlighted")
              {
                  output["reversesTitleShadowWhenHighlighted"] = item.Parent.GetElementForKey("reversesTitleShadowWhenHighlighted").Value;
              }
              else if (item.Value == "showsTouchWhenHighlighted")
              {
                  output["ShowsTouchWhenHighlighted"] = item.Parent.GetElementForKey("showsTouchWhenHighlighted").Value.BooleanString();
              }
              else if (item.Value == "titleShadowOffset")
              {
                  output["TitleLabel.ShadowOffset"] = item.Parent.GetElementForKey("titleShadowOffset").Value;
              }

              else if (item.Value == "normalTitle")
              {
                  string method = String.Format("SetTitle({0}, UIControlState.Normal )", item.Parent.GetElementForKey("normalTitle").Value.QuotedAsCodeString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }

              else if (item.Value == "selectedTitle")
              {
                  string method = String.Format("SetTitle({0}, UIControlState.Selected )", item.Parent.GetElementForKey("selectedTitle").Value.QuotedAsCodeString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }
              else if (item.Value == "highlightedTitle")
              {
                  string method = String.Format("SetTitle({0}, UIControlState.Highlighted )", item.Parent.GetElementForKey("highlightedTitle").Value.QuotedAsCodeString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }

              else if (item.Value == "disabledTitle")
              {
                  string method = String.Format("SetTitle({0}, UIControlState.Disabled )", item.Parent.GetElementForKey("disabledTitle").Value.QuotedAsCodeString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }

              else if (item.Value == "normalTitleColor")
              {
                  string method = String.Format("SetTitle({0}, UIControlState.Normal )", item.Parent.GetElementForKey("normalTitleColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }

              else if (item.Value == "selectedTitleColor")
              {
                  string method = String.Format("SetTitle({0}, UIControlState.Selected )", item.Parent.GetElementForKey("selectedTitleColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }
              else if (item.Value == "highlightedTitleColor")
              {
                  string method = String.Format("SetTitleColor({0}, UIControlState.Highlighted )", item.Parent.GetElementForKey("highlightedTitleColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }

              else if (item.Value == "disabledTitleColor")
              {
                  string method = String.Format("SetTitleColor({0}, UIControlState.Disabled )", item.Parent.GetElementForKey("disabledTitleColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);
                  output[index] = method;
              }

              else if (item.Value == "normalTitleShadowColor")
              {
                  string method = String.Format("SetTitleShadowColor({0}, UIControlState.Normal )", item.Parent.GetElementForKey("normalTitleColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }

              else if (item.Value == "selectedTitleShadowColor")
              {
                  string method = String.Format("SetTitleShadowColor({0}, UIControlState.Selected )", item.Parent.GetElementForKey("selectedTitleColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }
              else if (item.Value == "disabledTitleShadowColor")
              {
                  string method = String.Format("SetTitleShadowColor({0}, UIControlState.Highlighted )", item.Parent.GetElementForKey("highlightedTitleColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);

                  output[index] = method;
              }

              else if (item.Value == "disabledTitleShadowColor")
              {
                  string method = String.Format("SetTitleShadowColor({0}, UIControlState.Disabled )", item.Parent.GetElementForKey("disabledTitleShadowColor").Value.ColorString());
                  string index = String.Format("__method__{0}", item.Value);
                  output[index] = method;
              }

              else
              base.ProcessKey(item);
          }
    }
}
