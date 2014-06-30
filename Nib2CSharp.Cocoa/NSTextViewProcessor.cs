using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
	[Export("ClassProcessor", typeof(IClassProcessor))]
	public class NSTextViewProcessor : IClassProcessor
	{
	    public override Dictionary<string, ProcessedObject> ObjectProcessors
	    {
	        get { throw new NotImplementedException(); }
	        set { throw new NotImplementedException(); }
	    }

	    public override string Name
	{
	    get { return "NSTextView"; }
	    set { ; }
	}

	    public override string Handles
	    {
            get {return "NSTextView"; }
	        set{}
	    }

	    public override List<string> Hidden
	    {
	        get { throw new NotImplementedException(); }
	        set { throw new NotImplementedException(); }
	    }
	}
}

