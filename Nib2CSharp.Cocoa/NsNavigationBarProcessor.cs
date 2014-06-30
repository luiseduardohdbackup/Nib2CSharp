using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsNavigationBarProcessor : NSViewProcessor
    {
        public override string Name
        {
            get { return "UINavigationBar"; }
            set { }
        }
        public override string Handles { get { return "IBUINavigationBarProcessor"; }  set { }
        }




        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
                
              if (item.Value == "tintColor")
              {
                  output["TintColor"] = item.Parent.GetElementForKey("tintColor").Value.ColorString();
              }
              else      if (item.Value == "barStyle")
              {
                  output["BarStyle"] = item.Parent.GetElementForKey("barStyle").Value.BarStyleString();
              }
            

              else
              base.ProcessKey(item);
          }
        
        }
    }

