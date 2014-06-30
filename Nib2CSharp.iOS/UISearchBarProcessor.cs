using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UISearchBarProcessor : IClassProcessor
    {
        public override Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { return "UISearchBar"; }
            set { }
        }
        public override string Handles
        {
            get { return "IBUISearchBar"; }
            set { }
        }

        public override List<string> Hidden
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public override void ProcessKey(System.Xml.Linq.XElement item)
        {

            if (item.Value == "tintColor")
              {
                  output["tintColor"] = item.Parent.GetElementForKey("tintColor").Value;
              }
            else if (item.Value == "showsBookmarkButton")
              {
                  output["showsBookmarkButton"] = item.Parent.GetElementForKey("showsBookmarkButton").Value.BooleanString();
              }
            else if (item.Value == "showsBookmarkButton")
            {
                output["showsBookmarkButton"] = item.Parent.GetElementForKey("showsBookmarkButton").Value.BooleanString();
            }
            else if (item.Value == "showsCancelButton")
            {
                output["showsCancelButton"] = item.Parent.GetElementForKey("showsCancelButton").Value.BooleanString();
            }
            else if (item.Value == "showsScopeBar")
            {
                output["showsScopeBar"] = item.Parent.GetElementForKey("showsScopeBar").Value.BooleanString();
            }
            else if (item.Value == "showsSearchResultsButton")
            {
                output["showsSearchResultsButton"] = item.Parent.GetElementForKey("showsSearchResultsButton").Value.BooleanString();
            }
            else if (item.Value == "scopeButtonTitles")
            {
               
                string aString = "new string[] {";
                foreach (var title in  item.Parent.GetElementForKey("showsSearchResultsButton").Value.Split())
                {
                    aString += String.Format("\"{0}\", ", title);
                }

                aString.Remove(aString.Count() - 3);
                aString += "}";
                 output["scopeButtonTitles"] = aString;

           
            }
            else if (item.Value == "placeholder")
            {
                output["placeholder"] = item.Parent.GetElementForKey("placeholder").Value.QuotedAsCodeString();
            }
            else if (item.Value == "prompt")
            {
                output["prompt"] = item.Parent.GetElementForKey("prompt").Value;
            }
            else if (item.Value == "barStyle")
            {
                output["barStyle"] = item.Parent.GetElementForKey("barStyle").Value.BarStyleString();
            }
         
              else
              base.ProcessKey(item);
          }
        
        }
    }

