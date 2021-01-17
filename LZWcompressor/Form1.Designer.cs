
namespace LZWcompressor
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
            this.button_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_actionDECMP = new System.Windows.Forms.RadioButton();
            this.radioButton_actionCMP = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_ASM = new System.Windows.Forms.CheckBox();
            this.button_START = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_timer = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_THREADS = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_THREADS)).BeginInit();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(477, 28);
            this.button_select.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(136, 28);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "Select input file";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input file:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 31);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(340, 22);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_actionDECMP);
            this.groupBox1.Controls.Add(this.radioButton_actionCMP);
            this.groupBox1.Location = new System.Drawing.Point(28, 128);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(151, 91);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // radioButton_actionDECMP
            // 
            this.radioButton_actionDECMP.AutoSize = true;
            this.radioButton_actionDECMP.Location = new System.Drawing.Point(27, 53);
            this.radioButton_actionDECMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_actionDECMP.Name = "radioButton_actionDECMP";
            this.radioButton_actionDECMP.Size = new System.Drawing.Size(106, 21);
            this.radioButton_actionDECMP.TabIndex = 1;
            this.radioButton_actionDECMP.Text = "decompress";
            this.radioButton_actionDECMP.UseVisualStyleBackColor = true;
            // 
            // radioButton_actionCMP
            // 
            this.radioButton_actionCMP.AutoSize = true;
            this.radioButton_actionCMP.Checked = true;
            this.radioButton_actionCMP.Location = new System.Drawing.Point(27, 25);
            this.radioButton_actionCMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_actionCMP.Name = "radioButton_actionCMP";
            this.radioButton_actionCMP.Size = new System.Drawing.Size(90, 21);
            this.radioButton_actionCMP.TabIndex = 0;
            this.radioButton_actionCMP.TabStop = true;
            this.radioButton_actionCMP.Text = "compress";
            this.radioButton_actionCMP.UseVisualStyleBackColor = true;
            this.radioButton_actionCMP.CheckedChanged += new System.EventHandler(this.radioButton_actionCMP_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output file:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(113, 66);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(340, 22);
            this.textBox2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_ASM);
            this.groupBox2.Location = new System.Drawing.Point(187, 128);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(88, 91);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Library";
            // 
            // checkBox_ASM
            // 
            this.checkBox_ASM.AutoSize = true;
            this.checkBox_ASM.Location = new System.Drawing.Point(8, 38);
            this.checkBox_ASM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_ASM.Name = "checkBox_ASM";
            this.checkBox_ASM.Size = new System.Drawing.Size(59, 21);
            this.checkBox_ASM.TabIndex = 0;
            this.checkBox_ASM.Text = "ASM";
            this.checkBox_ASM.UseVisualStyleBackColor = true;
            // 
            // button_START
            // 
            this.button_START.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_START.Location = new System.Drawing.Point(477, 128);
            this.button_START.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_START.Name = "button_START";
            this.button_START.Size = new System.Drawing.Size(136, 91);
            this.button_START.TabIndex = 8;
            this.button_START.Text = "START";
            this.button_START.UseVisualStyleBackColor = true;
            this.button_START.Click += new System.EventHandler(this.button_START_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_timer);
            this.groupBox3.Location = new System.Drawing.Point(341, 128);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(113, 91);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time elapsed";
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_timer.Location = new System.Drawing.Point(31, 38);
            this.label_timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(23, 17);
            this.label_timer.TabIndex = 0;
            this.label_timer.Text = "---";
            this.label_timer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(28, 244);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(585, 28);
            this.progressBar.TabIndex = 10;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Threads:";
            // 
            // numericUpDown_THREADS
            // 
            this.numericUpDown_THREADS.Location = new System.Drawing.Point(545, 67);
            this.numericUpDown_THREADS.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_THREADS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_THREADS.Name = "numericUpDown_THREADS";
            this.numericUpDown_THREADS.Size = new System.Drawing.Size(68, 22);
            this.numericUpDown_THREADS.TabIndex = 13;
            this.numericUpDown_THREADS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(645, 321);
            this.Controls.Add(this.numericUpDown_THREADS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_START);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_select);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "LZWcompressor";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_THREADS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_actionDECMP;
        private System.Windows.Forms.RadioButton radioButton_actionCMP;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_START;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox_ASM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_THREADS;
    }
}

