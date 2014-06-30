using System;
using System.Linq;
using System.Xml.Linq;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    public  static class XElementExtensions
    {

        public static XElement GetElementForKey(this XElement  dict, string key)
        {
              if (dict.Elements("key").Any(o => o.Value == key))
            {
                XElement nextItem =
                    dict.Elements("key").Where(o => o.Value == key).FirstOrDefault().ElementsAfterSelf().FirstOrDefault();
                if (nextItem != null)
                    return nextItem;
            }

            return new XElement(key,"");
        }


        public static string FontString(this XElement aFont)
        {
           string name= aFont.GetElementForKey("Name").Value;
           string size = aFont.GetElementForKey("Size").Value;


            return String.Format("NSFont.FontFromName({0},{1})",name.QuotedAsCodeString(),size);
        }

    }
}
