namespace Search_Address2_OutlookAddIn
{
    partial class FormSearchAddress
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.listBoxKind = new System.Windows.Forms.ListBox();
            this.timerWatch = new System.Windows.Forms.Timer(this.components);
            this.listBoxAddress = new System.Windows.Forms.ListBox();
            this.buttonKind = new System.Windows.Forms.Button();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelReplyTo = new System.Windows.Forms.Label();
            this.labelReplyToList = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxKind
            // 
            this.listBoxKind.ItemHeight = 12;
            this.listBoxKind.Items.AddRange(new object[] {
            "To:",
            "Cc:",
            "Bcc:",
            "Reply-To:"});
            this.listBoxKind.Location = new System.Drawing.Point(2, 24);
            this.listBoxKind.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxKind.Name = "listBoxKind";
            this.listBoxKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBoxKind.Size = new System.Drawing.Size(75, 52);
            this.listBoxKind.TabIndex = 4;
            this.listBoxKind.Visible = false;
            this.listBoxKind.Click += new System.EventHandler(this.ListBoxKind_Click);
            this.listBoxKind.SelectedIndexChanged += new System.EventHandler(this.ListBoxKind_SelectedIndexChanged);
            this.listBoxKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxKind_KeyDown);
            // 
            // timerWatch
            // 
            this.timerWatch.Interval = 250;
            this.timerWatch.Tick += new System.EventHandler(this.TimerWatch_Tick);
            // 
            // listBoxAddress
            // 
            this.listBoxAddress.FormattingEnabled = true;
            this.listBoxAddress.ItemHeight = 12;
            this.listBoxAddress.Location = new System.Drawing.Point(77, 22);
            this.listBoxAddress.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxAddress.Name = "listBoxAddress";
            this.listBoxAddress.Size = new System.Drawing.Size(267, 76);
            this.listBoxAddress.TabIndex = 2;
            this.listBoxAddress.Visible = false;
            this.listBoxAddress.Click += new System.EventHandler(this.ListBoxAddress_Click);
            this.listBoxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxAddress_KeyDown);
            // 
            // buttonKind
            // 
            this.buttonKind.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonKind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKind.Location = new System.Drawing.Point(2, 1);
            this.buttonKind.Margin = new System.Windows.Forms.Padding(0);
            this.buttonKind.Name = "buttonKind";
            this.buttonKind.Size = new System.Drawing.Size(75, 23);
            this.buttonKind.TabIndex = 3;
            this.buttonKind.Text = "To:";
            this.buttonKind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKind.UseVisualStyleBackColor = false;
            this.buttonKind.Click += new System.EventHandler(this.ButtonKind_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxAddress.Location = new System.Drawing.Point(77, 3);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(267, 19);
            this.textBoxAddress.TabIndex = 1;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.TextBoxAddress_TextChanged);
            this.textBoxAddress.Enter += new System.EventHandler(this.TextBoxAddress_Enter);
            this.textBoxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAddress_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 25);
            this.panel1.TabIndex = 5;
            // 
            // labelReplyTo
            // 
            this.labelReplyTo.AutoEllipsis = true;
            this.labelReplyTo.BackColor = System.Drawing.Color.Yellow;
            this.labelReplyTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelReplyTo.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelReplyTo.Location = new System.Drawing.Point(350, 3);
            this.labelReplyTo.Margin = new System.Windows.Forms.Padding(0);
            this.labelReplyTo.Name = "labelReplyTo";
            this.labelReplyTo.Size = new System.Drawing.Size(37, 19);
            this.labelReplyTo.TabIndex = 7;
            this.labelReplyTo.Text = "ReplyTo";
            this.labelReplyTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelReplyTo.Visible = false;
            this.labelReplyTo.MouseLeave += new System.EventHandler(this.LabelReplyTo_MouseLeave);
            this.labelReplyTo.MouseHover += new System.EventHandler(this.LabelReplyTo_MouseHover);
            // 
            // labelReplyToList
            // 
            this.labelReplyToList.AutoSize = true;
            this.labelReplyToList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelReplyToList.Location = new System.Drawing.Point(350, 22);
            this.labelReplyToList.Margin = new System.Windows.Forms.Padding(0);
            this.labelReplyToList.Name = "labelReplyToList";
            this.labelReplyToList.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.labelReplyToList.Size = new System.Drawing.Size(37, 15);
            this.labelReplyToList.TabIndex = 8;
            this.labelReplyToList.Text = "label1";
            this.labelReplyToList.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(78, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(202, 53);
            this.label1.TabIndex = 9;
            this.label1.Text = "LDAP Server Connection Error\r\n\r\nSet the options collectly.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // FormSearchAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(620, 152);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelReplyToList);
            this.Controls.Add(this.labelReplyTo);
            this.Controls.Add(this.listBoxAddress);
            this.Controls.Add(this.listBoxKind);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.buttonKind);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchAddress";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Search Address";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Green;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxKind;
        private System.Windows.Forms.Timer timerWatch;
        private System.Windows.Forms.ListBox listBoxAddress;
        private System.Windows.Forms.Button buttonKind;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelReplyTo;
        private System.Windows.Forms.Label labelReplyToList;
        private System.Windows.Forms.Label label1;
    }
}