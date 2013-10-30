namespace KeyFreak
{
	partial class CommandItem
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.KeyLabel = new System.Windows.Forms.Label();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Location = new System.Drawing.Point(2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// KeyLabel
			// 
			this.KeyLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.KeyLabel.Location = new System.Drawing.Point(584, 2);
			this.KeyLabel.Name = "KeyLabel";
			this.KeyLabel.Size = new System.Drawing.Size(116, 24);
			this.KeyLabel.TabIndex = 1;
			this.KeyLabel.Text = "key";
			this.KeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescriptionLabel.Location = new System.Drawing.Point(26, 2);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(558, 24);
			this.DescriptionLabel.TabIndex = 2;
			this.DescriptionLabel.Text = "label1";
			this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CommandItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.KeyLabel);
			this.Controls.Add(this.pictureBox1);
			this.Name = "CommandItem";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Size = new System.Drawing.Size(702, 28);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label KeyLabel;
		private System.Windows.Forms.Label DescriptionLabel;
	}
}
