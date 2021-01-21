
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
            this.radioButton_decmp = new System.Windows.Forms.RadioButton();
            this.radioButton_cmp = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_cstring = new System.Windows.Forms.CheckBox();
            this.checkBox_asm = new System.Windows.Forms.CheckBox();
            this.button_start = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_timer = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_threads = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_threads)).BeginInit();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(382, 23);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(109, 22);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "Select input file";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input file:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_decmp);
            this.groupBox1.Controls.Add(this.radioButton_cmp);
            this.groupBox1.Location = new System.Drawing.Point(22, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 73);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // radioButton_decmp
            // 
            this.radioButton_decmp.AutoSize = true;
            this.radioButton_decmp.Location = new System.Drawing.Point(22, 42);
            this.radioButton_decmp.Name = "radioButton_decmp";
            this.radioButton_decmp.Size = new System.Drawing.Size(82, 17);
            this.radioButton_decmp.TabIndex = 1;
            this.radioButton_decmp.Text = "decompress";
            this.toolTip2.SetToolTip(this.radioButton_decmp, " ");
            this.radioButton_decmp.UseVisualStyleBackColor = true;
            // 
            // radioButton_cmp
            // 
            this.radioButton_cmp.AutoSize = true;
            this.radioButton_cmp.Checked = true;
            this.radioButton_cmp.Location = new System.Drawing.Point(22, 20);
            this.radioButton_cmp.Name = "radioButton_cmp";
            this.radioButton_cmp.Size = new System.Drawing.Size(70, 17);
            this.radioButton_cmp.TabIndex = 0;
            this.radioButton_cmp.TabStop = true;
            this.radioButton_cmp.Text = "compress";
            this.toolTip2.SetToolTip(this.radioButton_cmp, " ");
            this.radioButton_cmp.UseVisualStyleBackColor = true;
            this.radioButton_cmp.CheckedChanged += new System.EventHandler(this.radioButton_cmp_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output file:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(273, 20);
            this.textBox2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_cstring);
            this.groupBox2.Controls.Add(this.checkBox_asm);
            this.groupBox2.Location = new System.Drawing.Point(150, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 73);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // checkBox_cstring
            // 
            this.checkBox_cstring.AutoSize = true;
            this.checkBox_cstring.Checked = true;
            this.checkBox_cstring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cstring.Location = new System.Drawing.Point(6, 43);
            this.checkBox_cstring.Name = "checkBox_cstring";
            this.checkBox_cstring.Size = new System.Drawing.Size(105, 17);
            this.checkBox_cstring.TabIndex = 1;
            this.checkBox_cstring.Text = "text compression";
            this.toolTip1.SetToolTip(this.checkBox_cstring, "Uncheck \"text compression\" for processing other files.\r\n\r\nYou may try processing " +
        "non-text files with \r\n\"text compression\" checked only if they do not contain\r\n\"0" +
        "x00\" bytes. ");
            this.checkBox_cstring.UseVisualStyleBackColor = true;
            this.checkBox_cstring.CheckedChanged += new System.EventHandler(this.checkBox_cstring_CheckedChanged);
            // 
            // checkBox_asm
            // 
            this.checkBox_asm.AutoSize = true;
            this.checkBox_asm.Location = new System.Drawing.Point(6, 21);
            this.checkBox_asm.Name = "checkBox_asm";
            this.checkBox_asm.Size = new System.Drawing.Size(49, 17);
            this.checkBox_asm.TabIndex = 0;
            this.checkBox_asm.Text = "ASM";
            this.toolTip1.SetToolTip(this.checkBox_asm, "Uncheck \"text compression\" for processing other files.\r\n\r\nYou may try processing " +
        "non-text files with \r\n\"text compression\" checked only if they do not contain\r\n\"0" +
        "x00\" bytes. \r\n");
            this.checkBox_asm.UseVisualStyleBackColor = true;
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_start.Location = new System.Drawing.Point(382, 102);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(109, 73);
            this.button_start.TabIndex = 8;
            this.button_start.Text = "START";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_timer);
            this.groupBox3.Location = new System.Drawing.Point(273, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(90, 73);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time elapsed";
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_timer.Location = new System.Drawing.Point(25, 30);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(16, 13);
            this.label_timer.TabIndex = 0;
            this.label_timer.Text = "---";
            this.label_timer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 195);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(468, 22);
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
            this.label3.Location = new System.Drawing.Point(378, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Threads:";
            // 
            // numericUpDown_threads
            // 
            this.numericUpDown_threads.Location = new System.Drawing.Point(436, 54);
            this.numericUpDown_threads.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_threads.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown_threads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_threads.Name = "numericUpDown_threads";
            this.numericUpDown_threads.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown_threads.TabIndex = 13;
            this.numericUpDown_threads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "ASM only available for processing text files";
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipTitle = "ASM only available for compression";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(516, 257);
            this.Controls.Add(this.numericUpDown_threads);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_start);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_threads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_decmp;
        private System.Windows.Forms.RadioButton radioButton_cmp;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox_asm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_threads;
        private System.Windows.Forms.CheckBox checkBox_cstring;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

