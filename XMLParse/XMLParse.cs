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

            /* auto load */
            //cboType.SelectedItem = "Spells";
            //txtIn.Text = "C:\\Compendiums\\Spells Compendium 1.1.xml";
            
            //cboType.SelectedItem = "Items";
            //txtIn.Text = "C:\\Compendiums\\Items Compendium 1.1.1.xml";

            //cboType.SelectedItem = "Characters";
            //txtIn.Text = "C:\\Compendiums\\Character Compendium 1.2.xml";

            //cboType.SelectedItem = "Monsters";
            //txtIn.Text = "C:\\Compendiums\\Bestiary Compendium 1.1.1.xml";

            //cboType.SelectedItem = "Races";
            //txtIn.Text = "C:\\Character Files\\Races 1.6.xml";

            //cboType.SelectedItem = "Feats";
            //txtIn.Text = "C:\\Character Files\\Feats 1.4.xml";

            //cboType.SelectedItem = "Backgrounds";
            //txtIn.Text = "C:\\Character Files\\Backgrounds 1.4.xml";

            //cboType.SelectedItem = "Classes";
            //txtIn.Text = "C:\\Character Files\\Classes 2.4.xml";

            //txtOut.Text = "C:\\output.txt";
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
                sf.FileName = "output.txt";
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
                sf.Title = "Save Data To...";                
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    txtIn.Text = sf.FileName;
                }            
                
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtOut.Text;

                encyclopedia xml = new encyclopedia(Filename: txtIn.Text, FileType: cboType.SelectedItem.ToString());

                if (!File.Exists(path))
                {
                    //File.Create(path);
                    TextWriter tw = new StreamWriter(path);
                    string result = xml.getInserts();
                    txtResults.Text = result;
                    tw.WriteLine(result);
                    tw.Close();
                }
                else if (File.Exists(path))
                {
                    TextWriter tw = new StreamWriter(path);
                    string result = xml.getInserts();
                    txtResults.Text = result;
                    tw.WriteLine(result);
                    tw.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
