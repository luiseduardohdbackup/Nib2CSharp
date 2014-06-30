using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.iOS
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class UIScrollViewProcessor : UIViewProcessor
    
    {
        public override string Name
        {
            get
            {
                return "UIScrollView";
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
            if (item.Value == "indicatorStyle")
            {
                output["indicatorStyle"] = item.Parent.GetElementForKey("indicatorStyle").Value;
            }
            else if (item.Value == "scrollEnabled")
            {
                output["scrollEnabled"] = item.Parent.GetElementForKey("scrollEnabled").Value.BooleanString();
            }
            else if (item.Value == "pagingEnabled")
            {
                output["pagingEnabled"] = item.Parent.GetElementForKey("pagingEnabled").Value.BooleanString();
            }
            else if (item.Value == "directionalLockEnabled")
            {
                output["directionalLockEnabled"] = item.Parent.GetElementForKey("directionalLockEnabled").Value.BooleanString();
            }
            else if (item.Value == "bounces")
            {
                output["bounces"] = item.Parent.GetElementForKey("bounces").Value.BooleanString();
            }
            else if (item.Value == "alwaysBounceHorizontal")
            {
                output["alwaysBounceHorizontal"] = item.Parent.GetElementForKey("alwaysBounceHorizontal").Value.BooleanString();
            }
            else if (item.Value == "alwaysBounceVertical")
            {
                output["alwaysBounceVertical"] = item.Parent.GetElementForKey("alwaysBounceVertical").Value.BooleanString();
            }
            else if (item.Value == "maximumZoomScale")
            {
                output["maximumZoomScale"] = item.Parent.GetElementForKey("maximumZoomScale").Value.BooleanString();
            }
            else if (item.Value == "minimumZoomScale")
            {
                output["minimumZoomScale"] = item.Parent.GetElementForKey("minimumZoomScale").Value.BooleanString();
            }
            else if (item.Value == "bouncesZoom")
            {
                output["bouncesZoom"] = item.Parent.GetElementForKey("bouncesZoom").Value.BooleanString();
            }
            else if (item.Value == "delaysContentTouches")
            {
                output["delaysContentTouches"] = item.Parent.GetElementForKey("delaysContentTouches").Value.BooleanString();
            }
            else if (item.Value == "canCancelContentTouches")
            {
                output["canCancelContentTouches"] = item.Parent.GetElementForKey("canCancelContentTouches").Value.BooleanString();
            }
         
            else
                base.ProcessKey(item);
        }
    }
}
