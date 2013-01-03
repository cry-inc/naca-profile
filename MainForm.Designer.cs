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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.checkBoxValuesText = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.profilePanel = new NacaProfile.ProfilePanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNormals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxNormals
            // 
            this.checkBoxNormals.AutoSize = true;
            this.checkBoxNormals.Checked = true;
            this.checkBoxNormals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNormals.Location = new System.Drawing.Point(3, 26);
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
            this.checkBoxProbes.Location = new System.Drawing.Point(3, 3);
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
            this.checkBoxValues.Location = new System.Drawing.Point(3, 49);
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
            this.checkBoxFields.Location = new System.Drawing.Point(3, 95);
            this.checkBoxFields.Name = "checkBoxFields";
            this.checkBoxFields.Size = new System.Drawing.Size(101, 17);
            this.checkBoxFields.TabIndex = 4;
            this.checkBoxFields.Text = "Felder anzeigen";
            this.checkBoxFields.UseVisualStyleBackColor = true;
            this.checkBoxFields.CheckedChanged += new System.EventHandler(this.checkBoxFields_CheckedChanged);
            // 
            // richTextBoxValues
            // 
            this.richTextBoxValues.Location = new System.Drawing.Point(3, 432);
            this.richTextBoxValues.Name = "richTextBoxValues";
            this.richTextBoxValues.Size = new System.Drawing.Size(135, 101);
            this.richTextBoxValues.TabIndex = 5;
            this.richTextBoxValues.Text = "21 -134 -261 -227 -58 196 328 490 -516 -629 -350 -248 -112 -8 56";
            // 
            // buttonValues
            // 
            this.buttonValues.Location = new System.Drawing.Point(3, 539);
            this.buttonValues.Name = "buttonValues";
            this.buttonValues.Size = new System.Drawing.Size(136, 25);
            this.buttonValues.TabIndex = 6;
            this.buttonValues.Text = "Messwerte einlesen";
            this.buttonValues.UseVisualStyleBackColor = true;
            this.buttonValues.Click += new System.EventHandler(this.buttonValues_Click);
            // 
            // buttonExportPng
            // 
            this.buttonExportPng.Location = new System.Drawing.Point(3, 403);
            this.buttonExportPng.Name = "buttonExportPng";
            this.buttonExportPng.Size = new System.Drawing.Size(136, 23);
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
            this.numericUpDown1.Location = new System.Drawing.Point(86, 360);
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
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
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
            this.label1.Location = new System.Drawing.Point(3, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dummy Daten:";
            // 
            // checkBoxCentroid
            // 
            this.checkBoxCentroid.AutoSize = true;
            this.checkBoxCentroid.Location = new System.Drawing.Point(3, 187);
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
            this.checkBoxAntiAlias.Location = new System.Drawing.Point(3, 210);
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
            this.radioButtonPolygon.Location = new System.Drawing.Point(3, 118);
            this.radioButtonPolygon.Name = "radioButtonPolygon";
            this.radioButtonPolygon.Size = new System.Drawing.Size(128, 17);
            this.radioButtonPolygon.TabIndex = 12;
            this.radioButtonPolygon.Text = "Felder als Polygonzug";
            this.radioButtonPolygon.UseVisualStyleBackColor = true;
            this.radioButtonPolygon.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonBezier
            // 
            this.radioButtonBezier.AutoSize = true;
            this.radioButtonBezier.Location = new System.Drawing.Point(3, 141);
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
            this.radioButtonSpline.Location = new System.Drawing.Point(3, 164);
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
            this.trackBarNormals.Location = new System.Drawing.Point(3, 253);
            this.trackBarNormals.Maximum = 1000;
            this.trackBarNormals.Minimum = 10;
            this.trackBarNormals.Name = "trackBarNormals";
            this.trackBarNormals.Size = new System.Drawing.Size(136, 42);
            this.trackBarNormals.TabIndex = 15;
            this.trackBarNormals.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarNormals.Value = 150;
            this.trackBarNormals.ValueChanged += new System.EventHandler(this.trackBarNormals_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Normalenskalierung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Werteskalierung";
            // 
            // trackBarValues
            // 
            this.trackBarValues.Location = new System.Drawing.Point(3, 316);
            this.trackBarValues.Maximum = 1000;
            this.trackBarValues.Minimum = 10;
            this.trackBarValues.Name = "trackBarValues";
            this.trackBarValues.Size = new System.Drawing.Size(135, 42);
            this.trackBarValues.TabIndex = 17;
            this.trackBarValues.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarValues.Value = 100;
            this.trackBarValues.ValueChanged += new System.EventHandler(this.trackBarValues_ValueChanged);
            // 
            // checkBoxValuesText
            // 
            this.checkBoxValuesText.AutoSize = true;
            this.checkBoxValuesText.Location = new System.Drawing.Point(3, 72);
            this.checkBoxValuesText.Name = "checkBoxValuesText";
            this.checkBoxValuesText.Size = new System.Drawing.Size(129, 17);
            this.checkBoxValuesText.TabIndex = 19;
            this.checkBoxValuesText.Text = "Messwerten anzeigen";
            this.checkBoxValuesText.UseVisualStyleBackColor = true;
            this.checkBoxValuesText.CheckedChanged += new System.EventHandler(this.checkBoxValuesText_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 576);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Netzwerk-Status:";
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Location = new System.Drawing.Point(105, 575);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(16, 16);
            this.panelStatus.TabIndex = 0;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 500;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.profilePanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.checkBoxProbes);
            this.splitContainer.Panel2.Controls.Add(this.panelStatus);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxNormals);
            this.splitContainer.Panel2.Controls.Add(this.label4);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxValues);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxValuesText);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxFields);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.richTextBoxValues);
            this.splitContainer.Panel2.Controls.Add(this.trackBarValues);
            this.splitContainer.Panel2.Controls.Add(this.buttonValues);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.buttonExportPng);
            this.splitContainer.Panel2.Controls.Add(this.trackBarNormals);
            this.splitContainer.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer.Panel2.Controls.Add(this.radioButtonSpline);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.radioButtonBezier);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxCentroid);
            this.splitContainer.Panel2.Controls.Add(this.radioButtonPolygon);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxAntiAlias);
            this.splitContainer.Size = new System.Drawing.Size(722, 593);
            this.splitContainer.SplitterDistance = 576;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 21;
            // 
            // profilePanel
            // 
            this.profilePanel.AntiAliasing = true;
            this.profilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profilePanel.Data = new float[0];
            this.profilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePanel.FieldMode = NacaProfile.FieldMode.PSpline;
            this.profilePanel.Location = new System.Drawing.Point(0, 0);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.NormalFactor = 0.15F;
            this.profilePanel.Profile = null;
            this.profilePanel.ShowCentroid = false;
            this.profilePanel.ShowFields = true;
            this.profilePanel.ShowNormals = true;
            this.profilePanel.ShowProbes = true;
            this.profilePanel.ShowValues = true;
            this.profilePanel.ShowValuesText = false;
            this.profilePanel.Size = new System.Drawing.Size(576, 593);
            this.profilePanel.TabIndex = 1;
            this.profilePanel.ValueFactor = 1F;
            this.profilePanel.ViewCenter = ((System.Drawing.PointF)(resources.GetObject("profilePanel.ViewCenter")));
            this.profilePanel.ViewRadius = 1.5F;
            this.profilePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.profilePanel_MouseDown);
            this.profilePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.profilePanel_MouseMove);
            this.profilePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.profilePanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 593);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(730, 620);
            this.Name = "MainForm";
            this.Text = "Profilverteilung";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.profilePanel_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNormals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValues)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.CheckBox checkBoxValuesText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.SplitContainer splitContainer;
        private ProfilePanel profilePanel;
    }
}

