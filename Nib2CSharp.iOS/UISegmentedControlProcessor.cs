using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UISegmentedControlProcessor : UIControlProcessor
    {
        public override string Name
        {
            get { return "UISegmentedControl"; }
            set { }
        }
        public override string Handles
        {
            get { return "IBUISegmentedControl"; }
            set { }
        }

        public override string ConstructorString()
        {
          

            string aString = "new string[] {";
            foreach (var title in input.GetElementForKey("segmentTitles").Value.Split(','))
            {
                aString += String.Format("\"{0}\", ", title);
            }

            aString.Remove(aString.Count() - 3);
            aString += "}";

         
            return String.Format("new {0}(){{ Items = {1}}}", Name, aString);
          
        }
      
        public override void ProcessKey(System.Xml.Linq.XElement item)
        {

            if (item.Value == "segmentControlStyle")
              {
                  output["segmentControlStyle"] = item.Parent.GetElementForKey("segmentControlStyle").Value;
              }
            else if (item.Value == "segmentControlStyle")
              {
                  output["ShowsHorizontalScrollIndicator"] = item.Parent.GetElementForKey("showsHorizontalScrollIndicator").Value;
              }
            else if (item.Value == "momentary")
            {
                output["momentary"] = item.Parent.GetElementForKey("momentary").Value.BooleanString();
            }
          
              else
              base.ProcessKey(item);
          }
        
        }
    }

