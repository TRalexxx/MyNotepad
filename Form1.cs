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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

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
            box = new TextBox();
            box.BorderStyle = BorderStyle.None;
            box.Size = new Size(this.Width, this.Height-25);
            box.Location = new Point(0, 25);
            box.Multiline = true;
            box.Font = new Font("Times New Roman", 13, FontStyle.Regular);

            this.Controls.Add(box);
        }

        public void Ask_Save(object sender, EventArgs e)
        {
            if (box.Text != "")
            {
                if (MessageBox.Show("Do you whant to save file?", "Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            myStream.Close();
                            File.WriteAllText(saveFileDialog.FileName, this.Controls[0].Text);
                        }
                    }
                }
            }

        }

        private void OpenBtn_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "text|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                box.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void ChangeSize(object sender, EventArgs e)
        {
            box.Height = this.Height;
            box.Width = this.Width;
        }

        private void WindowColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                menu.BackColor = dialog.Color;
                box.BackColor = dialog.Color;
            }
        }

        private void TextColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                menu.ForeColor = dialog.Color;
                box.ForeColor = dialog.Color;
            }
        }

        private void FontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ToolStripComboBox).SelectedIndex == 0)
            {
                box.Font = new Font("Times New Roman", 10);
            }
            else if ((sender as ToolStripComboBox).SelectedIndex == 1)
            {
                box.Font = new Font("Times New Roman", 15);
            }
            else if ((sender as ToolStripComboBox).SelectedIndex == 2)
            {
                box.Font = new Font("Times New Roman", 20);
            }
        }

        TextBox box;
    }
}
