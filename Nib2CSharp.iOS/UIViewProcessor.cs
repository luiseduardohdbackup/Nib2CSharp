using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
       [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIViewProcessor : IClassProcessor
    {
           public override Dictionary<string, ProcessedObject> ObjectProcessors
           {
               get { throw new NotImplementedException(); }
               set { throw new NotImplementedException(); }
           }

           public override string Name { get { return "UIView"; } set { }
        }
        public override string Handles { get { return "IBUIView"; } set { }
        }

           public override List<string> Hidden
           {
               get { throw new NotImplementedException(); }
               set { throw new NotImplementedException(); }
           }

           public override void ProcessKey(System.Xml.Linq.XElement item)
        {
                if (item.Value == "autoresizesSubviews")
            {
                output["AutoResizeSubviews"] = item.Parent.GetElementForKey("autoresizesSubviews").Value.BooleanString();
            }


           


                    
           else     if (item.Value == "contentStretch")
            {
                output["ContentStretch"] = item.Parent.GetElementForKey("contentStretch").Value.RectString();
            }

           else             if (item.Value == "alpha")
            {
                output["Alpha"] = item.Parent.GetElementForKey("alpha").Value;
            }

            else                               if (item.Value == "hidden")
            {
                output["Hidden"] = item.Parent.GetElementForKey("hidden").Value.BooleanString();
            }

       else  if (item.Value == "opaqueForDevice")
            {
                output["Opaque"] = item.Parent.GetElementForKey("opaqueForDevice").Value.BooleanString();
            }
else
              if (item.Value == "clipsSubviews")
            {
                output["ClipsToBounds"] = item.Parent.GetElementForKey("clipsSubviews").Value.BooleanString();
            }

         else           if (item.Value == "clearsContextBeforeDrawing")
            {
                output["ClearsContextBeforeDrawing"] = item.Parent.GetElementForKey("clearsContextBeforeDrawing").Value.BooleanString();
            }

      else                    if (item.Value == "userInteractionEnabled")
            {
                output["UserInteractionEnabled"] = item.Parent.GetElementForKey("userInteractionEnabled").Value.BooleanString();
            }
else
                                if (item.Value == "multipleTouchEnabled")
            {
                output["MultipleTouchEnabled"] = item.Parent.GetElementForKey("multipleTouchEnabled").Value.BooleanString();
            }
   
  else                    if (item.Value == "tag")
            {
                output["Tag"] = item.Parent.GetElementForKey("tag").Value;
            }

     else                               if (item.Value == "backgroundColor")
            {
                output["BackgroundColor"] = item.Parent.GetElementForKey("backgroundColor").Value;
            }
   else
                                                                if (item.Value == "contentMode")
            {
                output["ContentMode"] = item.Parent.GetElementForKey("contentMode").Value;
            }
  
                                                                      else
                                                                if (item.Value == "autoresizingMask")
            {
                output["AutoresizingMask"] = item.Parent.GetElementForKey("autoresizingMask").Value;
            }


                                                                else
                                                                {
                                                                     base.ProcessKey(item);
                                                                }

           
        }

    }
}
