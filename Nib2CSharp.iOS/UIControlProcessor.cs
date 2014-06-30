using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIControlProcessor : UIViewProcessor
    {
        public override string Name { get { return "UIControl"; } set{}}
        public override string Handles { get { return "IBUIControl"; } set { }


        }

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {

                         if (item.Value == "contentHorizontalAlignment")
                         {
                             output["ContentVerticalAlignment"] = item.Parent.GetElementForKey("contentHorizontalAlignment").Value;
                         }
                   else      if (item.Value == "contentVerticalAlignment")
            {
                output["ContentVerticalAlignment"] = item.Parent.GetElementForKey("contentVerticalAlignment").Value;
            }


                   else      if (item.Value == "enabled")
            {
                output["Enabled"] = item.Parent.GetElementForKey("enabled").Value.BooleanString();
            }

                                  else      if (item.Value == "highlighted")
            {
                output["Highlighted"] = item.Parent.GetElementForKey("highlighted").Value.BooleanString();
            }
 
                                                    else      if (item.Value == "selected")
            {
                output["Selected"] = item.Parent.GetElementForKey("selected").Value.BooleanString();
            }
   
    else
    {
           base.ProcessKey(item);
    }

        
        }

    }
}
