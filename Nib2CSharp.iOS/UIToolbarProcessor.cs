using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIToolbarProcessor : UIViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UIToolbar";
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
            if (item.Value == "tintColor")
            {
                output["tintColor"] = item.Parent.GetElementForKey("tintColor").Value;
            }
            else if (item.Value == "barStyle")
            {
                output["barStyle"] = item.Parent.GetElementForKey("barStyle").Value.BarStyleString();
            }
         
            else
                base.ProcessKey(item);
        }
    }
}
