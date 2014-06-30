using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class NsImageViewProcessor : NSViewProcessor
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
