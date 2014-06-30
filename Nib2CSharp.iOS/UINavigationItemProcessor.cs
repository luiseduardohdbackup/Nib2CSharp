using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class UINavigationItemProcessor : IClassProcessor
    {
        public override Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { return "UINavigationItemProcessor"; }
            set { }
        }
        public override string Handles { get { return "IBUINavigationItemProcessor"; }  set { }
        }

        public override List<string> Hidden
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public override string  ConstructorString()
        {
            string title = input.GetElementForKey("title").Value;
 	return String.Format("new {0}(){{ Title = {1}}}", Name, title);
}

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
                
              if (item.Value == "class")
              {
                  output["Class"] = item.Parent.GetElementForKey("class").Value;
              }
              else      if (item.Value == "title")
              {
                  output["Title"] = item.Parent.GetElementForKey("title").Value.QuotedAsCodeString();
              }
               else      if (item.Value == "prompt")
              {
                  output["Prompt"] = item.Parent.GetElementForKey("prompt").Value.QuotedAsCodeString();
              }

              else
              base.ProcessKey(item);
          }
        
        }
    }

