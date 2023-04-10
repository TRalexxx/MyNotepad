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

namespace MyNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Empty_File_Load(object sender, EventArgs e)
        {
            TextBox box = new TextBox();

            box.Size = new Size(1000, 1000);
            box.Multiline = true;
            box.Font = new Font("Times New Roman", 13, FontStyle.Regular);

            this.Controls.Add(box);
        }

        public void Ask_Save(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you whant to save file?", "Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Stream myStream;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        myStream.Close();
                        File.WriteAllText(saveFileDialog.FileName, this.Controls[0].Text);
                    }
                }
            }
            else if(MessageBox.Show("Do you whant to save file?", "Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {

            }
        }
    }
}
