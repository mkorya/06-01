// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Security.Cryptography;
using System.Text;

using System.Reflection;

using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;


namespace WindowsFormsApp29
{
   
    public partial class Form1 : Form
    {
        string tex = " ";
        string te = " ";
        string te1= " ";
        sha1 sh;
        combined co;
        public Form1()
        {
            InitializeComponent();
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
            string pa = textBox2.Text;
            // te1= textBox3.Text;
            sh = new sha1(te,pa);
            label1.Text += sh.Encrypt();
            
             co=new combined(te1,pa);
            label3.Text += co.doEncrypt();
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы MS Word |*.docx",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Word.Application();
                Object fileName = dialog.FileName;
                string file = dialog.FileName.ToString();
                Word.Document doc = app.Documents.Open(file);
                //Word.Document doc = app.ActiveDocument;
                // Нумерация параграфов начинается с одного
                tex = doc.Content.Text;
                //for (int i = 0; i < doc.Words.Count; i++)
                {
                    //te= doc.Words[i].Text;

                }
                app.Quit();
            }
            
            char[] separators = new char[] { '\n','\r' };

            string[] subs = tex.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int k = 0;
            foreach (string sub in subs)
            {if (k==0)
               te = sub;
            else if (k==1) te1= sub;
            k++;
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            label2.Text += sh.Decrypt();
            label4.Text += co.doDecrypt();
            label5.Text += co.doDecrypt2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы MS Word |*.docx",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Word.Application();
                Object fileName = dialog.FileName;
                string file = dialog.FileName.ToString();
                Word.Document doc = app.Documents.Open(file);
                
                doc.Content.Text=te+'\n'+'\r'+te1;
                
                app.Quit();
            }
        }
    }
}
