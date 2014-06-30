using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsWebViewProcessor:NSViewProcessor
    
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
