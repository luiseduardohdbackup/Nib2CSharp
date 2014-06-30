using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsPickerViewProcessor : NSViewProcessor
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

