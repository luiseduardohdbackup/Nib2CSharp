using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIPickerViewProcessor : UIViewProcessor
    {
        public override string Name
        {
            get { return "UIPickerView"; }
            set { }
        }
        public override string Handles { get { return "IBUIPickerView"; }  set { }
        }


      

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {

            if (item.Value == "showsSelectionIndicator")
              {
                  output["ShowsSelectionIndicator"] = item.Parent.GetElementForKey("showsSelectionIndicator").Value.BooleanString();
              }
           
        
              else
              base.ProcessKey(item);
          }
        
        }
    }

