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

using System.ComponentModel;
using System.Windows.Forms;

namespace Yeti.MMedia
{
    /// <summary>
    /// Summary description for EditWaveWriter.
    /// </summary>
    public class EditWaveWriter : UserControl, IEditAudioWriterConfig
    {
        private GroupBox groupBox1;
        private EditFormat editFormat1;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public EditWaveWriter()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call

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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            editFormat1 = new EditFormat();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(editFormat1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(312, 208);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Audio format";
            // 
            // editFormat1
            // 
            editFormat1.Dock = DockStyle.Fill;
            editFormat1.Location = new System.Drawing.Point(3, 16);
            editFormat1.Name = "editFormat1";
            editFormat1.ReadOnly = false;
            editFormat1.Size = new System.Drawing.Size(306, 189);
            editFormat1.TabIndex = 0;
            editFormat1.ConfigChange += new System.EventHandler(editFormat1_ConfigChange);
            // 
            // EditWaveWriter
            // 
            Controls.Add(groupBox1);
            Name = "EditWaveWriter";
            Size = new System.Drawing.Size(312, 208);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);

        }
        #endregion

        #region IEditAudioWriterConfig Members

        public AudioWriterConfig Config
        {
            get
            {
                return new AudioWriterConfig(editFormat1.Format);
            }
            set
            {
                editFormat1.Format = value.Format;
            }
        }

        #endregion

        #region IConfigControl Members

        public void DoApply()
        {
            editFormat1.DoApply();
        }

        public void DoSetInitialValues()
        {
            editFormat1.DoSetInitialValues();
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
                return "Wave writer config";
            }
        }

        public event System.EventHandler ConfigChange;

        #endregion

        private void editFormat1_ConfigChange(object sender, System.EventArgs e)
        {
            ConfigChange?.Invoke(sender, e);
        }
    }
}
