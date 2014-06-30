using System;
using System.Drawing;
using System.Text;

namespace Nib2CSharp.Core
{
	public static class StringExtensions
	{
		
	public static string	RectStringFromPoint(this String aString,string pointString, string sizeString)
{
			
 //   Point point = Point. NSPointFromString(pointString);
			System.ComponentModel.TypeConverter converter = 
        System.ComponentModel.TypeDescriptor.GetConverter(typeof(PointF));
            sizeString = sizeString.Replace("{", "");
            sizeString = sizeString.Replace("}", "");

            pointString = pointString.Replace("{", "");
            pointString = pointString.Replace("}", "");

            PointF point = new PointF(float.Parse(pointString.Split(',')[0]), float.Parse(pointString.Split(',')[1]));

            SizeF size = new SizeF(float.Parse(sizeString.Split(',')[0]), float.Parse(sizeString.Split(',')[1]));
   
		
  return  aString= String.Format("new RectangleF({0}, {1}, {2}, {3})", point.X, point.Y, size.Width, size.Height);
}

    public static string BooleanString(this String aString)
    {
        if(!String.IsNullOrEmpty(aString))
        return int.Parse(aString)==1 ?true.ToString().ToLower():false.ToString().ToLower();
        return false.ToString().ToLower();
    }
    public static string DateString(this String aString)
    {
        return aString;
    }
		
        

		public static string SizeString(this String aString)
{

    aString = aString.Replace("{", "");
    aString = aString.Replace("}", "");

    SizeF size = new SizeF(float.Parse(aString.Split(',')[0]), float.Parse(aString.Split(',')[1]));
    return String.Format("new SizeF ({0}, {1})", size.Width, size.Height);
}

        public static string RectString(this String aString)
        {

            aString = aString.Replace("{", "");
            aString = aString.Replace("}", "");
            PointF point = new PointF(float.Parse(aString.Split(',')[0]), float.Parse(aString.Split(',')[1]));
            SizeF size = new SizeF(float.Parse(aString.Split(',')[2]), float.Parse(aString.Split(',')[3]));
            return aString = String.Format("new RectangleF({0}, {1}, {2}, {3})", point.X, point.Y, size.Width, size.Height);
        }

        


        public static string BarStyleString(this String aString)
        {

          
            return aString;
        }

        public static string BorderStyleString(this String aString)
        {

          
            return aString;
        }

        

        
        public static string TextAlignmentString(this String aString)
        {

          
            return aString;
        }
public static string ColorString(this String aString)
{
    string color = "";
    if (aString.StartsWith("NSCalibratedRGBColorSpace "))
    {

      aString=  aString.Replace("NSCalibratedRGBColorSpace ", "");
        color = " UIColor.FromCalibratedRGBA(";
        foreach (var component in aString.Split())
        {
            color += component  + ", ";
        }

        color = color.Remove(color.LastIndexOf(", "));
        color += ")";


    }
    else if (aString.StartsWith("NSCustomColorSpace Generic Gray colorspace "))
    {
        aString = aString.Replace("NSCustomColorSpace Generic Gray colorspace ", "");
        color = " UIColor.FromCalibratedWhite(";
        foreach (var component in aString.Split())
        {
            color += component + ", ";
        }

        color = color.Remove(color.LastIndexOf(", "));
        color += ")";
    
    }
    else if (aString.StartsWith("NSCalibratedWhiteColorSpace "))
    {
        aString = aString.Replace("NSCalibratedWhiteColorSpace ", "");
        color = " UIColor.FromCalibratedWhite(";
        foreach (var component in aString.Split())
        {
            color += component + ", ";
        }

        color = color.Remove(color.LastIndexOf(", "));
        color += ")";
   
    }
    else if (aString.StartsWith("NSCustomColorSpace Generic CMYK colorspace "))
    {
        aString = aString.Replace("NSCustomColorSpace Generic CMYK colorspace ", "");
       
        color = "UIColor.FromColorSpace(UIColorSpace.UIColorSpace.Generic, ";
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
        color+= aString;
    }
    return color;
}

public static string QuotedAsCodeString(this String aString)
{
    return String.Format("\"{0}\"",aString);
}

public static string Capitalize(this String aString)
{
   
   return  aString.ToLower().Substring(0, 1).ToUpper() + aString.Substring(1);
}

		
		/// <summary>
/// Remove illegal XML characters from a string.
/// </summary>
public static string SanitizeXmlString(this string xml)
{
	if (xml == null)
	{
		throw new ArgumentNullException("xml");
	}

	StringBuilder buffer = new StringBuilder(xml.Length);

	foreach (char c in xml)
	{
		if (IsLegalXmlChar(c))
		{
			buffer.Append(c);
		}
	}

	return buffer.ToString();
}

/// <summary>
/// Whether a given character is allowed by XML 1.0.
/// </summary>
public static bool IsLegalXmlChar(int character)
{
	return
	(
		 character == 0x9 /* == '\t' == 9   */          ||
		 character == 0xA /* == '\n' == 10  */          ||
		 character == 0xD /* == '\r' == 13  */          ||
		(character >= 0x20    && character <= 0xD7FF  ) ||
		(character >= 0xE000  && character <= 0xFFFD  ) ||
		(character >= 0x10000 && character <= 0x10FFFF)
	);
}

/// <summary>
/// Returns a string with backslashes before characters that need to be quoted
/// </summary>
/// <param name="InputTxt">Text string need to be escape with slashes</param>
public static string AddSlashes(this string InputTxt)
{
    // List of characters handled:
    // \000 null
    // \010 backspace
    // \011 horizontal tab
    // \012 new line
    // \015 carriage return
    // \032 substitute
    // \042 double quote
    // \047 single quote
    // \134 backslash
    // \140 grave accent

    string Result = InputTxt;

    try
    {
        Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"[\000\010\011\012\015\032\042\047\134\140]", "\\$0");
    }
    catch (Exception Ex)
    {
        // handle any exception here
        Console.WriteLine(Ex.Message);
    }

    return Result;
}

/// <summary>
/// Un-quotes a quoted string
/// </summary>
/// <param name="InputTxt">Text string need to be escape with slashes</param>
public static string StripSlashes(this string InputTxt)
{
    // List of characters handled:
    // \000 null
    // \010 backspace
    // \011 horizontal tab
    // \012 new line
    // \015 carriage return
    // \032 substitute
    // \042 double quote
    // \047 single quote
    // \134 backslash
    // \140 grave accent

    string Result = InputTxt;

    try
    {
        Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");
    }
    catch (Exception Ex)
    {
        // handle any exception here
        Console.WriteLine(Ex.Message);
    }

    return Result;
}
	}
}

