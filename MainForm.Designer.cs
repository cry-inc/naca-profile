namespace NacaProfile
{
    partial class MainForm
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
            this.checkBoxNormals = new System.Windows.Forms.CheckBox();
            this.checkBoxProbes = new System.Windows.Forms.CheckBox();
            this.checkBoxValues = new System.Windows.Forms.CheckBox();
            this.checkBoxFields = new System.Windows.Forms.CheckBox();
            this.richTextBoxValues = new System.Windows.Forms.RichTextBox();
            this.buttonValues = new System.Windows.Forms.Button();
            this.buttonExportPng = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.profilePanel = new NacaProfile.ProfilePanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxNormals
            // 
            this.checkBoxNormals.AutoSize = true;
            this.checkBoxNormals.Location = new System.Drawing.Point(610, 35);
            this.checkBoxNormals.Name = "checkBoxNormals";
            this.checkBoxNormals.Size = new System.Drawing.Size(111, 17);
            this.checkBoxNormals.TabIndex = 1;
            this.checkBoxNormals.Text = "Normale anzeigen";
            this.checkBoxNormals.UseVisualStyleBackColor = true;
            this.checkBoxNormals.CheckedChanged += new System.EventHandler(this.checkBoxNormals_CheckedChanged);
            // 
            // checkBoxProbes
            // 
            this.checkBoxProbes.AutoSize = true;
            this.checkBoxProbes.Location = new System.Drawing.Point(610, 12);
            this.checkBoxProbes.Name = "checkBoxProbes";
            this.checkBoxProbes.Size = new System.Drawing.Size(130, 17);
            this.checkBoxProbes.TabIndex = 2;
            this.checkBoxProbes.Text = "Messpunkte anzeigen";
            this.checkBoxProbes.UseVisualStyleBackColor = true;
            this.checkBoxProbes.CheckedChanged += new System.EventHandler(this.checkBoxProbes_CheckedChanged);
            // 
            // checkBoxValues
            // 
            this.checkBoxValues.AutoSize = true;
            this.checkBoxValues.Location = new System.Drawing.Point(610, 58);
            this.checkBoxValues.Name = "checkBoxValues";
            this.checkBoxValues.Size = new System.Drawing.Size(127, 17);
            this.checkBoxValues.TabIndex = 3;
            this.checkBoxValues.Text = "Messungen anzeigen";
            this.checkBoxValues.UseVisualStyleBackColor = true;
            this.checkBoxValues.CheckedChanged += new System.EventHandler(this.checkBoxValues_CheckedChanged);
            // 
            // checkBoxFields
            // 
            this.checkBoxFields.AutoSize = true;
            this.checkBoxFields.Location = new System.Drawing.Point(610, 81);
            this.checkBoxFields.Name = "checkBoxFields";
            this.checkBoxFields.Size = new System.Drawing.Size(101, 17);
            this.checkBoxFields.TabIndex = 4;
            this.checkBoxFields.Text = "Felder anzeigen";
            this.checkBoxFields.UseVisualStyleBackColor = true;
            this.checkBoxFields.CheckedChanged += new System.EventHandler(this.checkBoxFields_CheckedChanged);
            // 
            // richTextBoxValues
            // 
            this.richTextBoxValues.Location = new System.Drawing.Point(610, 386);
            this.richTextBoxValues.Name = "richTextBoxValues";
            this.richTextBoxValues.Size = new System.Drawing.Size(127, 187);
            this.richTextBoxValues.TabIndex = 5;
            this.richTextBoxValues.Text = "";
            // 
            // buttonValues
            // 
            this.buttonValues.Location = new System.Drawing.Point(610, 579);
            this.buttonValues.Name = "buttonValues";
            this.buttonValues.Size = new System.Drawing.Size(127, 25);
            this.buttonValues.TabIndex = 6;
            this.buttonValues.Text = "Messwerte anzeigen";
            this.buttonValues.UseVisualStyleBackColor = true;
            this.buttonValues.Click += new System.EventHandler(this.buttonValues_Click);
            // 
            // buttonExportPng
            // 
            this.buttonExportPng.Location = new System.Drawing.Point(610, 259);
            this.buttonExportPng.Name = "buttonExportPng";
            this.buttonExportPng.Size = new System.Drawing.Size(130, 23);
            this.buttonExportPng.TabIndex = 7;
            this.buttonExportPng.Text = "Grafik exportieren";
            this.buttonExportPng.UseVisualStyleBackColor = true;
            this.buttonExportPng.Click += new System.EventHandler(this.buttonExportPng_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(693, 161);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dummy Daten:";
            // 
            // profilePanel
            // 
            this.profilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePanel.Data = new float[0];
            this.profilePanel.Location = new System.Drawing.Point(4, 4);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Profile = null;
            this.profilePanel.ShowField = false;
            this.profilePanel.ShowNormals = false;
            this.profilePanel.ShowProbes = false;
            this.profilePanel.ShowValues = false;
            this.profilePanel.Size = new System.Drawing.Size(600, 600);
            this.profilePanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 607);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonExportPng);
            this.Controls.Add(this.buttonValues);
            this.Controls.Add(this.richTextBoxValues);
            this.Controls.Add(this.checkBoxFields);
            this.Controls.Add(this.checkBoxValues);
            this.Controls.Add(this.checkBoxProbes);
            this.Controls.Add(this.checkBoxNormals);
            this.Controls.Add(this.profilePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Profilverteilung";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProfilePanel profilePanel;
        private System.Windows.Forms.CheckBox checkBoxNormals;
        private System.Windows.Forms.CheckBox checkBoxProbes;
        private System.Windows.Forms.CheckBox checkBoxValues;
        private System.Windows.Forms.CheckBox checkBoxFields;
        private System.Windows.Forms.RichTextBox richTextBoxValues;
        private System.Windows.Forms.Button buttonValues;
        private System.Windows.Forms.Button buttonExportPng;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}

