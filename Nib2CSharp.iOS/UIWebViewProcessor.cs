using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIWebViewProcessor:UIViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UIWebView";
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
            if (item.Value == "scalesPageToFit")
            {
                output["scalesPageToFit"] = item.Parent.GetElementForKey("scalesPageToFit").Value.BooleanString();
            }
            else if (item.Value == "detectsPhoneNumbers")
            {
                output["detectsPhoneNumbers"] = item.Parent.GetElementForKey("detectsPhoneNumbers").Value.BooleanString();
            }
         
            else
                base.ProcessKey(item);
        }
    }
}
