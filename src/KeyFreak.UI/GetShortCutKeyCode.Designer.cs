namespace KeyFreak.UI
{
    partial class GetShortCutKeyCode
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetShortCutKeyCode));
			this.labelKeyCode = new System.Windows.Forms.Label();
			this.textBoxKeyCode = new System.Windows.Forms.TextBox();
			this.buttonClear = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelKeyCode
			// 
			this.labelKeyCode.AutoSize = true;
			this.labelKeyCode.Location = new System.Drawing.Point(12, 17);
			this.labelKeyCode.Name = "labelKeyCode";
			this.labelKeyCode.Size = new System.Drawing.Size(74, 13);
			this.labelKeyCode.TabIndex = 0;
			this.labelKeyCode.Text = "Klawisz skrótu";
			// 
			// textBoxKeyCode
			// 
			this.textBoxKeyCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxKeyCode.Enabled = false;
			this.textBoxKeyCode.Location = new System.Drawing.Point(92, 14);
			this.textBoxKeyCode.Name = "textBoxKeyCode";
			this.textBoxKeyCode.Size = new System.Drawing.Size(223, 20);
			this.textBoxKeyCode.TabIndex = 1;
			// 
			// buttonClear
			// 
			this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClear.Location = new System.Drawing.Point(321, 12);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(75, 23);
			this.buttonClear.TabIndex = 2;
			this.buttonClear.Text = "Wyczyść";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(321, 41);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Anuluj";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(240, 41);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 4;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			// 
			// GetShortCutKeyCode
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 76);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.textBoxKeyCode);
			this.Controls.Add(this.labelKeyCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "GetShortCutKeyCode";
			this.Text = "Ustaw klawisz skrótu";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GetShortCutKeyCode_FormClosed);
			this.Load += new System.EventHandler(this.GetShortCutKeyCode_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetShortCutKeyCode_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }        

        #endregion

        private System.Windows.Forms.Label labelKeyCode;
        private System.Windows.Forms.TextBox textBoxKeyCode;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}