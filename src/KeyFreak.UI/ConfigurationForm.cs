using KeyFreak.Base;
using KeyFreak.Tools;
using KeyFreak.UI.Configuration;
using KeyFreak.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KeyFreak.UI
{
	public partial class ConfigurationForm : Form
	{
		private ConfigCommand selectedCommand;
		private int? selectedCommandIndex;

		public IList<ConfigCommand> ConfigCommands { get; set; }
		private AppSettings settings;
		public AppSettings Settings
		{
			get { return settings; }
			set
			{
				settings = value;
				LoadSettings();
			}
		}

		public ConfigurationForm()
		{
			InitializeComponent();
			LoadAvailableCommandTypes();
			LoadConfiguration();
		}

		private void LoadSettings()
		{
			textBoxGlobalKey.Text = Settings.GlobalKey;
		}

		private void LoadAvailableCommandTypes()
		{
			commandTypeComboBox.DataSource = ConfigurationHelper.GetAvailableCommands();
		}

		private void LoadConfiguration()
		{
			ConfigCommands = ConfigurationHelper.GetConfigCommands();
			dataGridViewCommands.DataSource = ConfigCommands;
			SetParents();
		}

		private void SetParents()
		{
			var parents = ConfigCommands.Select(command => command.Id).ToList();
			parents.Insert(0, string.Empty);
			parentComboBox.DataSource = parents;
		}

		private void LoadControls()
		{
			idTextBox.Text = selectedCommand.Id;
			parentComboBox.SelectedItem = selectedCommand.Parent ?? string.Empty;
			commandTypeComboBox.SelectedItem = selectedCommand.CommandType;
			descriptionTextBox.Text = selectedCommand.Description ?? string.Empty;
			keyTextBox.Text = selectedCommand.Key;
			globalKeyTextBox.Text = selectedCommand.GlobalKey;

			SetIconPath(selectedCommand.IconPath);

			LoadParametrsControl();
		}

		private void SetIconPath(string iconPath)
		{
			iconPathTextBox.Text = iconPath;
			SetIconImage(iconPath);
		}

		private void SetIconImage(string iconPath)
		{
			try
			{
				pictureBoxIcon.Image = Image.FromFile(iconPath);
			}
			catch
			{
				pictureBoxIcon.Image = null;
			}
		}

		private void LoadParametrsControl()
		{
			if (commandParametersGroupBox.Controls.Count > 0)
			{
				((KeyCommandConfigurationControl)commandParametersGroupBox.Controls[0]).ParametersChanged -= OnParametersChanged;
			}

			KeyCommandConfigurationControl control = ConfigurationHelper
				.CreateCommandConfigurationControl(selectedCommand.CommandType);

			commandParametersGroupBox.Controls.Clear();
			if (control != null)
			{
				control.Dock = DockStyle.Fill;
				control.Parameters = selectedCommand.Parameters;
				control.ParametersChanged += OnParametersChanged;
				commandParametersGroupBox.Controls.Add(control);
			}
		}

		private void ChangeGridRowSelection(int newIndex)
		{
			if (dataGridViewCommands.SelectedRows.Count > 0)
			{
				try
				{
					dataGridViewCommands.Rows[dataGridViewCommands.SelectedRows[0].Index].Selected = false;
				}
				catch (IndexOutOfRangeException)
				{
				}
			}
			dataGridViewCommands.Rows[newIndex].Selected = true;
		}

		private void RefreshGrid()
		{
			dataGridViewCommands.DataSource = ConfigCommands.GetType();
			dataGridViewCommands.DataSource = ConfigCommands;
		}

		private void OnParametersChanged(object sender, EventArgs e)
		{
			selectedCommand.Parameters = ((KeyCommandConfigurationControl)sender).Parameters;
		}

		private static void ShowValidationError(string errorText)
		{
			MessageBox.Show(errorText, Resources.ConfigurationForm_ShowValidationError_Validation_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void idTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = !ValidateId();
		}

		private void keyTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = !ValidateKey();
		}

		private void parentComboBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = !ValidateParent();
		}

		private void commandTypeComboBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = !ValidateCommandType();
		}

		#region validations

		private bool ValidateAll()
		{
			if (!ValidateId())
				return false;

			if (!ValidateKey())
				return false;

			if (!ValidateCommandType())
				return false;

			if (!ValidateParent())
				return false;

			return true;
		}

		private bool ValidateId()
		{
			if (string.IsNullOrWhiteSpace(idTextBox.Text))
			{
				ShowValidationError("Id cannot be empty.");
				return false;
			}

			if (ConfigCommands.Any(configCommand => configCommand.Id == idTextBox.Text && !configCommand.Equals(selectedCommand)))
			{
				ShowValidationError("Other command, uses same Id.");
				return false;
			}

			return true;
		}

		private bool ValidateKey()
		{
			if (ConfigCommands
						 .Any(cc => cc.Parent == selectedCommand.Parent
							 && cc.Key == keyTextBox.Text
							 && !cc.Equals(selectedCommand)))
			{
				ShowValidationError("Other command with the same parent, uses same Key.");
				return false;
			}

			return true;
		}

		private bool ValidateCommandType()
		{
			if (commandTypeComboBox.SelectedItem == null
						 || string.IsNullOrWhiteSpace(commandTypeComboBox.SelectedItem.ToString()))
			{
				ShowValidationError("Command Type cannot be empty.");
				return false;
			}

			return true;
		}

		private bool ValidateParent()
		{
			string parent = string.Empty;
			if (parentComboBox.SelectedItem != null)
				parent = parentComboBox.SelectedItem.ToString().Trim();

			if (parent != string.Empty)
			{
				if (ConfigCommands != null && !ConfigCommands.Any(cc => cc.Id == parent))
				{
					ShowValidationError(String.Format("Cannot find command with id [{0}]", parent));
				}
			}

			return true;
		}

		#endregion validations

		private void idTextBox_Validated(object sender, EventArgs e)
		{
			if (!String.IsNullOrWhiteSpace(selectedCommand.Id))
			{
				foreach (var command in ConfigCommands.Where(cmd => cmd.Parent == selectedCommand.Id))
					command.Parent = idTextBox.Text;
			}
			selectedCommand.Id = idTextBox.Text;
			SetParents();
		}

		private void iconPathTextBox_Validated(object sender, EventArgs e)
		{
			SetIconImage(iconPathTextBox.Text);
			selectedCommand.IconPath = iconPathTextBox.Text;
		}

		private void keyTextBox_Validated(object sender, EventArgs e)
		{
			selectedCommand.Key = keyTextBox.Text;
		}

		private void descriptionTextBox_Validated(object sender, EventArgs e)
		{
			selectedCommand.Description = descriptionTextBox.Text;
		}

		private void commandTypeComboBox_Validated(object sender, EventArgs e)
		{
			selectedCommand.CommandType = commandTypeComboBox.SelectedItem.ToString();
			selectedCommand.Parameters = String.Empty;
			LoadParametrsControl();
		}

		private void keyTextBox_TextChanged(object sender, EventArgs e)
		{
			if (keyTextBox.Text.Length > 0)
			{
				keyTextBox.TextChanged -= keyTextBox_TextChanged;
				keyTextBox.Text = keyTextBox.Text.Substring(0, 1).ToUpper();
				keyTextBox.TextChanged += keyTextBox_TextChanged;
			}
		}

		private void dataGridViewCommands_SelectionChanged(object sender, EventArgs e)
		{
			if (selectedCommandIndex != null)
			{
				if (!ValidateAll())
				{
					dataGridViewCommands.SelectionChanged -= dataGridViewCommands_SelectionChanged;
					ChangeGridRowSelection(selectedCommandIndex.Value);
					dataGridViewCommands.SelectionChanged += dataGridViewCommands_SelectionChanged;
				}
			}

			if (dataGridViewCommands.SelectedRows.Count > 0)
			{
				selectedCommand = ConfigCommands[dataGridViewCommands.SelectedRows[0].Index];
				selectedCommandIndex = dataGridViewCommands.SelectedRows[0].Index;
				LoadControls();
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			ConfigCommands.Add(new ConfigCommand());
			RefreshGrid();
			ChangeGridRowSelection(dataGridViewCommands.Rows.Count - 1);
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (selectedCommandIndex != null && selectedCommand != null)
			{
				ConfigCommands.Remove(selectedCommand);
				selectedCommand = null;

				var oldIndex = selectedCommandIndex.Value;
				selectedCommandIndex = null;
				if (oldIndex > ConfigCommands.Count - 1)
				{
					ChangeGridRowSelection(oldIndex - 1);
				}
				else
				{
					ChangeGridRowSelection(oldIndex);
				}
				RefreshGrid();
			}
		}

		private void buttonUp_Click(object sender, EventArgs e)
		{
			if (dataGridViewCommands.SelectedRows.Count > 0
				&& dataGridViewCommands.SelectedRows[0].Index > 0)
			{
				int selectedIndex = dataGridViewCommands.SelectedRows[0].Index;
				ConfigCommand tempCommand = ConfigCommands[selectedIndex - 1];
				ConfigCommands[selectedIndex - 1] = selectedCommand;
				ConfigCommands[selectedIndex] = tempCommand;
				ChangeGridRowSelection(selectedIndex - 1);
			}
		}

		private void buttonDown_Click(object sender, EventArgs e)
		{
			if (dataGridViewCommands.SelectedRows.Count > 0
				&& dataGridViewCommands.SelectedRows[0].Index < dataGridViewCommands.Rows.Count - 1)
			{
				int selectedIndex = dataGridViewCommands.SelectedRows[0].Index;
				ConfigCommand tempCommand = ConfigCommands[selectedIndex + 1];
				ConfigCommands[selectedIndex + 1] = selectedCommand;
				ConfigCommands[selectedIndex] = tempCommand;
				ChangeGridRowSelection(selectedIndex + 1);
			}
		}

		private void iconBrowseButton_Click(object sender, EventArgs e)
		{
			if (iconPathFileDialog.ShowDialog() == DialogResult.OK)
			{
				SetIconPath(iconPathFileDialog.FileName);
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (ValidateAll())
				DialogResult = DialogResult.OK;
		}

		private void parentComboBox_Validated(object sender, EventArgs e)
		{
			selectedCommand.Parent = parentComboBox.SelectedItem != null
				? parentComboBox.SelectedItem.ToString()
				: String.Empty;
		}

		private void buttonGetGlobalKey_Click(object sender, EventArgs e)
		{
			var getShortCutKeyCode = new GetShortCutKeyCode();
			getShortCutKeyCode.ShortCut = KeysHelper.GetKeyCombination(textBoxGlobalKey.Text);
			if (getShortCutKeyCode.ShowDialog() == DialogResult.OK)
			{
				textBoxGlobalKey.Text = getShortCutKeyCode.ShortCut.ToString();
				settings.GlobalKey = textBoxGlobalKey.Text;
			}
		}

		private void ConfigurationForm_Load(object sender, EventArgs e)
		{
			if (dataGridViewCommands.Rows.Count > 0)
				dataGridViewCommands.Rows[0].Selected = true;
		}

		private void globalKeyButton_Click(object sender, EventArgs e)
		{
			var getShortCutKeyCode = new GetShortCutKeyCode();
			getShortCutKeyCode.ShortCut = KeysHelper.GetKeyCombination(globalKeyTextBox.Text);
			if (getShortCutKeyCode.ShowDialog() == DialogResult.OK)
			{
				globalKeyTextBox.Text = getShortCutKeyCode.ShortCut.ToString();
				selectedCommand.GlobalKey = globalKeyTextBox.Text;
			}
		}
	}
}