namespace KeyFreak.UI
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
			this.CurrentKeyCombination = new System.Windows.Forms.Label();
			this.commandsList1 = new KeyFreak.CommandsList();
			this.SuspendLayout();
			// 
			// CurrentKeyCombination
			// 
			this.CurrentKeyCombination.Dock = System.Windows.Forms.DockStyle.Top;
			this.CurrentKeyCombination.Location = new System.Drawing.Point(0, 0);
			this.CurrentKeyCombination.Name = "CurrentKeyCombination";
			this.CurrentKeyCombination.Size = new System.Drawing.Size(838, 29);
			this.CurrentKeyCombination.TabIndex = 0;
			this.CurrentKeyCombination.Text = "Current combination";
			this.CurrentKeyCombination.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// commandsList1
			// 
			this.commandsList1.Dock = System.Windows.Forms.DockStyle.Top;
			this.commandsList1.Location = new System.Drawing.Point(0, 29);
			this.commandsList1.Name = "commandsList1";
			this.commandsList1.Size = new System.Drawing.Size(838, 160);
			this.commandsList1.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(838, 188);
			this.Controls.Add(this.commandsList1);
			this.Controls.Add(this.CurrentKeyCombination);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label CurrentKeyCombination;
		private CommandsList commandsList1;
	}
}

