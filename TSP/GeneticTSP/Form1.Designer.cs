namespace GeneticTSP
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
            this.label1 = new System.Windows.Forms.Label();
            this.TaskList = new System.Windows.Forms.ListBox();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.RemoveTaskBtn = new System.Windows.Forms.Button();
            this.MutationLabel = new System.Windows.Forms.Label();
            this.CrossOverType = new System.Windows.Forms.Label();
            this.SelectionTypeLabel = new System.Windows.Forms.Label();
            this.mutationCB = new System.Windows.Forms.ComboBox();
            this.CrossoverCB = new System.Windows.Forms.ComboBox();
            this.SelectionTypeCB = new System.Windows.Forms.ComboBox();
            this.mutationChanceInput = new System.Windows.Forms.TextBox();
            this.mutationChanceLabel = new System.Windows.Forms.Label();
            this.breedingInput = new System.Windows.Forms.TextBox();
            this.populationInput = new System.Windows.Forms.TextBox();
            this.sizeLB = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeInput = new System.Windows.Forms.TextBox();
            this.loadFileBtn = new System.Windows.Forms.Button();
            this.fileInfoLabel = new System.Windows.Forms.Label();
            this.RunBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.crossOverChanceInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Genetic Algorithm solver by Piotr Blonski";
            // 
            // TaskList
            // 
            this.TaskList.FormattingEnabled = true;
            this.TaskList.Location = new System.Drawing.Point(558, 56);
            this.TaskList.Name = "TaskList";
            this.TaskList.Size = new System.Drawing.Size(728, 394);
            this.TaskList.TabIndex = 1;
            this.TaskList.SelectedIndexChanged += new System.EventHandler(this.TaskList_SelectedIndexChanged);
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Location = new System.Drawing.Point(555, 9);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(102, 13);
            this.TaskLabel.TabIndex = 2;
            this.TaskLabel.Text = "Tasks ordered to do";
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Location = new System.Drawing.Point(558, 27);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.addTaskBtn.TabIndex = 3;
            this.addTaskBtn.Text = "Add";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.addTaskBtn_Click);
            // 
            // RemoveTaskBtn
            // 
            this.RemoveTaskBtn.Location = new System.Drawing.Point(717, 27);
            this.RemoveTaskBtn.Name = "RemoveTaskBtn";
            this.RemoveTaskBtn.Size = new System.Drawing.Size(71, 23);
            this.RemoveTaskBtn.TabIndex = 4;
            this.RemoveTaskBtn.Text = "Remove";
            this.RemoveTaskBtn.UseVisualStyleBackColor = true;
            this.RemoveTaskBtn.Click += new System.EventHandler(this.RemoveTaskBtn_Click);
            // 
            // MutationLabel
            // 
            this.MutationLabel.AutoSize = true;
            this.MutationLabel.Location = new System.Drawing.Point(12, 9);
            this.MutationLabel.Name = "MutationLabel";
            this.MutationLabel.Size = new System.Drawing.Size(75, 13);
            this.MutationLabel.TabIndex = 6;
            this.MutationLabel.Text = "Mutation Type";
            // 
            // CrossOverType
            // 
            this.CrossOverType.AutoSize = true;
            this.CrossOverType.Location = new System.Drawing.Point(9, 56);
            this.CrossOverType.Name = "CrossOverType";
            this.CrossOverType.Size = new System.Drawing.Size(81, 13);
            this.CrossOverType.TabIndex = 7;
            this.CrossOverType.Text = "Crossover Type";
            // 
            // SelectionTypeLabel
            // 
            this.SelectionTypeLabel.AutoSize = true;
            this.SelectionTypeLabel.Location = new System.Drawing.Point(9, 106);
            this.SelectionTypeLabel.Name = "SelectionTypeLabel";
            this.SelectionTypeLabel.Size = new System.Drawing.Size(78, 13);
            this.SelectionTypeLabel.TabIndex = 8;
            this.SelectionTypeLabel.Text = "Selection Type";
            // 
            // mutationCB
            // 
            this.mutationCB.FormattingEnabled = true;
            this.mutationCB.Items.AddRange(new object[] {
            "InversionMutation"});
            this.mutationCB.Location = new System.Drawing.Point(12, 25);
            this.mutationCB.Name = "mutationCB";
            this.mutationCB.Size = new System.Drawing.Size(121, 21);
            this.mutationCB.TabIndex = 9;
            // 
            // CrossoverCB
            // 
            this.CrossoverCB.FormattingEnabled = true;
            this.CrossoverCB.Items.AddRange(new object[] {
            "PMXCrossover",
            "OXCrossover"});
            this.CrossoverCB.Location = new System.Drawing.Point(12, 72);
            this.CrossoverCB.Name = "CrossoverCB";
            this.CrossoverCB.Size = new System.Drawing.Size(121, 21);
            this.CrossoverCB.TabIndex = 10;
            // 
            // SelectionTypeCB
            // 
            this.SelectionTypeCB.FormattingEnabled = true;
            this.SelectionTypeCB.Items.AddRange(new object[] {
            "TournamentSelection"});
            this.SelectionTypeCB.Location = new System.Drawing.Point(12, 122);
            this.SelectionTypeCB.Name = "SelectionTypeCB";
            this.SelectionTypeCB.Size = new System.Drawing.Size(121, 21);
            this.SelectionTypeCB.TabIndex = 11;
            // 
            // mutationChanceInput
            // 
            this.mutationChanceInput.Location = new System.Drawing.Point(233, 26);
            this.mutationChanceInput.Name = "mutationChanceInput";
            this.mutationChanceInput.Size = new System.Drawing.Size(100, 20);
            this.mutationChanceInput.TabIndex = 12;
            // 
            // mutationChanceLabel
            // 
            this.mutationChanceLabel.AutoSize = true;
            this.mutationChanceLabel.Location = new System.Drawing.Point(139, 32);
            this.mutationChanceLabel.Name = "mutationChanceLabel";
            this.mutationChanceLabel.Size = new System.Drawing.Size(88, 13);
            this.mutationChanceLabel.TabIndex = 13;
            this.mutationChanceLabel.Text = "Mutation Chance";
            // 
            // breedingInput
            // 
            this.breedingInput.Location = new System.Drawing.Point(233, 122);
            this.breedingInput.Name = "breedingInput";
            this.breedingInput.Size = new System.Drawing.Size(100, 20);
            this.breedingInput.TabIndex = 14;
            // 
            // populationInput
            // 
            this.populationInput.Location = new System.Drawing.Point(12, 182);
            this.populationInput.Name = "populationInput";
            this.populationInput.Size = new System.Drawing.Size(100, 20);
            this.populationInput.TabIndex = 15;
            // 
            // sizeLB
            // 
            this.sizeLB.AutoSize = true;
            this.sizeLB.Location = new System.Drawing.Point(9, 166);
            this.sizeLB.Name = "sizeLB";
            this.sizeLB.Size = new System.Drawing.Size(80, 13);
            this.sizeLB.TabIndex = 16;
            this.sizeLB.Text = "Population Size";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(15, 227);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(55, 13);
            this.timeLabel.TabIndex = 17;
            this.timeLabel.Text = "Time[Sec]";
            // 
            // timeInput
            // 
            this.timeInput.Location = new System.Drawing.Point(11, 257);
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(100, 20);
            this.timeInput.TabIndex = 18;
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.Location = new System.Drawing.Point(18, 306);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(94, 23);
            this.loadFileBtn.TabIndex = 19;
            this.loadFileBtn.Text = "Load TSP xml file";
            this.loadFileBtn.UseVisualStyleBackColor = true;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // fileInfoLabel
            // 
            this.fileInfoLabel.AutoSize = true;
            this.fileInfoLabel.Location = new System.Drawing.Point(128, 311);
            this.fileInfoLabel.Name = "fileInfoLabel";
            this.fileInfoLabel.Size = new System.Drawing.Size(72, 13);
            this.fileInfoLabel.TabIndex = 20;
            this.fileInfoLabel.Text = "No file loaded";
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(814, 27);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(75, 23);
            this.RunBtn.TabIndex = 21;
            this.RunBtn.Text = "Run solutions";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(944, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Results will be in folder: Results in xml files";
            // 
            // crossOverChanceInput
            // 
            this.crossOverChanceInput.Location = new System.Drawing.Point(233, 73);
            this.crossOverChanceInput.Name = "crossOverChanceInput";
            this.crossOverChanceInput.Size = new System.Drawing.Size(100, 20);
            this.crossOverChanceInput.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 450);
            this.Controls.Add(this.crossOverChanceInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.fileInfoLabel);
            this.Controls.Add(this.loadFileBtn);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.sizeLB);
            this.Controls.Add(this.populationInput);
            this.Controls.Add(this.breedingInput);
            this.Controls.Add(this.mutationChanceLabel);
            this.Controls.Add(this.mutationChanceInput);
            this.Controls.Add(this.SelectionTypeCB);
            this.Controls.Add(this.CrossoverCB);
            this.Controls.Add(this.mutationCB);
            this.Controls.Add(this.SelectionTypeLabel);
            this.Controls.Add(this.CrossOverType);
            this.Controls.Add(this.MutationLabel);
            this.Controls.Add(this.RemoveTaskBtn);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.TaskList);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox TaskList;
        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.Button RemoveTaskBtn;
        private System.Windows.Forms.Label MutationLabel;
        private System.Windows.Forms.Label CrossOverType;
        private System.Windows.Forms.Label SelectionTypeLabel;
        private System.Windows.Forms.ComboBox mutationCB;
        private System.Windows.Forms.ComboBox CrossoverCB;
        private System.Windows.Forms.ComboBox SelectionTypeCB;
        private System.Windows.Forms.TextBox mutationChanceInput;
        private System.Windows.Forms.Label mutationChanceLabel;
        private System.Windows.Forms.TextBox breedingInput;
        private System.Windows.Forms.TextBox populationInput;
        private System.Windows.Forms.Label sizeLB;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox timeInput;
        private System.Windows.Forms.Button loadFileBtn;
        private System.Windows.Forms.Label fileInfoLabel;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox crossOverChanceInput;
    }
}

