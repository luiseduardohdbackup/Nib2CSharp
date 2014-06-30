using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UISwitchProcessor : UIControlProcessor
    {
          public override string Name
          {
              get
              {
                  return "UISwitch";
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
                  return "IBUISwitch";
              }
              set
              {
                  base.Handles = value;
              }
          }
          public override void ProcessKey(System.Xml.Linq.XElement item)
          {
              if (item.Value == "on")
              {
                  output["On"] = item.Parent.GetElementForKey("on").Value.BooleanString();
              }
              else
              base.ProcessKey(item);
          }
    }
}
