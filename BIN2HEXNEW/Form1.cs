using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIN2HEXNEW
{
    public partial class Form1 : Form
    {
        String abc;
        String filename;
     

        public Form1()
        {
            InitializeComponent();
            this.TextBox2.Multiline = true;
            this.TextBox2.WordWrap = true;
            this.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }


   
        
     
      

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Bin File";
            theDialog.Filter = "BIN files|*.bin";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;
                TextBox1.Text = filename;

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBox1.Text)) 
            {
                String path = TextBox1.Text;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "bin_hex.cmd";
                startInfo.Arguments = "\"" + path + "\"";
                process.StartInfo = startInfo;
                process.Start();
                filename = path.Substring(0, path.LastIndexOf('.'));
                abc = filename + ".hex";
                if (File.Exists(abc))
                {
                    using (StreamReader sr = new StreamReader(abc))
                    {
                        String line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            TextBox2.AppendText(line + "\n");
                        }
                    }
                    File.Delete(abc);
                }
            }
            else
            {
                MessageBox.Show("Please select BIN file!");
            }
           

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Small Tech Pixel Software Soulution");

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBox2.Text))
            {
                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = Path.GetFileName(abc);
                // set filters - this can be done in properties as well
                savefile.Filter = "Hex files (*.hex)|*.hex";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName))
                        sw.WriteLine(TextBox2.Text);
                }
                MessageBox.Show("Hex Saved Successfully");
            }
            else 
            {
                MessageBox.Show("HEX not generated!");

            }
          


        }


    }
}
