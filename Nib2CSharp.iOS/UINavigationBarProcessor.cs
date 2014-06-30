using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UINavigationBarProcessor : UIViewProcessor
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

