using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
      [Export("ClassProcessor", typeof(IClassProcessor))]
    class MKMapViewProcessor:NSViewProcessor
    {

        public override string Name
        {
            get
            {
                return "MKMapView";
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
                return "IBMKMapView";
            }
            set
            {
                base.Handles = value;
            }
        }
        public override void ProcessKey(System.Xml.Linq.XElement item)
        {
            if (item.Value == "showsUserLocation")
            {
                output["ShowsUserLocation"] = item.Parent.GetElementForKey("showsUserLocation").Value.BooleanString();
            }
            else if (item.Value == "mapType")
            {
                output["MapType"] = item.Parent.GetElementForKey("mapType").Value.BooleanString();
            }
            else if (item.Value == "scrollEnabled")
            {
                output["ScrollEnabled"] = item.Parent.GetElementForKey("scrollEnabled").Value.BooleanString();
            }
            else if (item.Value == "zoomEnabled")
            {
                output["ZoomEnabled"] = item.Parent.GetElementForKey("zoomEnabled").Value.BooleanString();
            }
                
            else
                base.ProcessKey(item);
        }
    }
}
