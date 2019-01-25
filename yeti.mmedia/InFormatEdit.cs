//
//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.
//
//  Email:  yetiicb@hotmail.com
//
//  Copyright (C) 2002-2003 Idael Cardoso. 
//

using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WaveLib;

namespace Yeti.MMedia
{
    /// <summary>
    /// Summary description for EditFormat.
    /// </summary>
    public class EditFormat : UserControl, IEditFormat
    {
        private ComboBox comboBoxChannels;
        private ComboBox comboBoxBitsPerSample;
        private Label label3;
        private Label label2;
        private Controls.NumericTextBox textBoxSampleRate;
        private Label label1;
        private ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
        private WaveFormat m_OrigFormat;
        private ErrorProvider errorProvider1;

        private bool m_FireConfigChangeEvent = true;

        public EditFormat()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            Format = new WaveFormat(44100, 16, 2); //Set default values
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public bool ReadOnly
        {
            get
            {
                return textBoxSampleRate.ReadOnly;
            }
            set
            {
                textBoxSampleRate.ReadOnly = value;
                comboBoxBitsPerSample.Enabled = comboBoxChannels.Enabled = !value;
            }
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBoxChannels = new ComboBox();
            comboBoxBitsPerSample = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            textBoxSampleRate = new Controls.NumericTextBox();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            errorProvider1 = new ErrorProvider();
            SuspendLayout();
            // 
            // comboBoxChannels
            // 
            comboBoxChannels.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChannels.Items.AddRange(new object[] {
                                                          "MONO",
                                                          "STEREO"});
            comboBoxChannels.Location = new Point(96, 56);
            comboBoxChannels.Name = "comboBoxChannels";
            comboBoxChannels.Size = new Size(112, 21);
            comboBoxChannels.TabIndex = 13;
            comboBoxChannels.SelectedIndexChanged += new EventHandler(comboBoxChannels_SelectedIndexChanged);
            // 
            // comboBoxBitsPerSample
            // 
            comboBoxBitsPerSample.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBitsPerSample.Items.AddRange(new object[] {
                                                               "8 bits per sample",
                                                               "16 bits per sample"});
            comboBoxBitsPerSample.Location = new Point(96, 96);
            comboBoxBitsPerSample.Name = "comboBoxBitsPerSample";
            comboBoxBitsPerSample.Size = new Size(112, 21);
            comboBoxBitsPerSample.TabIndex = 12;
            comboBoxBitsPerSample.SelectedIndexChanged += new EventHandler(comboBoxBitsPerSample_SelectedIndexChanged);
            // 
            // label3
            // 
            label3.Location = new Point(16, 96);
            label3.Name = "label3";
            label3.Size = new Size(88, 23);
            label3.TabIndex = 11;
            label3.Text = "Bits per sample:";
            // 
            // label2
            // 
            label2.Location = new Point(16, 56);
            label2.Name = "label2";
            label2.Size = new Size(72, 16);
            label2.TabIndex = 10;
            label2.Text = "Audio mode:";
            // 
            // textBoxSampleRate
            // 
            textBoxSampleRate.Location = new Point(96, 16);
            textBoxSampleRate.Name = "textBoxSampleRate";
            textBoxSampleRate.Size = new Size(112, 20);
            textBoxSampleRate.TabIndex = 8;
            textBoxSampleRate.Text = "44100";
            toolTip1.SetToolTip(textBoxSampleRate, "Sample rate, in samples per second. ");
            textBoxSampleRate.Value = 44100;
            textBoxSampleRate.FormatValid += new EventHandler(textBoxSampleRate_FormatValid);
            textBoxSampleRate.FormatError += new EventHandler(textBoxSampleRate_FormatError);
            textBoxSampleRate.TextChanged += new EventHandler(textBoxSampleRate_TextChanged);
            // 
            // label1
            // 
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(72, 16);
            label1.TabIndex = 9;
            label1.Text = "Sample rate:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // EditFormat
            // 
            Controls.Add(comboBoxChannels);
            Controls.Add(comboBoxBitsPerSample);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxSampleRate);
            Controls.Add(label1);
            Name = "EditFormat";
            Size = new Size(288, 200);
            ResumeLayout(false);

        }
        #endregion

        #region IConfigControl Members

        public void DoApply()
        {
            // Nothing to do
        }

        public void DoSetInitialValues()
        {
            m_FireConfigChangeEvent = false;
            try
            {
                textBoxSampleRate.Text = m_OrigFormat.nSamplesPerSec.ToString();
                if (m_OrigFormat.wBitsPerSample == 8)
                {
                    comboBoxBitsPerSample.SelectedIndex = 0;
                }
                else
                {
                    comboBoxBitsPerSample.SelectedIndex = 1;
                }
                if (m_OrigFormat.nChannels == 1)
                {
                    comboBoxChannels.SelectedIndex = 0;
                }
                else
                {
                    comboBoxChannels.SelectedIndex = 1;
                }
            }
            finally
            {
                m_FireConfigChangeEvent = true;
            }
        }

        public Control ConfigControl
        {
            get
            {
                return this;
            }
        }

        public string ControlName
        {
            get
            {
                return "Input Format";
            }
        }

        public event EventHandler ConfigChange;

        #endregion

        #region IEditFormat members

        public WaveFormat Format
        {
            get
            {
                int rate = int.Parse(textBoxSampleRate.Text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
                int bits;
                int channels;
                if (comboBoxBitsPerSample.SelectedIndex == 0)
                {
                    bits = 8;
                    comboBoxBitsPerSample.SelectedIndex = 0;
                }
                else
                {
                    bits = 16;
                }
                if (comboBoxChannels.SelectedIndex == 0)
                {
                    channels = 1;
                }
                else
                {
                    channels = 2;
                }
                return new WaveFormat(rate, bits, channels);
            }
            set
            {
                m_OrigFormat = value;
                DoSetInitialValues();
            }
        }

        #endregion

        private void OnConfigChange(EventArgs e)
        {
            if (m_FireConfigChangeEvent && (ConfigChange != null))
            {
                ConfigChange(this, e);
            }
        }

        private void textBoxSampleRate_TextChanged(object sender, EventArgs e)
        {
            // TODO: Validate text
            OnConfigChange(EventArgs.Empty);
        }

        private void comboBoxChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnConfigChange(EventArgs.Empty);
        }

        private void comboBoxBitsPerSample_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnConfigChange(EventArgs.Empty);
        }

        private void textBoxSampleRate_FormatError(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBoxSampleRate, "Number expected");
        }

        private void textBoxSampleRate_FormatValid(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBoxSampleRate, "");
        }
    }
}
