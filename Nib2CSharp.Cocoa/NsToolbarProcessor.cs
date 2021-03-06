﻿using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsToolbarProcessor : NSViewProcessor
    
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
