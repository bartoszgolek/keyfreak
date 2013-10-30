namespace KeyFreak.Commands
{
	partial class ShellCommandConfigurationControl
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
			this.commandParamatersLabel = new System.Windows.Forms.Label();
			this.commandParamatersTextBox = new System.Windows.Forms.TextBox();
			this.commandPathLabel = new System.Windows.Forms.Label();
			this.commandPathTextBox = new System.Windows.Forms.TextBox();
			this.browseCommandButton = new System.Windows.Forms.Button();
			this.browseCommandDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// commandParamatersLabel
			// 
			this.commandParamatersLabel.AutoSize = true;
			this.commandParamatersLabel.Location = new System.Drawing.Point(3, 38);
			this.commandParamatersLabel.Name = "commandParamatersLabel";
			this.commandParamatersLabel.Size = new System.Drawing.Size(113, 13);
			this.commandParamatersLabel.TabIndex = 14;
			this.commandParamatersLabel.Text = "Command Parameters:";
			// 
			// commandParamatersTextBox
			// 
			this.commandParamatersTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.commandParamatersTextBox.Location = new System.Drawing.Point(122, 35);
			this.commandParamatersTextBox.Name = "commandParamatersTextBox";
			this.commandParamatersTextBox.Size = new System.Drawing.Size(272, 20);
			this.commandParamatersTextBox.TabIndex = 13;
			this.commandParamatersTextBox.Leave += new System.EventHandler(this.OnLeave);
			// 
			// commandPathLabel
			// 
			this.commandPathLabel.AutoSize = true;
			this.commandPathLabel.Location = new System.Drawing.Point(34, 11);
			this.commandPathLabel.Name = "commandPathLabel";
			this.commandPathLabel.Size = new System.Drawing.Size(82, 13);
			this.commandPathLabel.TabIndex = 12;
			this.commandPathLabel.Text = "Shell command:";
			// 
			// commandPathTextBox
			// 
			this.commandPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.commandPathTextBox.Location = new System.Drawing.Point(122, 8);
			this.commandPathTextBox.Name = "commandPathTextBox";
			this.commandPathTextBox.Size = new System.Drawing.Size(238, 20);
			this.commandPathTextBox.TabIndex = 11;
			this.commandPathTextBox.Leave += new System.EventHandler(this.OnLeave);
			// 
			// browseCommandButton
			// 
			this.browseCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseCommandButton.Location = new System.Drawing.Point(366, 6);
			this.browseCommandButton.Name = "browseCommandButton";
			this.browseCommandButton.Size = new System.Drawing.Size(28, 23);
			this.browseCommandButton.TabIndex = 10;
			this.browseCommandButton.Text = "...";
			this.browseCommandButton.UseVisualStyleBackColor = true;
			this.browseCommandButton.Click += new System.EventHandler(this.browseCommandButton_Click);
			// 
			// browseCommandDialog
			// 
			this.browseCommandDialog.Filter = "Executables (*.exe)|*.exe";
			this.browseCommandDialog.Title = "Find Command";
			// 
			// ShellCommandConfigurationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.commandParamatersLabel);
			this.Controls.Add(this.commandParamatersTextBox);
			this.Controls.Add(this.commandPathLabel);
			this.Controls.Add(this.commandPathTextBox);
			this.Controls.Add(this.browseCommandButton);
			this.Name = "ShellCommandConfigurationControl";
			this.Size = new System.Drawing.Size(397, 64);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label commandParamatersLabel;
		private System.Windows.Forms.TextBox commandParamatersTextBox;
		private System.Windows.Forms.Label commandPathLabel;
		private System.Windows.Forms.TextBox commandPathTextBox;
		private System.Windows.Forms.Button browseCommandButton;
		private System.Windows.Forms.OpenFileDialog browseCommandDialog;
	}
}
