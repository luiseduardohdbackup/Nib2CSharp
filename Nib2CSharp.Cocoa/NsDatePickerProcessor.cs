using System;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsDatePickerProcessor : NsControlProcessor
    {
          public override string Name
          {
              get
              {
                  return "UIDatePicker";
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
                  return "IBUIDatePicker";
              }
              set
              {
                  base.Handles = value;
              }
          }


     

          public override void ProcessKey(System.Xml.Linq.XElement item)
          {
              if (item.Value == "datePickerMode")
              {
                  output["datePickerMode"] = item.Parent.GetElementForKey("datePickerMode").Value;
              }
              else if (item.Value == "timeZone")
              {
                  output["timeZone"] = item.Parent.GetElementForKey("timeZone").Value;
              }
              else if (item.Value == "font")
              {
                  output["TitleLabel.Font"] = item.Parent.GetElementForKey("font").FontString();
              }
              else if (item.Value == "locale")
              {
                  output["locale"] = item.Parent.GetElementForKey("locale").Value;
              }
              else if (item.Value == "minuteInterval")
              {
                  output["minuteInterval"] = item.Parent.GetElementForKey("minuteInterval").Value;
              }
              else if (item.Value == "date")
              {
                  output["date"] = String.Format("new DateTime({0})", item.Parent.GetElementForKey("date").Value.DateString().QuotedAsCodeString());
              }
              else if (item.Value == "maximumDate")
              {
                  output["maximumDate"] = String.Format("new DateTime({0})", item.Parent.GetElementForKey("maximumDate").Value.DateString().QuotedAsCodeString());
              }
              else if (item.Value == "minimumDate")
              {
                  output["minimumDate"] = String.Format("new DateTime({0})", item.Parent.GetElementForKey("minimumDate").Value.DateString().QuotedAsCodeString());
              }
              else if (item.Value == "countDownDuration")
              {
                  output["countDownDuration"] = item.Parent.GetElementForKey("countDownDuration").Value;
              }

              else
              base.ProcessKey(item);
          }
    }
}
