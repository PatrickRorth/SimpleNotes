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

namespace SimpleNotes
{
    public partial class Form1 : Form
    {

        string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "SimpleNotes" + ".txt";        


        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(28, 33, 46);
            richTextBox1.BackColor = Color.FromArgb(33, 40, 54);
            richTextBox1.ForeColor = Color.White;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
               richTextBox1.LoadFile(path, RichTextBoxStreamType.RichText);
            }
            else
            {
                richTextBox1.Text = "Features: \n\nCTRL + B = Bold text\nCTRL + S = Save content";
            }
            
        }

        public void saveFile()
        {

        }

        void KeyPressed (Object sender, KeyEventArgs e)
        {
            //IF CTRL + B IS PRESSED - MAKE SELECTE TEXT BOLD
            if (e.Control && e.KeyCode == Keys.B)
            {
                if (richTextBox1.SelectionFont != null)
                {
                    System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    if (richTextBox1.SelectionFont.Bold == true)
                    {
                        newFontStyle = FontStyle.Regular;
                    }
                    else
                    {
                        newFontStyle = FontStyle.Bold;
                    }

                    richTextBox1.SelectionFont = new Font(
                       currentFont.FontFamily,
                       currentFont.Size,
                       newFontStyle
                    );
                }
            }


            if (e.Control && e.KeyCode == Keys.S)
            {
                if (richTextBox1.Text != String.Empty)
                {

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    
                    if (!File.Exists(path))
                    {
                        richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);

                    }
                    else
                    {
                        richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);
                    }
                    
                    

                }
                else
                {
                    MessageBox.Show("ERROR - Try Again");
                }
            }


                /*
                //IF CTRL + I IS PRESSED - MAKE SELECTE TEXT ITALIC
                if (e.Control && e.KeyCode == Keys.I)
                {
                    if (richTextBox1.SelectionFont != null)
                    {
                        System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                        System.Drawing.FontStyle newFontStyle;

                        if (richTextBox1.SelectionFont.Italic == true)
                        {
                            newFontStyle = FontStyle.Regular;
                        }
                        else
                        {
                            newFontStyle = FontStyle.Italic;
                        }

                        richTextBox1.SelectionFont = new Font(
                           currentFont.FontFamily,
                           currentFont.Size,
                           newFontStyle
                        );
                    }
                }

            
                //IF CTRL + U IS PRESSED - MAKE SELECTE TEXT UNDERLINE
                if (e.Control && e.KeyCode == Keys.U)
                {
                    if (richTextBox1.SelectionFont != null)
                    {
                        System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                        System.Drawing.FontStyle newFontStyle;

                        if (richTextBox1.SelectionFont.Underline == true)
                        {
                            newFontStyle = FontStyle.Regular;
                        }
                        else
                        {
                            newFontStyle = FontStyle.Underline;
                        }

                        richTextBox1.SelectionFont = new Font(
                           currentFont.FontFamily,
                           currentFont.Size,
                           newFontStyle
                        );
                    }
                }
                */
            }
    }
}
