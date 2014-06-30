using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UITabBarItemProcessor : UIBarItemProcessor
    {
          public override string Name
          {
              get
              {
                  return "UITabBarItem";
              }
              set { ; }
          }

          public override string Handles
          {
              get
              {
                  return "IBUITabBarItem";
              }
              set
              {
                
                  ;
              }
          }


          public override string ConstructorString()
          {
              string systemItemIdentifier = input.GetElementForKey("systemItemIdentifier").Value;
              string constructor = "";
              if(systemItemIdentifier=="-1")
              {
                  string title = input.GetElementForKey("title").Value.QuotedAsCodeString();
                  string tag = input.GetElementForKey("style").Value;
                  constructor = String.Format("new {0}(){{ Title = {1}, Tag = {2} }}", Name, title, tag);
              }
              else
              {
                  string tag = input.GetElementForKey("style").Value;
                  constructor = String.Format("new {0}(){{ TabBarButtonSystemItem = {1}, Tag = {2} }}", Name, systemItemIdentifier,tag);
              }

              return constructor;
          }


          public override void ProcessKey(System.Xml.Linq.XElement item)
          {
              if (item.Value == "badgeValue")
              {
                  output["badgeValue"] = item.Parent.GetElementForKey("badgeValue").Value.QuotedAsCodeString();
              }
            
              else
              base.ProcessKey(item);
          }
    }
}
