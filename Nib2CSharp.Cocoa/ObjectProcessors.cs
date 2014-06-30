using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class ContentRectProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "ContentRect"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string oString = item.Parent.GetElementForKey("contentRectOrigin").Value;
            oString += " , " + item.Parent.GetElementForKey("contentRectSize").Value;

            oString = oString.Replace("{", "");
            oString = oString.Replace("}", "");

            if (!String.IsNullOrEmpty(oString))
            {
                PointF point = new PointF(float.Parse(oString.Split(',')[0]), float.Parse(oString.Split(',')[1]));
                SizeF size = new SizeF(float.Parse(oString.Split(',')[2]), float.Parse(oString.Split(',')[3]));
                return

                    String.Format("new RectangleF({0}f, {1}f, {2}f, {3}f)", point.X, point.Y, size.Width, size.Height);
            }
            return "";
        }
    }


    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class BackingStoreProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "BackingStore"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string oString = item.Parent.GetElementForKey(item.Value).Value;

            return String.Format("(NSBackingStore) {0}", int.Parse(oString));
        }
    }



    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class WindowStyleProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "WindowStyle"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string oString = item.Parent.GetElementForKey(item.Value).Value;

            return String.Format("(NSWindowStyle) {0}", int.Parse(oString));
        }
    }
    
    

     [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class FontStringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Font"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string name;
            string size;

          var font = item.Parent.GetElementForKey(item.Value);


          if (font.Name == "dict")
            {
                name = font.GetElementForKey("Name").Value;
                size = font.GetElementForKey("Size").Value;
                return String.Format("NSFont.FromFontName({0},{1})", name.QuotedAsCodeString(), size);
            }
            return "";
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class RectStringFromPointProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "RectStringFromPoint"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { return ""; }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
       string aString = item.Parent.GetElementForKey(item.Value).Value;

            if (!String.IsNullOrEmpty(aString))
                return int.Parse(aString) == 1 ? true.ToString().ToLower() : false.ToString().ToLower();

          
            return false.ToString().ToLower();
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class BooleanProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Bool"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            if (!String.IsNullOrEmpty(aString))
                return int.Parse(aString) == 1 ? true.ToString().ToLower() : false.ToString().ToLower();
            return false.ToString().ToLower();
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class EnumProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Enum"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            if (!String.IsNullOrEmpty(aString))
            {
                return String.Format("({0})({1})", options, aString);
            }
            return "";
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class ObjectProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Object"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            if (!String.IsNullOrEmpty(aString))
            {
                return String.Format("new {0}({1})", options, aString.QuotedAsCodeString());
            }
            return "";
        }
    }


    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class SizeStringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Size"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            aString = aString.Replace("{", "");
            aString = aString.Replace("}", "");

            SizeF size = new SizeF(float.Parse(aString.Split(',')[0]), float.Parse(aString.Split(',')[1]));
            return String.Format("new SizeF ({0}f, {1}f)", size.Width, size.Height);
        }
    }


    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class RectStringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Rect"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            aString = aString.Replace("{", "");
            aString = aString.Replace("}", "");
            PointF point = new PointF(float.Parse(aString.Split(',')[0]), float.Parse(aString.Split(',')[1]));
            SizeF size = new SizeF(float.Parse(aString.Split(',')[2]), float.Parse(aString.Split(',')[3]));
            return aString = String.Format("new RectangleF({0}f, {1}f, {2}f, {3}f)", point.X, point.Y, size.Width, size.Height);
        }
    }


    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class ColorStringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Color"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            string color = "";
            if (aString.StartsWith("NSCalibratedRGBColorSpace "))
            {

                aString = aString.Replace("NSCalibratedRGBColorSpace ", "");
                color = " NSColor.FromCalibratedRgba(";
                foreach (var component in aString.Split())
                {
                    color += component + "f, ";
                }

                color = color.Remove(color.LastIndexOf(", "));
                color += ")";


            }
            else if (aString.StartsWith("NSCustomColorSpace Generic Gray colorspace "))
            {
                aString = aString.Replace("NSCustomColorSpace Generic Gray colorspace ", "");
                color = " NSColor.FromCalibratedWhite(";
                foreach (var component in aString.Split())
                {
                    color += component + "f, ";
                }

                color = color.Remove(color.LastIndexOf(", "));
                color += ")";

            }
            else if (aString.StartsWith("NSCalibratedWhiteColorSpace "))
            {
                aString = aString.Replace("NSCalibratedWhiteColorSpace ", "");
                color = " NSColor.FromCalibratedWhite(";
                foreach (var component in aString.Split())
                {
                    color += component + "f, ";
                }

                color = color.Remove(color.LastIndexOf(", "));
                color += ")";

            }

            else if (aString.StartsWith("NSDeviceWhiteColorSpace "))
            {
                aString = aString.Replace("NSDeviceWhiteColorSpace ", "");
                color = " NSColor.FromDeviceWhite(";
                foreach (var component in aString.Split())
                {
                    color += component + "f, ";
                }

                color = color.Remove(color.LastIndexOf(", "));
                color += ")";

            }
            else if (aString.StartsWith("NSNamedColorSpace System "))
            {
                aString = aString.Replace("NSNamedColorSpace System ", "");
               
            aString=    aString.Replace("Color", "");

               

                color = " NSColor.";

                color += aString.Capitalize();
              
               

            }
            else if (aString.StartsWith("NSCustomColorSpace Generic CMYK colorspace "))
            {
                aString = aString.Replace("NSCustomColorSpace Generic CMYK colorspace ", "");

                color = "NSColor.FromColorSpace(UIColorSpace.UIColorSpace.Generic, ";
                foreach (var component in aString.Split())
                {
                    color += component + ", ";
                }

                color = color.Remove(color.LastIndexOf(", "));
                color += ")";
                // sscanf([aString UTF8String], "NSCustomColorSpace Generic CMYK colorspace %f %f %f %f %f", &cyan, &magenta, &yellow, &black, &alpha);
                // There is no method in UIColor for CMYK colors...
                //  [color appendFormat:@"[UIColor colorWithCGColor:CGColorCreate(kCGColorSpaceGenericCMYK, {%1.3f, %1.3f, %1.3f, %1.3f, %1.3f})]", cyan, magenta, yellow, black, alpha];
            }
            else
            {
                color += aString;
            }
            return color;
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class FloatStringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Float"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;
           

            return float.Parse(aString) + "f";
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class IntegerStringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "Integer"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;


            return int.Parse(aString).ToString();
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class StringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "String"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            return (String.Format("\"{0}\"", aString.AddSlashes()));
        }
    }

    [Export("ObjectProcessor", typeof(IObjectProcessor))]
    public class QuotedAsCodeStringProcessor : IObjectProcessor
    {
        public override string Name
        {
            get { return "quoted"; }
            set { ; }
        }

        public override string ProcessedName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string Style
        {
            get { return "MonoMac"; }
            set { ; }
        }

        public override string ProcessObject(System.Xml.Linq.XElement item, object options)
        {
            string aString = item.Parent.GetElementForKey(item.Value).Value;

            return String.Format("\"{0}\"", aString);
        }


    }
}
