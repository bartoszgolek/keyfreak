namespace KeyFreak.UI
{
	partial class ConfigurationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
			this.splitContainerHorizontal = new System.Windows.Forms.SplitContainer();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonDown = new System.Windows.Forms.Button();
			this.buttonUp = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.dataGridViewCommands = new System.Windows.Forms.DataGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.iconPathLabel = new System.Windows.Forms.Label();
			this.iconPathTextBox = new System.Windows.Forms.TextBox();
			this.iconBrowseButton = new System.Windows.Forms.Button();
			this.keyLabel = new System.Windows.Forms.Label();
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.commandTypeLabel = new System.Windows.Forms.Label();
			this.parentLabel = new System.Windows.Forms.Label();
			this.IdLabel = new System.Windows.Forms.Label();
			this.keyTextBox = new System.Windows.Forms.TextBox();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.commandTypeComboBox = new System.Windows.Forms.ComboBox();
			this.parentComboBox = new System.Windows.Forms.ComboBox();
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.commandParametersGroupBox = new System.Windows.Forms.GroupBox();
			this.iconPathFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tabControlConfiguration = new System.Windows.Forms.TabControl();
			this.tabPageConfiguration = new System.Windows.Forms.TabPage();
			this.groupBoxGlobalKey = new System.Windows.Forms.GroupBox();
			this.labelGlobalKey = new System.Windows.Forms.Label();
			this.textBoxGlobalKey = new System.Windows.Forms.TextBox();
			this.buttonGetGlobalKey = new System.Windows.Forms.Button();
			this.tabPageCommands = new System.Windows.Forms.TabPage();
			this.globalKeyButton = new System.Windows.Forms.Button();
			this.globalKeyTextBox = new System.Windows.Forms.TextBox();
			this.globalKeyLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).BeginInit();
			this.splitContainerHorizontal.Panel1.SuspendLayout();
			this.splitContainerHorizontal.Panel2.SuspendLayout();
			this.splitContainerHorizontal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.panelButtons.SuspendLayout();
			this.tabControlConfiguration.SuspendLayout();
			this.tabPageConfiguration.SuspendLayout();
			this.groupBoxGlobalKey.SuspendLayout();
			this.tabPageCommands.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainerHorizontal
			// 
			this.splitContainerHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerHorizontal.Location = new System.Drawing.Point(3, 3);
			this.splitContainerHorizontal.Name = "splitContainerHorizontal";
			this.splitContainerHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerHorizontal.Panel1
			// 
			this.splitContainerHorizontal.Panel1.Controls.Add(this.splitContainer1);
			// 
			// splitContainerHorizontal.Panel2
			// 
			this.splitContainerHorizontal.Panel2.Controls.Add(this.commandParametersGroupBox);
			this.splitContainerHorizontal.Size = new System.Drawing.Size(830, 418);
			this.splitContainerHorizontal.SplitterDistance = 313;
			this.splitContainerHorizontal.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(830, 313);
			this.splitContainer1.SplitterDistance = 429;
			this.splitContainer1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.dataGridViewCommands);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(429, 313);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Commands";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonDown);
			this.panel1.Controls.Add(this.buttonUp);
			this.panel1.Controls.Add(this.buttonDelete);
			this.panel1.Controls.Add(this.buttonAdd);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 278);
			this.panel1.MaximumSize = new System.Drawing.Size(9999, 32);
			this.panel1.MinimumSize = new System.Drawing.Size(331, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(423, 32);
			this.panel1.TabIndex = 1;
			// 
			// buttonDown
			// 
			this.buttonDown.Location = new System.Drawing.Point(252, 3);
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.Size = new System.Drawing.Size(75, 23);
			this.buttonDown.TabIndex = 3;
			this.buttonDown.Text = "Down";
			this.buttonDown.UseVisualStyleBackColor = true;
			this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
			// 
			// buttonUp
			// 
			this.buttonUp.Location = new System.Drawing.Point(171, 3);
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.Size = new System.Drawing.Size(75, 23);
			this.buttonUp.TabIndex = 2;
			this.buttonUp.Text = "Up";
			this.buttonUp.UseVisualStyleBackColor = true;
			this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(90, 3);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(75, 23);
			this.buttonDelete.TabIndex = 1;
			this.buttonDelete.Text = "Remove";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(9, 3);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 0;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// dataGridViewCommands
			// 
			this.dataGridViewCommands.AllowUserToAddRows = false;
			this.dataGridViewCommands.AllowUserToDeleteRows = false;
			this.dataGridViewCommands.AllowUserToResizeRows = false;
			this.dataGridViewCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewCommands.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewCommands.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewCommands.Name = "dataGridViewCommands";
			this.dataGridViewCommands.ReadOnly = true;
			this.dataGridViewCommands.RowHeadersVisible = false;
			this.dataGridViewCommands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewCommands.Size = new System.Drawing.Size(423, 294);
			this.dataGridViewCommands.TabIndex = 0;
			this.dataGridViewCommands.SelectionChanged += new System.EventHandler(this.dataGridViewCommands_SelectionChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.globalKeyLabel);
			this.groupBox2.Controls.Add(this.globalKeyTextBox);
			this.groupBox2.Controls.Add(this.globalKeyButton);
			this.groupBox2.Controls.Add(this.pictureBoxIcon);
			this.groupBox2.Controls.Add(this.iconPathLabel);
			this.groupBox2.Controls.Add(this.iconPathTextBox);
			this.groupBox2.Controls.Add(this.iconBrowseButton);
			this.groupBox2.Controls.Add(this.keyLabel);
			this.groupBox2.Controls.Add(this.descriptionLabel);
			this.groupBox2.Controls.Add(this.commandTypeLabel);
			this.groupBox2.Controls.Add(this.parentLabel);
			this.groupBox2.Controls.Add(this.IdLabel);
			this.groupBox2.Controls.Add(this.keyTextBox);
			this.groupBox2.Controls.Add(this.descriptionTextBox);
			this.groupBox2.Controls.Add(this.commandTypeComboBox);
			this.groupBox2.Controls.Add(this.parentComboBox);
			this.groupBox2.Controls.Add(this.idTextBox);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(397, 313);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Command Configuration";
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxIcon.Location = new System.Drawing.Point(327, 150);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(24, 24);
			this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxIcon.TabIndex = 13;
			this.pictureBoxIcon.TabStop = false;
			// 
			// iconPathLabel
			// 
			this.iconPathLabel.AutoSize = true;
			this.iconPathLabel.Location = new System.Drawing.Point(59, 156);
			this.iconPathLabel.Name = "iconPathLabel";
			this.iconPathLabel.Size = new System.Drawing.Size(31, 13);
			this.iconPathLabel.TabIndex = 12;
			this.iconPathLabel.Text = "Icon:";
			// 
			// iconPathTextBox
			// 
			this.iconPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPathTextBox.Location = new System.Drawing.Point(96, 153);
			this.iconPathTextBox.Name = "iconPathTextBox";
			this.iconPathTextBox.Size = new System.Drawing.Size(225, 20);
			this.iconPathTextBox.TabIndex = 11;
			this.iconPathTextBox.Validated += new System.EventHandler(this.iconPathTextBox_Validated);
			// 
			// iconBrowseButton
			// 
			this.iconBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconBrowseButton.Location = new System.Drawing.Point(357, 151);
			this.iconBrowseButton.Name = "iconBrowseButton";
			this.iconBrowseButton.Size = new System.Drawing.Size(28, 23);
			this.iconBrowseButton.TabIndex = 10;
			this.iconBrowseButton.Text = "...";
			this.iconBrowseButton.UseVisualStyleBackColor = true;
			this.iconBrowseButton.Click += new System.EventHandler(this.iconBrowseButton_Click);
			// 
			// keyLabel
			// 
			this.keyLabel.AutoSize = true;
			this.keyLabel.Location = new System.Drawing.Point(62, 128);
			this.keyLabel.Name = "keyLabel";
			this.keyLabel.Size = new System.Drawing.Size(28, 13);
			this.keyLabel.TabIndex = 9;
			this.keyLabel.Text = "Key:";
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.AutoSize = true;
			this.descriptionLabel.Location = new System.Drawing.Point(27, 102);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
			this.descriptionLabel.TabIndex = 8;
			this.descriptionLabel.Text = "Description:";
			// 
			// commandTypeLabel
			// 
			this.commandTypeLabel.AutoSize = true;
			this.commandTypeLabel.Location = new System.Drawing.Point(6, 75);
			this.commandTypeLabel.Name = "commandTypeLabel";
			this.commandTypeLabel.Size = new System.Drawing.Size(84, 13);
			this.commandTypeLabel.TabIndex = 7;
			this.commandTypeLabel.Text = "Command Type:";
			// 
			// parentLabel
			// 
			this.parentLabel.AutoSize = true;
			this.parentLabel.Location = new System.Drawing.Point(49, 48);
			this.parentLabel.Name = "parentLabel";
			this.parentLabel.Size = new System.Drawing.Size(41, 13);
			this.parentLabel.TabIndex = 6;
			this.parentLabel.Text = "Parent:";
			// 
			// IdLabel
			// 
			this.IdLabel.AutoSize = true;
			this.IdLabel.Location = new System.Drawing.Point(69, 22);
			this.IdLabel.Name = "IdLabel";
			this.IdLabel.Size = new System.Drawing.Size(21, 13);
			this.IdLabel.TabIndex = 5;
			this.IdLabel.Text = "ID:";
			// 
			// keyTextBox
			// 
			this.keyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.keyTextBox.Location = new System.Drawing.Point(96, 125);
			this.keyTextBox.Name = "keyTextBox";
			this.keyTextBox.Size = new System.Drawing.Size(289, 20);
			this.keyTextBox.TabIndex = 4;
			this.keyTextBox.TextChanged += new System.EventHandler(this.keyTextBox_TextChanged);
			this.keyTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.keyTextBox_Validating);
			this.keyTextBox.Validated += new System.EventHandler(this.keyTextBox_Validated);
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionTextBox.Location = new System.Drawing.Point(96, 99);
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.Size = new System.Drawing.Size(289, 20);
			this.descriptionTextBox.TabIndex = 3;
			this.descriptionTextBox.Validated += new System.EventHandler(this.descriptionTextBox_Validated);
			// 
			// commandTypeComboBox
			// 
			this.commandTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.commandTypeComboBox.FormattingEnabled = true;
			this.commandTypeComboBox.Location = new System.Drawing.Point(96, 72);
			this.commandTypeComboBox.Name = "commandTypeComboBox";
			this.commandTypeComboBox.Size = new System.Drawing.Size(289, 21);
			this.commandTypeComboBox.TabIndex = 2;
			this.commandTypeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.commandTypeComboBox_Validating);
			this.commandTypeComboBox.Validated += new System.EventHandler(this.commandTypeComboBox_Validated);
			// 
			// parentComboBox
			// 
			this.parentComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.parentComboBox.FormattingEnabled = true;
			this.parentComboBox.Location = new System.Drawing.Point(96, 45);
			this.parentComboBox.Name = "parentComboBox";
			this.parentComboBox.Size = new System.Drawing.Size(289, 21);
			this.parentComboBox.TabIndex = 1;
			this.parentComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.parentComboBox_Validating);
			this.parentComboBox.Validated += new System.EventHandler(this.parentComboBox_Validated);
			// 
			// idTextBox
			// 
			this.idTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.idTextBox.Location = new System.Drawing.Point(96, 19);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.Size = new System.Drawing.Size(289, 20);
			this.idTextBox.TabIndex = 0;
			this.idTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.idTextBox_Validating);
			this.idTextBox.Validated += new System.EventHandler(this.idTextBox_Validated);
			// 
			// commandParametersGroupBox
			// 
			this.commandParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commandParametersGroupBox.Location = new System.Drawing.Point(0, 0);
			this.commandParametersGroupBox.Name = "commandParametersGroupBox";
			this.commandParametersGroupBox.Size = new System.Drawing.Size(830, 101);
			this.commandParametersGroupBox.TabIndex = 0;
			this.commandParametersGroupBox.TabStop = false;
			this.commandParametersGroupBox.Text = "Cammand parameters";
			// 
			// iconPathFileDialog
			// 
			this.iconPathFileDialog.FileName = "openFileDialog1";
			this.iconPathFileDialog.Filter = "Images|*.jpg;*.jpeg;*.png;*.gif";
			this.iconPathFileDialog.Title = "Find image";
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.buttonSave);
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.Location = new System.Drawing.Point(0, 450);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(844, 32);
			this.panelButtons.TabIndex = 0;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(676, 6);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(757, 6);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// tabControlConfiguration
			// 
			this.tabControlConfiguration.Controls.Add(this.tabPageConfiguration);
			this.tabControlConfiguration.Controls.Add(this.tabPageCommands);
			this.tabControlConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlConfiguration.Location = new System.Drawing.Point(0, 0);
			this.tabControlConfiguration.Name = "tabControlConfiguration";
			this.tabControlConfiguration.SelectedIndex = 0;
			this.tabControlConfiguration.Size = new System.Drawing.Size(844, 450);
			this.tabControlConfiguration.TabIndex = 1;
			// 
			// tabPageConfiguration
			// 
			this.tabPageConfiguration.Controls.Add(this.groupBoxGlobalKey);
			this.tabPageConfiguration.Location = new System.Drawing.Point(4, 22);
			this.tabPageConfiguration.Name = "tabPageConfiguration";
			this.tabPageConfiguration.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageConfiguration.Size = new System.Drawing.Size(836, 424);
			this.tabPageConfiguration.TabIndex = 0;
			this.tabPageConfiguration.Text = "Configuration";
			this.tabPageConfiguration.UseVisualStyleBackColor = true;
			// 
			// groupBoxGlobalKey
			// 
			this.groupBoxGlobalKey.Controls.Add(this.labelGlobalKey);
			this.groupBoxGlobalKey.Controls.Add(this.textBoxGlobalKey);
			this.groupBoxGlobalKey.Controls.Add(this.buttonGetGlobalKey);
			this.groupBoxGlobalKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxGlobalKey.Location = new System.Drawing.Point(3, 3);
			this.groupBoxGlobalKey.Name = "groupBoxGlobalKey";
			this.groupBoxGlobalKey.Size = new System.Drawing.Size(830, 418);
			this.groupBoxGlobalKey.TabIndex = 0;
			this.groupBoxGlobalKey.TabStop = false;
			this.groupBoxGlobalKey.Text = "Global Key";
			// 
			// labelGlobalKey
			// 
			this.labelGlobalKey.AutoSize = true;
			this.labelGlobalKey.Location = new System.Drawing.Point(6, 24);
			this.labelGlobalKey.Name = "labelGlobalKey";
			this.labelGlobalKey.Size = new System.Drawing.Size(60, 13);
			this.labelGlobalKey.TabIndex = 2;
			this.labelGlobalKey.Text = "Global key:";
			// 
			// textBoxGlobalKey
			// 
			this.textBoxGlobalKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGlobalKey.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxGlobalKey.Enabled = false;
			this.textBoxGlobalKey.Location = new System.Drawing.Point(72, 21);
			this.textBoxGlobalKey.Name = "textBoxGlobalKey";
			this.textBoxGlobalKey.Size = new System.Drawing.Size(719, 20);
			this.textBoxGlobalKey.TabIndex = 1;
			// 
			// buttonGetGlobalKey
			// 
			this.buttonGetGlobalKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGetGlobalKey.Location = new System.Drawing.Point(797, 19);
			this.buttonGetGlobalKey.Name = "buttonGetGlobalKey";
			this.buttonGetGlobalKey.Size = new System.Drawing.Size(27, 23);
			this.buttonGetGlobalKey.TabIndex = 0;
			this.buttonGetGlobalKey.Text = "...";
			this.buttonGetGlobalKey.UseVisualStyleBackColor = true;
			this.buttonGetGlobalKey.Click += new System.EventHandler(this.buttonGetGlobalKey_Click);
			// 
			// tabPageCommands
			// 
			this.tabPageCommands.Controls.Add(this.splitContainerHorizontal);
			this.tabPageCommands.Location = new System.Drawing.Point(4, 22);
			this.tabPageCommands.Name = "tabPageCommands";
			this.tabPageCommands.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCommands.Size = new System.Drawing.Size(836, 424);
			this.tabPageCommands.TabIndex = 1;
			this.tabPageCommands.Text = "Commands";
			this.tabPageCommands.UseVisualStyleBackColor = true;
			// 
			// globalKeyButton
			// 
			this.globalKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.globalKeyButton.Location = new System.Drawing.Point(357, 176);
			this.globalKeyButton.Name = "globalKeyButton";
			this.globalKeyButton.Size = new System.Drawing.Size(28, 23);
			this.globalKeyButton.TabIndex = 14;
			this.globalKeyButton.Text = "...";
			this.globalKeyButton.UseVisualStyleBackColor = true;
			this.globalKeyButton.Click += new System.EventHandler(this.globalKeyButton_Click);
			// 
			// globalKeyTextBox
			// 
			this.globalKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.globalKeyTextBox.Enabled = false;
			this.globalKeyTextBox.Location = new System.Drawing.Point(96, 179);
			this.globalKeyTextBox.Name = "globalKeyTextBox";
			this.globalKeyTextBox.Size = new System.Drawing.Size(255, 20);
			this.globalKeyTextBox.TabIndex = 15;
			// 
			// globalKeyLabel
			// 
			this.globalKeyLabel.AutoSize = true;
			this.globalKeyLabel.Location = new System.Drawing.Point(29, 181);
			this.globalKeyLabel.Name = "globalKeyLabel";
			this.globalKeyLabel.Size = new System.Drawing.Size(61, 13);
			this.globalKeyLabel.TabIndex = 16;
			this.globalKeyLabel.Text = "Global Key:";
			// 
			// ConfigurationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(844, 482);
			this.Controls.Add(this.tabControlConfiguration);
			this.Controls.Add(this.panelButtons);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConfigurationForm";
			this.Text = "KeyFreak Configuration";
			this.Load += new System.EventHandler(this.ConfigurationForm_Load);
			this.splitContainerHorizontal.Panel1.ResumeLayout(false);
			this.splitContainerHorizontal.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).EndInit();
			this.splitContainerHorizontal.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.panelButtons.ResumeLayout(false);
			this.tabControlConfiguration.ResumeLayout(false);
			this.tabPageConfiguration.ResumeLayout(false);
			this.groupBoxGlobalKey.ResumeLayout(false);
			this.groupBoxGlobalKey.PerformLayout();
			this.tabPageCommands.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainerHorizontal;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonDown;
		private System.Windows.Forms.Button buttonUp;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.DataGridView dataGridViewCommands;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox commandParametersGroupBox;
		private System.Windows.Forms.OpenFileDialog iconPathFileDialog;
		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.ComboBox parentComboBox;
		private System.Windows.Forms.ComboBox commandTypeComboBox;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.TextBox keyTextBox;
		private System.Windows.Forms.Label keyLabel;
		private System.Windows.Forms.Label descriptionLabel;
		private System.Windows.Forms.Label commandTypeLabel;
		private System.Windows.Forms.Label parentLabel;
		private System.Windows.Forms.Label IdLabel;
		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.Label iconPathLabel;
		private System.Windows.Forms.TextBox iconPathTextBox;
		private System.Windows.Forms.Button iconBrowseButton;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TabControl tabControlConfiguration;
		private System.Windows.Forms.TabPage tabPageConfiguration;
		private System.Windows.Forms.GroupBox groupBoxGlobalKey;
		private System.Windows.Forms.Label labelGlobalKey;
		private System.Windows.Forms.TextBox textBoxGlobalKey;
		private System.Windows.Forms.Button buttonGetGlobalKey;
		private System.Windows.Forms.TabPage tabPageCommands;
		private System.Windows.Forms.Label globalKeyLabel;
		private System.Windows.Forms.TextBox globalKeyTextBox;
		private System.Windows.Forms.Button globalKeyButton;
	}
}