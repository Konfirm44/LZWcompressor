
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
            this.comboBox_THREADS = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(358, 23);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(102, 23);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "Select input file";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input file:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_actionDECMP);
            this.groupBox1.Controls.Add(this.radioButton_actionCMP);
            this.groupBox1.Location = new System.Drawing.Point(21, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // radioButton_actionDECMP
            // 
            this.radioButton_actionDECMP.AutoSize = true;
            this.radioButton_actionDECMP.Location = new System.Drawing.Point(20, 43);
            this.radioButton_actionDECMP.Name = "radioButton_actionDECMP";
            this.radioButton_actionDECMP.Size = new System.Drawing.Size(82, 17);
            this.radioButton_actionDECMP.TabIndex = 1;
            this.radioButton_actionDECMP.Text = "decompress";
            this.radioButton_actionDECMP.UseVisualStyleBackColor = true;
            // 
            // radioButton_actionCMP
            // 
            this.radioButton_actionCMP.AutoSize = true;
            this.radioButton_actionCMP.Checked = true;
            this.radioButton_actionCMP.Location = new System.Drawing.Point(20, 20);
            this.radioButton_actionCMP.Name = "radioButton_actionCMP";
            this.radioButton_actionCMP.Size = new System.Drawing.Size(70, 17);
            this.radioButton_actionCMP.TabIndex = 0;
            this.radioButton_actionCMP.TabStop = true;
            this.radioButton_actionCMP.Text = "compress";
            this.radioButton_actionCMP.UseVisualStyleBackColor = true;
            this.radioButton_actionCMP.CheckedChanged += new System.EventHandler(this.radioButton_actionCMP_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output file:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(256, 20);
            this.textBox2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_ASM);
            this.groupBox2.Location = new System.Drawing.Point(140, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(66, 74);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Library";
            // 
            // checkBox_ASM
            // 
            this.checkBox_ASM.AutoSize = true;
            this.checkBox_ASM.Location = new System.Drawing.Point(6, 31);
            this.checkBox_ASM.Name = "checkBox_ASM";
            this.checkBox_ASM.Size = new System.Drawing.Size(49, 17);
            this.checkBox_ASM.TabIndex = 0;
            this.checkBox_ASM.Text = "ASM";
            this.checkBox_ASM.UseVisualStyleBackColor = true;
            // 
            // button_START
            // 
            this.button_START.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_START.Location = new System.Drawing.Point(358, 104);
            this.button_START.Name = "button_START";
            this.button_START.Size = new System.Drawing.Size(102, 74);
            this.button_START.TabIndex = 8;
            this.button_START.Text = "START";
            this.button_START.UseVisualStyleBackColor = true;
            this.button_START.Click += new System.EventHandler(this.button_START_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_timer);
            this.groupBox3.Location = new System.Drawing.Point(256, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(85, 74);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time elapsed";
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_timer.Location = new System.Drawing.Point(23, 31);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(16, 13);
            this.label_timer.TabIndex = 0;
            this.label_timer.Text = "---";
            this.label_timer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(21, 198);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(439, 23);
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
            // comboBox_THREADS
            // 
            this.comboBox_THREADS.AllowDrop = true;
            this.comboBox_THREADS.FormattingEnabled = true;
            this.comboBox_THREADS.Location = new System.Drawing.Point(405, 54);
            this.comboBox_THREADS.Name = "comboBox_THREADS";
            this.comboBox_THREADS.Size = new System.Drawing.Size(54, 21);
            this.comboBox_THREADS.TabIndex = 11;
            this.comboBox_THREADS.SelectedIndexChanged += new System.EventHandler(this.comboBox_THREADS_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Threads:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_THREADS);
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
        private System.Windows.Forms.ComboBox comboBox_THREADS;
        private System.Windows.Forms.Label label3;
    }
}

