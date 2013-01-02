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
            this.checkBoxCentroid = new System.Windows.Forms.CheckBox();
            this.checkBoxAntiAlias = new System.Windows.Forms.CheckBox();
            this.radioButtonPolygon = new System.Windows.Forms.RadioButton();
            this.radioButtonBezier = new System.Windows.Forms.RadioButton();
            this.radioButtonSpline = new System.Windows.Forms.RadioButton();
            this.trackBarNormals = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarValues = new System.Windows.Forms.TrackBar();
            this.profilePanel = new NacaProfile.ProfilePanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNormals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValues)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxNormals
            // 
            this.checkBoxNormals.AutoSize = true;
            this.checkBoxNormals.Checked = true;
            this.checkBoxNormals.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.checkBoxProbes.Checked = true;
            this.checkBoxProbes.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.checkBoxValues.Checked = true;
            this.checkBoxValues.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.checkBoxFields.Checked = true;
            this.checkBoxFields.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.richTextBoxValues.Location = new System.Drawing.Point(610, 441);
            this.richTextBoxValues.Name = "richTextBoxValues";
            this.richTextBoxValues.Size = new System.Drawing.Size(127, 132);
            this.richTextBoxValues.TabIndex = 5;
            this.richTextBoxValues.Text = "";
            // 
            // buttonValues
            // 
            this.buttonValues.Location = new System.Drawing.Point(610, 579);
            this.buttonValues.Name = "buttonValues";
            this.buttonValues.Size = new System.Drawing.Size(127, 25);
            this.buttonValues.TabIndex = 6;
            this.buttonValues.Text = "Messwerte einlesen";
            this.buttonValues.UseVisualStyleBackColor = true;
            this.buttonValues.Click += new System.EventHandler(this.buttonValues_Click);
            // 
            // buttonExportPng
            // 
            this.buttonExportPng.Location = new System.Drawing.Point(610, 412);
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
            this.numericUpDown1.Location = new System.Drawing.Point(693, 369);
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
            this.label1.Location = new System.Drawing.Point(607, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dummy Daten:";
            // 
            // checkBoxCentroid
            // 
            this.checkBoxCentroid.AutoSize = true;
            this.checkBoxCentroid.Location = new System.Drawing.Point(610, 173);
            this.checkBoxCentroid.Name = "checkBoxCentroid";
            this.checkBoxCentroid.Size = new System.Drawing.Size(111, 17);
            this.checkBoxCentroid.TabIndex = 10;
            this.checkBoxCentroid.Text = "Centroid anzeigen";
            this.checkBoxCentroid.UseVisualStyleBackColor = true;
            this.checkBoxCentroid.CheckedChanged += new System.EventHandler(this.checkBoxCentroid_CheckedChanged);
            // 
            // checkBoxAntiAlias
            // 
            this.checkBoxAntiAlias.AutoSize = true;
            this.checkBoxAntiAlias.Checked = true;
            this.checkBoxAntiAlias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAntiAlias.Location = new System.Drawing.Point(610, 196);
            this.checkBoxAntiAlias.Name = "checkBoxAntiAlias";
            this.checkBoxAntiAlias.Size = new System.Drawing.Size(80, 17);
            this.checkBoxAntiAlias.TabIndex = 11;
            this.checkBoxAntiAlias.Text = "AntiAliasing";
            this.checkBoxAntiAlias.UseVisualStyleBackColor = true;
            this.checkBoxAntiAlias.CheckedChanged += new System.EventHandler(this.checkBoxAntiAlias_CheckedChanged);
            // 
            // radioButtonPolygon
            // 
            this.radioButtonPolygon.AutoSize = true;
            this.radioButtonPolygon.Location = new System.Drawing.Point(610, 104);
            this.radioButtonPolygon.Name = "radioButtonPolygon";
            this.radioButtonPolygon.Size = new System.Drawing.Size(117, 17);
            this.radioButtonPolygon.TabIndex = 12;
            this.radioButtonPolygon.Text = "Felder als Polygone";
            this.radioButtonPolygon.UseVisualStyleBackColor = true;
            this.radioButtonPolygon.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonBezier
            // 
            this.radioButtonBezier.AutoSize = true;
            this.radioButtonBezier.Location = new System.Drawing.Point(610, 127);
            this.radioButtonBezier.Name = "radioButtonBezier";
            this.radioButtonBezier.Size = new System.Drawing.Size(135, 17);
            this.radioButtonBezier.TabIndex = 13;
            this.radioButtonBezier.Text = "Felder als Bezierkurven";
            this.radioButtonBezier.UseVisualStyleBackColor = true;
            this.radioButtonBezier.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSpline
            // 
            this.radioButtonSpline.AutoSize = true;
            this.radioButtonSpline.Checked = true;
            this.radioButtonSpline.Location = new System.Drawing.Point(610, 150);
            this.radioButtonSpline.Name = "radioButtonSpline";
            this.radioButtonSpline.Size = new System.Drawing.Size(114, 17);
            this.radioButtonSpline.TabIndex = 14;
            this.radioButtonSpline.TabStop = true;
            this.radioButtonSpline.Text = "Felder als PSplines";
            this.radioButtonSpline.UseVisualStyleBackColor = true;
            this.radioButtonSpline.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // trackBarNormals
            // 
            this.trackBarNormals.Location = new System.Drawing.Point(610, 253);
            this.trackBarNormals.Maximum = 1000;
            this.trackBarNormals.Minimum = 10;
            this.trackBarNormals.Name = "trackBarNormals";
            this.trackBarNormals.Size = new System.Drawing.Size(127, 42);
            this.trackBarNormals.TabIndex = 15;
            this.trackBarNormals.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarNormals.Value = 150;
            this.trackBarNormals.ValueChanged += new System.EventHandler(this.trackBarNormals_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Normalenskalierung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(627, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Werteskalierung";
            // 
            // trackBarValues
            // 
            this.trackBarValues.Location = new System.Drawing.Point(610, 321);
            this.trackBarValues.Maximum = 1000;
            this.trackBarValues.Minimum = 10;
            this.trackBarValues.Name = "trackBarValues";
            this.trackBarValues.Size = new System.Drawing.Size(127, 42);
            this.trackBarValues.TabIndex = 17;
            this.trackBarValues.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarValues.Value = 100;
            this.trackBarValues.ValueChanged += new System.EventHandler(this.trackBarValues_ValueChanged);
            // 
            // profilePanel
            // 
            this.profilePanel.AntiAliasing = true;
            this.profilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePanel.Data = new float[0];
            this.profilePanel.FieldMode = NacaProfile.FieldMode.PSpline;
            this.profilePanel.Location = new System.Drawing.Point(4, 4);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.NormalFactor = 0.15F;
            this.profilePanel.Profile = null;
            this.profilePanel.ShowCentroid = false;
            this.profilePanel.ShowFields = true;
            this.profilePanel.ShowNormals = true;
            this.profilePanel.ShowProbes = true;
            this.profilePanel.ShowValues = true;
            this.profilePanel.Size = new System.Drawing.Size(600, 600);
            this.profilePanel.TabIndex = 0;
            this.profilePanel.ValueFactor = 1F;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarValues);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarNormals);
            this.Controls.Add(this.radioButtonSpline);
            this.Controls.Add(this.radioButtonBezier);
            this.Controls.Add(this.radioButtonPolygon);
            this.Controls.Add(this.checkBoxAntiAlias);
            this.Controls.Add(this.checkBoxCentroid);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Profilverteilung";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNormals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValues)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBoxCentroid;
        private System.Windows.Forms.CheckBox checkBoxAntiAlias;
        private System.Windows.Forms.RadioButton radioButtonPolygon;
        private System.Windows.Forms.RadioButton radioButtonBezier;
        private System.Windows.Forms.RadioButton radioButtonSpline;
        private System.Windows.Forms.TrackBar trackBarNormals;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarValues;
    }
}

