using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void filesBnt_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStream;
            OpenFileDialog thisDialog = new OpenFileDialog();
            thisDialog.Multiselect = true;
            thisDialog.Filter = "tspXMLFile|*.xml";
            if (thisDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in thisDialog.FileNames)
                {
                    try
                    {
                        if ((myStream = thisDialog.OpenFile()) != null)
                        {
                            Facade.addXDocument(file);
                            Console.WriteLine(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Facade.createExcel(textBox1.Text))
            {
                MessageBox.Show("Excel error");
            }
        }
    }
}

