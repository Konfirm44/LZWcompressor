using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Wrapper;

namespace LZWcompressor
{
    public partial class Form1 : Form
    {
        private bool _shouldCompress;
        private WrappedController _wrappedController;
        private int _seconds;
        private Stopwatch _stopwatch;


        public Form1()
        {
            InitializeComponent();
            _shouldCompress = radioButton_cmp.Checked;
            label_timer.Text = "";
            button_start.Enabled = false;

            var threads = Environment.ProcessorCount;
            numericUpDown_threads.Value = threads;
        }

        private void AdjustInputFileName()
        {
            if (!_shouldCompress && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!textBox1.Text.EndsWith("_cmp"))
                {
                    textBox1.Text += "_cmp";
                }
            }
        }

        private void AdjustOutputFileName()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox2.Text = textBox1.Text + (_shouldCompress ? "_cmp" : "_decmp");
            }
        }

        private void DisableControls()
        {
            button_start.Enabled = false;
            button_select.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            numericUpDown_threads.Enabled = false;
        }

        private void EnableControls()
        {
            button_start.Enabled = true;
            button_select.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            numericUpDown_threads.Enabled = radioButton_cmp.Checked;
        }

        private bool IsFileValidForDecompression()
        {
            string fileName = textBox1.Text;
            int index = fileName.LastIndexOf("_");
            if (index == -1)
            {
                return false;
            }
            string suffix = fileName.Substring(index);
            return suffix == "_cmp";
        }

        private void LogDetails(TimeSpan timeSpan)
        {
            string path = @"log.csv";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write("date;");
                    sw.Write("inputFile;");
                    sw.Write("shouldCompress;");
                    sw.Write("useASM;");
                    sw.Write("useCstrings;");
                    sw.Write("threadCount;");
                    sw.Write("timeSpan;");
                    sw.WriteLine("outputSize");
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                DateTime dateTime = DateTime.Now;
                sw.Write(dateTime);
                sw.Write(";");
                sw.Write(@textBox1.Text);
                sw.Write(";");
                sw.Write(_shouldCompress);
                sw.Write(";");
                sw.Write(checkBox_asm.Checked);
                sw.Write(";");
                sw.Write(checkBox_cstring.Checked);
                sw.Write(";");
                sw.Write(numericUpDown_threads.Value);
                sw.Write(";");
                sw.Write(timeSpan.TotalMilliseconds);
                sw.Write(";");

                FileInfo fileInfo = new FileInfo(@textBox2.Text);
                sw.WriteLine(fileInfo.Length);
            }
        }

#pragma warning disable IDE1006 // Naming Styles - shut up, that's how winforms likes it

        private void button_select_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length == 0)
                    {
                        MessageBox.Show("Selected file is empty.", "LZWcompressor");
                    }
                    else
                    {
                        progressBar.Value = 0;
                        label_timer.Text = "";
                        textBox1.Text = openFileDialog.FileName;
                        AdjustOutputFileName();
                        button_start.Enabled = true;
                    }
                }
            }
        }

        private void radioButton_cmp_CheckedChanged(object sender, EventArgs e)
        {
            _shouldCompress = radioButton_cmp.Checked;
            numericUpDown_threads.Enabled = _shouldCompress;
            AdjustInputFileName();
            AdjustOutputFileName();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (!_shouldCompress && !IsFileValidForDecompression())
            {
                MessageBox.Show("Selected file cannot be decompressed (name lacks the '_cmp' suffix).", "LZWcompressor");
                return;
            }

            DisableControls();
            progressBar.Value = 0;
            _seconds = 0;
            label_timer.Text = "0 s";
            _wrappedController = new WrappedController(textBox1.Text, _shouldCompress, checkBox_asm.Checked, checkBox_cstring.Checked, (int)numericUpDown_threads.Value);
            backgroundWorker1.RunWorkerAsync();
            timer1.Start();
            timer2.Start();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_wrappedController == null)
            {
                throw new ArgumentNullException(nameof(_wrappedController));
            }

            _stopwatch = new Stopwatch();
            _stopwatch.Reset();
            _stopwatch.Start();
            _wrappedController.processFile();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _stopwatch.Stop();
            timer1.Stop();
            timer2.Stop();
            progressBar.Value = progressBar.Maximum;

            TimeSpan timeSpan = _stopwatch.Elapsed;
            LogDetails(timeSpan);

            MessageBox.Show("Finished in "+ timeSpan.TotalSeconds.ToString() + " seconds.", "LZWcompressor");
            label_timer.Text = timeSpan.TotalSeconds.ToString("0.###") + " s";
            _wrappedController = null;
            EnableControls();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_timer.Text = (++_seconds).ToString() + " s";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_wrappedController != null)
            {
                progressBar.Value = _wrappedController.getProgress();
            }
        }

        private void checkBox_cstring_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_asm.Enabled = checkBox_cstring.Checked && _shouldCompress;
        }
    }
}
