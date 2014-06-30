using System;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsActivityIndicatorViewProcessor : NSViewProcessor
    {
        public override string Name
        {
            get
            {
                return "UIActivityIndicatorView";
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
                return "IBUIActivityIndicatorView";
            }
            set
            {
                base.Handles = value;
            }
        }

        public override string ConstructorString()
        {
            string style = input.GetElementForKey("style").Value;
          //    NSString *style = [[self.input objectForKey:@"style"] activityIndicatorViewStyleString];
    return String.Format("{0} = new UIActivityIndicatorView() {{ Style = {1} }}",Name,style);
          
          
        }

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "hidesWhenStopped")
            {
                output["HidesWhenStopped"] = item.Parent.GetElementForKey("hidesWhenStopped").Value.BooleanString();
            }
            else if (item.Value == "animating")
            {
               bool animating= Convert.ToBoolean(item.Parent.GetElementForKey("animating").Value.BooleanString());

                if(animating)
                    output["__method__animating"] = "StartAnimating";
                else
                    output["__method__animating"] = "StopAnimating";
            }
            else
                base.ProcessKey(item);
        }
    }
}
