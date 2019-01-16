using GeneticTSP.CrossoverTypes;
using GeneticTSP.MutationTypes;
using GeneticTSP.SelectionTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GeneticTSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            int populationSize = int.Parse(populationInput.Text.ToString());
            float mutationChance = float.Parse(mutationChanceInput.Text.ToString(), CultureInfo.InvariantCulture);
            float crossOverChance = float.Parse(crossOverChanceInput.Text.ToString(), CultureInfo.InvariantCulture);
            int time = int.Parse(timeInput.Text.ToString());
            int breedingSize = int.Parse(breedingInput.Text.ToString());
            if (Facade.tspXmlFile == null) { 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "tspXMLFile|*.xml";
            if(ofd.ShowDialog()==DialogResult.OK)
            {

                    Facade.tspXmlFile = XDocument.Load(ofd.FileName);
            }
            }
            if (Facade.tspXmlFile != null)
            {
                Facade.createNewSolver(mutationCB.SelectedIndex, CrossoverCB.SelectedIndex, SelectionTypeCB.SelectedIndex, populationSize, mutationChance, time, breedingSize,crossOverChance);
                UpdateTaskList();
            }
        }

        private void UpdateTaskList()
        {
            TaskList.Items.Clear();
            foreach(var task in Facade.listTask)
            {
                TaskList.Items.Add(task.result.measureName);
            }
        }

        private void loadFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "tspXMLFile|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                Facade.tspXmlFile = XDocument.Load(ofd.FileName);
                fileInfoLabel.Text = ofd.SafeFileName;
            }
        }

        private void TaskList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            Facade.runSolution();
            UpdateTaskList();
        }

        private void RemoveTaskBtn_Click(object sender, EventArgs e)
        {
            if(TaskList.SelectedIndex!=-1)
            Facade.removeTask(TaskList.SelectedIndex);
            UpdateTaskList();
        }
    }
}
