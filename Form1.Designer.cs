using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyNotepad
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            this.Load += Empty_File_Load;

            this.FormClosing += Ask_Save;

            this.SizeChanged += ChangeSize;

            menu = new MenuStrip();
            ToolStripMenuItem fileItem = new ToolStripMenuItem();
            fileItem.ShowShortcutKeys = true;
            fileItem.Text = "File";
            fileItem.DropDownItems.Add(new ToolStripMenuItem("New", null, new EventHandler((s, e) => box.Text = "")) { ShortcutKeys = Keys.Control | Keys.N });
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Open", null, OpenBtn_Click) { ShortcutKeys = Keys.Control | Keys.O });
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Save", null, Ask_Save) { ShortcutKeys = Keys.Control | Keys.S });
            fileItem.DropDownItems.Add(new ToolStripSeparator());
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Exit", null, new EventHandler((s, e) => this.Close())));

            menu.Items.Add(fileItem);

            ToolStripMenuItem windowItem = new ToolStripMenuItem();
            windowItem.ShowShortcutKeys = true;
            windowItem.Text = "Window";
            windowItem.DropDownItems.Add(new ToolStripMenuItem("Window Color", null, WindowColorBtn_Click) { ShortcutKeys = Keys.Control | Keys.C | Keys.O });
            windowItem.DropDownItems.Add(new ToolStripMenuItem("Text Color", null, TextColorBtn_Click) { ShortcutKeys = Keys.Control | Keys.C | Keys.O });
            menu.Items.Add(windowItem);

            ToolStripComboBox fontSize = new ToolStripComboBox();
            fontSize.Items.Add("Small");
            fontSize.Items.Add("Medium");
            fontSize.Items.Add("Large");
            fontSize.SelectedIndex = 0;
            fontSize.SelectedIndexChanged += FontSize_SelectedIndexChanged;

            menu.Items.Add(fontSize);


            this.Controls.Add(menu);
            
        }

        

        MenuStrip menu;

        CheckBox nightTheme;
        #endregion
    }
}

