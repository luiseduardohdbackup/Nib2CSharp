using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UITableViewProcessor : UIViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UITableView";
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


        public override string ConstructorString()
        {


            string style = input.GetElementForKey("style").Value;
            return String.Format("new {0}(){{ Title = {1}, Frame = {2} }}", Name, style, FrameString());

        }



        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "rowHeight")
            {
                output["rowHeight"] = item.Parent.GetElementForKey("rowHeight").GetElementForKey("description").Value;
            }
            else if (item.Value == "sectionFooterHeight")
            {
                output["sectionFooterHeight"] = item.Parent.GetElementForKey("sectionFooterHeight").GetElementForKey("description").Value.BooleanString();
            }
                  else if (item.Value == "sectionHeaderHeight")
            {
                output["sectionHeaderHeight"] = item.Parent.GetElementForKey("sectionHeaderHeight").GetElementForKey("description").Value.BooleanString();
            }

            else if (item.Value == "separatorStyle")
            {
                output["separatorStyle"] = item.Parent.GetElementForKey("separatorStyle").Value;
            }

            else if (item.Value == "sectionIndexMinimumDisplayRowCount")
            {
                output["sectionIndexMinimumDisplayRowCount"] = item.Parent.GetElementForKey("sectionIndexMinimumDisplayRowCount").Value;
            }

            else if (item.Value == "allowsSelectionDuringEditing")
            {
                output["allowsSelectionDuringEditing"] = item.Parent.GetElementForKey("allowsSelectionDuringEditing").Value;
            }
         
         
            else
                base.ProcessKey(item);
        }
    }
}
