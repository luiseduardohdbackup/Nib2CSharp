using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;
namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UISliderProcessor : UIControlProcessor
    {
        public override string Name
        {
            get { return "UISlider"; }


            set {  }
        }

        public override string Handles
        {
            get { return "IBUISlider"; }


            set { }
        }

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "continuous")
            {
                output["Continuous"] = item.Parent.GetElementForKey("continuous").Value.BooleanString();
            }

            else  if (item.Value == "maxValue")
            {
                output["MaxValue"] = item.Parent.GetElementForKey("maxValue").Value;
            }

                 else  if (item.Value == "minValue")
            {
                output["MinValue"] = item.Parent.GetElementForKey("minValue").Value;
            }

                       else  if (item.Value == "value")
            {
                output["Value"] = item.Parent.GetElementForKey("value").Value;
            }
            else
            base.ProcessKey(item);
        }
        
    }
}
