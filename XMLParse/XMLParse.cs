using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcReactor;
using System.IO;
using System.IO.Compression;

namespace XMLParse
{
    public partial class XMLParse : Form
    {
        public XMLParse()
        {
            InitializeComponent();
        }

        // Save location set up 
        private void btnOut_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.DefaultExt = "txt";
                sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
                sf.Filter = "Text File (*.txt) | *.txt";
                sf.Title = "Save Data To...";
                sf.FileName = "Output.txt";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    txtOut.Text = sf.FileName;
                }
            }
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            using( OpenFileDialog sf = new OpenFileDialog() )
            {
                sf.DefaultExt = "txt";
                sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
                //sf.Filter = "Text File (*.txt) | *.txt"; -- not needed 
                sf.Title = "Save Data To...";
                sf.FileName = "Output.txt";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    txtIn.Text = sf.FileName;
                }            
                
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string path = txtOut.Text;

            encyclopedia xml = new encyclopedia(Filename: txtIn.Text, FileType: cboType.SelectedItem.ToString()); 

            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(xml.getInserts());
                tw.Close();
            }
            else if (File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(xml.getInserts());
                tw.Close();
            }
        }

    

    }
}
