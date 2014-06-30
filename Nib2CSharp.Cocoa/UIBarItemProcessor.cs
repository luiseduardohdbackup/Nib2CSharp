using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
       [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIBarItemProcessor : IClassProcessor
    {
           public override Dictionary<string, ProcessedObject> ObjectProcessors
           {
               get { throw new NotImplementedException(); }
               set { throw new NotImplementedException(); }
           }

           public override string Name
           {
               get { return "UIBarItem"; }
               set { }
        }
           public override string Handles
           {
               get { return "IBUIBarItem"; }
               set { }
        }

           public override List<string> Hidden
           {
               get { throw new NotImplementedException(); }
               set { throw new NotImplementedException(); }
           }

           public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "class")
            {
                output["Class"] = item.Parent.GetElementForKey("class").Value;
            }


  
            else if (item.Value == "tag")
            {
                output["tag"] = item.Parent.GetElementForKey("tag").Value;
            }

            else if (item.Value == "enabled")
            {
                output["enabled"] = item.Parent.GetElementForKey("enabled").Value.BooleanString();
            }

            else if (item.Value == "image")
            {
                output["image"] = item.Parent.GetElementForKey("image").Value.BooleanString();
            }
           


                                                                else
                                                                {
                                                                     base.ProcessKey(item);
                                                                }

           
        }

    }
}
