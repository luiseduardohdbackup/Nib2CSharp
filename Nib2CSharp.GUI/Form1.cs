using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nib2CSharp.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (var processor in runner.AvailableProcessors)
            {
                listBox1.Items.Add(processor);
            }

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_Completed;

            

        }

        BackgroundWorker backgroundWorker = new BackgroundWorker();

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalSteps = 10;

            for (int i = 1; i <= totalSteps; i++)
            {
                //  One chunk of your code

                int progress = i * 100 / totalSteps;
                backgroundWorker.ReportProgress(progress);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            blocksProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            blocksProgressBar.Value = 0;
        }

        private string filePath = "";

        Runner runner = new Runner();

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(filePath))
                txtOutput.Text = (new Runner().Run(filePath)).Replace("\n", Environment.NewLine);
            else
            {
                MessageBox.Show("No Input file chosen",
                                         "Important Message");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create and show an open file dialog
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Plist|*.plist|Xcode Nib File|*.nib|Xcode Xib File|*.xib";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {

                if (Path.GetExtension(dlgOpen.FileName) != ".plist")
                {
                    if (!File.Exists("/usr/bin/ibtool"))
                    {
                        MessageBox.Show("Sorry ibtool is not installed (Are you on windows?)",
                                        "Important Message");
                        return;
                    }
                }

                filePath = dlgOpen.FileName;
                Console.Write(dlgOpen.FileName);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "C# Source Code|*.cs";
            saveFileDialog1.Title = "Save Source Code File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                TextWriter fs = new StreamWriter(saveFileDialog1.OpenFile());

              

                // write a line of text to the file
              fs.Write(txtOutput.Text);

                // close the stream
            

                fs.Close();
            }
        }

       
    }
}
