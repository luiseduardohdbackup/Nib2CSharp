using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIProgressViewProcessor : UIViewProcessor
    {
        public override string Name
        {
            get { return "UIProgressView"; }
            set { }
        }
        public override string Handles { get { return "IBUIProgressView"; }  set { }
        }


        public override string  ConstructorString()
        {
            string style = input.GetElementForKey("progressViewStyle").Value;
 	return String.Format("new {0}(){{ ProgressViewStyle = {1}}}", Name, style);
}

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
                
              if (item.Value == "progress")
              {
                  output["Progress"] = item.Parent.GetElementForKey("progress").Value;
              }
              else    if (item.Value == "progressViewStyle")
              {
                  output["ProgressViewStyle"] = item.Parent.GetElementForKey("progressViewStyle").Value;
              }
        
              else
              base.ProcessKey(item);
          }
        
        }
    }

