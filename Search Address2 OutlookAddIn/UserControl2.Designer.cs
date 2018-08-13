namespace Search_Address2_OutlookAddIn
{
    partial class MyPropPage2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.numericUpDownOffsetX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownOffsetX
            // 
            this.numericUpDownOffsetX.Location = new System.Drawing.Point(92, 50);
            this.numericUpDownOffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownOffsetX.Name = "numericUpDownOffsetX";
            this.numericUpDownOffsetX.Size = new System.Drawing.Size(120, 19);
            this.numericUpDownOffsetX.TabIndex = 0;
            // 
            // numericUpDownOffsetY
            // 
            this.numericUpDownOffsetY.Location = new System.Drawing.Point(92, 100);
            this.numericUpDownOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownOffsetY.Name = "numericUpDownOffsetY";
            this.numericUpDownOffsetY.Size = new System.Drawing.Size(120, 19);
            this.numericUpDownOffsetY.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Offset X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Offset Y";
            // 
            // MyPropPage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownOffsetY);
            this.Controls.Add(this.numericUpDownOffsetX);
            this.Name = "MyPropPage2";
            this.Size = new System.Drawing.Size(269, 319);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownOffsetX;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
