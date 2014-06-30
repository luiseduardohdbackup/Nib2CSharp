using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Nib2CSharp.Core;

namespace Nib2CSharp.Cocoa
{
    [Export("ClassProcessor", typeof(IClassProcessor))]
    class NSOpenGlViewProcessor : NSViewProcessor
    {
        public override string Name { get { return "NSOpenGLView"; } set { } }
        public override string Handles
        {
            get { return "NSOpenGLView"; }
            set { }


        }

      
        public new List<string> Hidden
        {
            get { return new List<string>() {}; }
            set { ; }

        }

        public new Dictionary<string, ProcessedObject> ObjectProcessors
        {
            get
            {
                var objectProcessors = new Dictionary<string, ProcessedObject>()
                                           {
                                           
                                           
                                              
                                                        
                                                          {"pixelFormat.attributes", (new ProcessedObject() {Processor = "PixelFormat", OutputName=" PixelFormat.Attributes" })},    
                                               
                                                    
                                           };



                return objectProcessors;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void ProcessKey(System.Xml.Linq.XElement item)
        {

            if (ObjectProcessors.ContainsKey(item.Value))
            {
                var objectProcessor = ObjectProcessors[item.Value];
                var processedObject = MainNIBProcessor.processObject(item, objectProcessor.Processor,objectProcessor.Options);
                if (!String.IsNullOrEmpty(processedObject))
                    output[objectProcessor.OutputName] = processedObject;// + "// " + "NSView";
                else
                {
                    Console.WriteLine(@"Skipped: " + item.Value + @" No Data To Process");
                }
            }
            else if (!Hidden.Contains(item.Value))
            {
                base.ProcessKey(item);
            }

            output["__Helper__Class__"] = Name;
        }
        

    }
}
