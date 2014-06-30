using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Nib2CSharp.Core;

namespace Nib2CSharp.GUI
{
    class Runner
    {
        [ImportMany("NIBProcessor", typeof(INIBProcessor))]
        IEnumerable<INIBProcessor> NIBProcessors { get; set; }

        private  void Compose()
        {
            var catalog = new DirectoryCatalog( @"Plug-ins");//Path.GetDirectoryName(
    //  Assembly.GetExecutingAssembly().GetName().CodeBase) +
   
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public List<string> AvailableProcessors
        {
            get { return NIBProcessors.Select(o=>o.Name).ToList(); }
        }
        
        public Runner()
        {
             Compose();
        }

        public string Run(string filePath, string processorName="Cocoa")
        {
           

            INIBProcessor processor = NIBProcessors.Where(m => m.Name == processorName).FirstOrDefault();
          
            if(processor!=null)
            {
                return processor.Run(filePath);
            }

            return "Failed To Run";
        }
    }
}
