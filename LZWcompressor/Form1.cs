using System;
using System.ComponentModel;
using System.Windows.Forms;
using Wrapper;

namespace LZWcompressor
{
    public partial class Form1 : Form
    {
        private bool _shouldCompress;
        private WrappedController _wrappedController;
        private int _seconds;


        public Form1()
        {
            InitializeComponent();
            _shouldCompress = radioButton_actionCMP.Checked;
            label_timer.Text = "";
            button_START.Enabled = false;

            var threads = Environment.ProcessorCount;
            numericUpDown_THREADS.Value = threads;
        }

        private void AdjustOutputFileName()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                textBox2.Text = textBox1.Text + (_shouldCompress ? "_cmp" : "_decmp");
        }

        private void DisableControls()
        {
            button_START.Enabled = false;
            button_select.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            numericUpDown_THREADS.Enabled = false;
        }

        private void EnableControls()
        {
            button_START.Enabled = true;
            button_select.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            numericUpDown_THREADS.Enabled = true;
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        progressBar.Value = 0;
                        label_timer.Text = "";
                    }

                    textBox1.Text = openFileDialog.FileName;
                    AdjustOutputFileName();
                    button_START.Enabled = true;
                }
            }
        }

        private void radioButton_actionCMP_CheckedChanged(object sender, EventArgs e)
        {
            _shouldCompress = radioButton_actionCMP.Checked;
            AdjustOutputFileName();
        }

        private void button_START_Click(object sender, EventArgs e)
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
            _wrappedController = new WrappedController(textBox1.Text, _shouldCompress, checkBox_ASM.Checked, (int)numericUpDown_THREADS.Value);
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
            _wrappedController.work();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = progressBar.Maximum;
            timer1.Stop();
            timer2.Stop();
            MessageBox.Show("Finished in " + _seconds.ToString() + " seconds.", "LZWcompressor");
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
            if (_wrappedController == null)
            {
                throw new ArgumentNullException(nameof(_wrappedController));
            }

            progressBar.Value = _wrappedController.getProgress();
        }
    }
}
