using System;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsPageControlProcessor : NsControlProcessor
    {
        public override string Name
        {
            get { return "UIPageControl"; }
            set { }
        }
        public override string Handles { get { return "IBUIPageControl"; }  set { }
        }


        public override string  ConstructorString()
        {
            string title = input.GetElementForKey("title").Value;
 	return String.Format("new {0}(){{ Title = {1}}}", Name, title);
}

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
                
              if (item.Value == "currentPage")
              {
                  output["CurrentPage"] = item.Parent.GetElementForKey("currentPage").Value;
              }
              else      if (item.Value == "numberOfPages")
              {
                  output["NumberOfPages"] = item.Parent.GetElementForKey("numberOfPages").Value.QuotedAsCodeString();
              }
               else      if (item.Value == "HidesForSinglePage")
              {
                  output["HidesForSinglePage"] = item.Parent.GetElementForKey("hidesForSinglePage").Value.QuotedAsCodeString();
              }
                 else      if (item.Value == "defersCurrentPageDisplay")
              {
                  output["DefersCurrentPageDisplay"] = item.Parent.GetElementForKey("defersCurrentPageDisplay").Value.QuotedAsCodeString();
              }
                  
              else
              base.ProcessKey(item);
          }
        
        }
    }

