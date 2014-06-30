using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIBarButtonItemProcessor : UIBarItemProcessor
    {
          public override string Name
          {
              get
              {
                  return "UIBarButtonItem";
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
                  return "IBUIBarButtonItem";
              }
              set
              {
                  base.Handles = value;
              }
          }


          public override string ConstructorString()
          {
              string systemItemIdentifier = input.GetElementForKey("systemItemIdentifier").Value;
              string constructor = "";
              if(systemItemIdentifier=="-1")
              {
                  string title = input.GetElementForKey("title").Value.QuotedAsCodeString();
                  string style = input.GetElementForKey("style").Value;
                  constructor = String.Format("new {0}(){{ Title = {1}, Style = {2} }}", Name, title, style);
              }
              else
              {
                 
                  constructor = String.Format("new {0}(){{ BarButtonSystemItem = {1} }}", Name, systemItemIdentifier);
              }

              return constructor;
          }


          public override void ProcessKey(System.Xml.Linq.XElement item)
          {
              if (item.Value == "style")
              {
                  output["style"] = item.Parent.GetElementForKey("style").Value;
              }
              else if (item.Value == "width")
              {
                  output["width"] = item.Parent.GetElementForKey("width").Value;
              }
              else
              base.ProcessKey(item);
          }
    }
}
