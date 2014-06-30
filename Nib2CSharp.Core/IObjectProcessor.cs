using System;
using System.Xml.Linq;

namespace Nib2CSharp.Core
{
	public abstract class IObjectProcessor
	{
	

        public abstract string Name { get; set; }

        public abstract string ProcessedName { get; set; }

        public virtual string ProcessObject(XElement item, Object options = null)
        {
            return item.Parent.GetElementForKey(item.Value).Value;
        }
		public string ObjectTextRepresentation
		{
			get; set;
		}

	    public abstract string Style { get; set; }
	}
}

