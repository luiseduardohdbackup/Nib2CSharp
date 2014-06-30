using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIImageViewProcessor : UIViewProcessor
    {
          public override string Name
          {
              get
              {
                  return "UIImageView";
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


     

          public override void ProcessKey(System.Xml.Linq.XElement item)
          {
              if (item.Value == "image")
              {
                  output["image"] = item.Parent.GetElementForKey("image").Value;
              }
            
              else if (item.Value == "highlighted")
              {
                  output["highlighted"] = item.Parent.GetElementForKey("highlighted").Value.BooleanString();
              }
           

              else
              base.ProcessKey(item);
          }
    }
}
