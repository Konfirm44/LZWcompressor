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

        private void AdjustOutputFileName()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                textBox2.Text = textBox1.Text + (_shouldCompress ? "_cmp" : "_decmp");
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
            numericUpDown_threads.Enabled = true;
        }

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
            checkBox_asm.Enabled = _shouldCompress;
            numericUpDown_threads.Enabled = _shouldCompress;
            AdjustOutputFileName();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (!_shouldCompress && !fileValidForDecompression())
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

        private bool fileValidForDecompression()
        {
            String fileName = textBox1.Text;
            int index = fileName.IndexOf("_");
            if (index == -1)
            {
                return false;
            }
            String suffix = fileName.Substring(index);
            if (suffix == "_cmp")
            {
                return true;
            }

            return false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_wrappedController == null)
            {
                throw new ArgumentNullException(nameof(_wrappedController));
            }

            BackgroundWorker worker = sender as BackgroundWorker;
            _stopwatch = new Stopwatch();
            _stopwatch.Reset();
            _stopwatch.Start();
            _wrappedController.work();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _stopwatch.Stop();
            timer1.Stop();
            timer2.Stop();
            progressBar.Value = progressBar.Maximum;

            TimeSpan timeSpan = _stopwatch.Elapsed;
            MessageBox.Show("Finished in " + timeSpan.ToString(@"hh\:mm\:ss\.ffff") + "\n(that is " + timeSpan.TotalSeconds.ToString() + " seconds).", "LZWcompressor");
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
            progressBar.Value = _wrappedController.getProgress();
        }

        private void checkBox_cstring_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_asm.Enabled = checkBox_cstring.Checked;
        }
    }
}
