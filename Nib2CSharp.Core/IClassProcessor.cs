using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;


namespace Nib2CSharp.Core
{
    
 public delegate string ObjectProcessor(XElement dict, string item);

	public abstract class IClassProcessor
	{

        [Import("NIBProcessor", typeof(INIBProcessor))]
       public INIBProcessor MainNIBProcessor { get; set; }

        public virtual Dictionary<string, ProcessedObject> ObjectProcessors { get; set; }


		[ImportMany(typeof(IObjectProcessor))]
		IEnumerable<IObjectProcessor> Objects { get; set; }




        public virtual string Name { get; set; }


	    public virtual Dictionary<string,string> ProcessObject (XElement anObject)
		{
			
 	input = anObject;
    output =new Dictionary<string,string>();
	
			foreach(var item in input.Elements("key").OrderByDescending(o=>o.Value))
			{
				ProcessKey(item);
			}

            output["__Helper__Class__"] = ClassString();

			output["__Helper__Constructor__"]= ConstructorString();
			
	        output["__Helper__Frame__"]= FrameString();

            output["__Helper__Name__"] = NameString();
			
			return output;
		}

	    protected XElement input { get; set; }

		public Dictionary<string, string> output { get; set; }
	    public virtual string Handles { get; set; }
        public virtual List<string> Hidden
        {
            get { return new List<string>() { "custom-class", "ibExternalCustomClassName", "ibExternalIdentityShowNotesWithSelection", 
                "ibExternalExplicitLabel", "ibExternalVisibleAtLaunch", "ibShadowedAutoPositionMask", "ibShadowedContentMinSize","ibShadowedBorderStyle",
                "ibShadowedButtonBehavior","ibShadowedButtonCellType","ibShadowedImage","ibShadowedImagePosition","ibShadowedInset","ibShadowedAutohidesScrollers",
                "custom-class","identifier", "class","ibShadowedToolTip","ibShadowedAlternateImage","ibShadowedEnabledStates","ibShadowedImages","ibShadowedImageScalings" 
            ,"ibShadowedLabels","ibShadowedNumberOfSegments","ibShadowedSelectedStates","ibShadowedTags","ibShadowedToolTips","ibShadowedWidths"
             };}
            set { ; }
        }

	    public virtual void ProcessKey(XElement item)
		{
			// Overridden in subclasses
            //           if (item.Value == "class")
            //{
            //    output["Class"] = item.Parent.GetElementForKey("class").Value;
            //}
            //           else

              if (!Hidden.Contains(item.Value))
            {
                  output[item.Value] = item.Parent.GetElementForKey(item.Value).Value;
            }

                
		//	ProcessDict (item);
		}


        public virtual string  AddChild(string parentName,string childname, string s=null)
        {
            // Overridden in subclasses
            //           if (item.Value == "class")
            //{
            //    output["Class"] = item.Parent.GetElementForKey("class").Value;
            //}
            //           else

            
            return String.Format("{0}.AddSubview({1})",parentName,childname);

            //	ProcessDict (item);
        }

        public string ClassString()
        {
            string classString = "";
            if (output.ContainsKey("__Helper__Class__"))
            {
                classString = output["__Helper__Class__"];
            }
            else
            {
                classString = input.GetElementForKey("class").Value;
            }
            

            return classString;
        }
        

		public string FrameString ()
		{
			string rect = null;

		    string frameOrigin = input.GetElementForKey("frameOrigin").Value;
		    string frameSize = input.GetElementForKey("frameSize").Value;


			if(!(String.IsNullOrEmpty(frameOrigin) || String.IsNullOrEmpty(frameOrigin)))
	rect =rect.RectStringFromPoint(frameOrigin, frameSize);
				
			return rect;
		}

        public string NameString()
        {
            string klass = output["__Helper__Class__"];
             klass = klass.ToLower().Substring(2);


            string identifier = input.GetElementForKey("identifier").Value;
            string explicitLabel = input.GetElementForKey("ibExternalExplicitLabel").Value;

            if (!String.IsNullOrEmpty(identifier))
            {
                klass =  identifier + klass;
              
            }

            if (!String.IsNullOrEmpty(explicitLabel))
            {
                klass = explicitLabel;
               
            }
            klass = klass.Replace(" ", "").Replace("-","");
         return  klass;
        }


	    public virtual string ConstructorString ()
		{
			// Some subclasses have different constructors than the classic
			// "initWithFrame:", and as such they should override this method.
            //if (frameString () != null)
            //    return String.Format (@"new {0}(){{ Frame= {1} }}", Name, frameString ());
            //else
            return String.Format(@"new {0}()", output["__Helper__Class__"]);
		}

		void ProcessDict (XElement dict2)
		{
			foreach (XElement element2 in dict2.Elements ("key")) 
			{
				var Value = element2.ElementsAfterSelf ().FirstOrDefault ();
				if (Value.Name == "dict")
				{
					ProcessDict (Value);
				} else

				{
				    output[element2.Value] = Value.Value;
				}
				
			}
		}
	}
	
	
}
