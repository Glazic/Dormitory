namespace Dormitory
{
	partial class BackupForm
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
			this.connectButton = new System.Windows.Forms.Button();
			this.databasesComboBox = new System.Windows.Forms.ComboBox();
			this.backupFileTextBox = new System.Windows.Forms.TextBox();
			this.restoreFileTextBox = new System.Windows.Forms.TextBox();
			this.dataSourceTextBox = new System.Windows.Forms.TextBox();
			this.loginTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.disconnectButton = new System.Windows.Forms.Button();
			this.backupButton = new System.Windows.Forms.Button();
			this.restoreButton = new System.Windows.Forms.Button();
			this.browseBackupButton = new System.Windows.Forms.Button();
			this.browseRestoreButton = new System.Windows.Forms.Button();
			this.browseSqlScriptButton = new System.Windows.Forms.Button();
			this.sqlScriptFileTextBox = new System.Windows.Forms.TextBox();
			this.runSqlScriptButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(251, 12);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(75, 23);
			this.connectButton.TabIndex = 0;
			this.connectButton.Text = "con";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// databasesComboBox
			// 
			this.databasesComboBox.FormattingEnabled = true;
			this.databasesComboBox.Location = new System.Drawing.Point(12, 67);
			this.databasesComboBox.Name = "databasesComboBox";
			this.databasesComboBox.Size = new System.Drawing.Size(121, 21);
			this.databasesComboBox.TabIndex = 1;
			// 
			// backupFileTextBox
			// 
			this.backupFileTextBox.Location = new System.Drawing.Point(12, 94);
			this.backupFileTextBox.Name = "backupFileTextBox";
			this.backupFileTextBox.Size = new System.Drawing.Size(100, 20);
			this.backupFileTextBox.TabIndex = 2;
			// 
			// restoreFileTextBox
			// 
			this.restoreFileTextBox.Location = new System.Drawing.Point(12, 127);
			this.restoreFileTextBox.Name = "restoreFileTextBox";
			this.restoreFileTextBox.Size = new System.Drawing.Size(100, 20);
			this.restoreFileTextBox.TabIndex = 3;
			// 
			// dataSourceTextBox
			// 
			this.dataSourceTextBox.Location = new System.Drawing.Point(12, 12);
			this.dataSourceTextBox.Name = "dataSourceTextBox";
			this.dataSourceTextBox.Size = new System.Drawing.Size(233, 20);
			this.dataSourceTextBox.TabIndex = 4;
			// 
			// loginTextBox
			// 
			this.loginTextBox.Location = new System.Drawing.Point(12, 41);
			this.loginTextBox.Name = "loginTextBox";
			this.loginTextBox.Size = new System.Drawing.Size(100, 20);
			this.loginTextBox.TabIndex = 5;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(128, 38);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
			this.passwordTextBox.TabIndex = 6;
			// 
			// disconnectButton
			// 
			this.disconnectButton.Enabled = false;
			this.disconnectButton.Location = new System.Drawing.Point(251, 41);
			this.disconnectButton.Name = "disconnectButton";
			this.disconnectButton.Size = new System.Drawing.Size(75, 23);
			this.disconnectButton.TabIndex = 7;
			this.disconnectButton.Text = "disc";
			this.disconnectButton.UseVisualStyleBackColor = true;
			// 
			// backupButton
			// 
			this.backupButton.Enabled = false;
			this.backupButton.Location = new System.Drawing.Point(160, 92);
			this.backupButton.Name = "backupButton";
			this.backupButton.Size = new System.Drawing.Size(75, 23);
			this.backupButton.TabIndex = 8;
			this.backupButton.Text = "backup";
			this.backupButton.UseVisualStyleBackColor = true;
			this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
			// 
			// restoreButton
			// 
			this.restoreButton.Enabled = false;
			this.restoreButton.Location = new System.Drawing.Point(160, 122);
			this.restoreButton.Name = "restoreButton";
			this.restoreButton.Size = new System.Drawing.Size(75, 23);
			this.restoreButton.TabIndex = 9;
			this.restoreButton.Text = "restore";
			this.restoreButton.UseVisualStyleBackColor = true;
			this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
			// 
			// browseBackupButton
			// 
			this.browseBackupButton.Location = new System.Drawing.Point(251, 92);
			this.browseBackupButton.Name = "browseBackupButton";
			this.browseBackupButton.Size = new System.Drawing.Size(75, 23);
			this.browseBackupButton.TabIndex = 10;
			this.browseBackupButton.Text = "browse";
			this.browseBackupButton.UseVisualStyleBackColor = true;
			this.browseBackupButton.Click += new System.EventHandler(this.browseBackupButton_Click);
			// 
			// browseRestoreButton
			// 
			this.browseRestoreButton.Location = new System.Drawing.Point(251, 121);
			this.browseRestoreButton.Name = "browseRestoreButton";
			this.browseRestoreButton.Size = new System.Drawing.Size(75, 23);
			this.browseRestoreButton.TabIndex = 11;
			this.browseRestoreButton.Text = "browse";
			this.browseRestoreButton.UseVisualStyleBackColor = true;
			this.browseRestoreButton.Click += new System.EventHandler(this.browseRestoreButton_Click);
			// 
			// browseSqlScriptButton
			// 
			this.browseSqlScriptButton.Location = new System.Drawing.Point(251, 195);
			this.browseSqlScriptButton.Name = "browseSqlScriptButton";
			this.browseSqlScriptButton.Size = new System.Drawing.Size(75, 23);
			this.browseSqlScriptButton.TabIndex = 12;
			this.browseSqlScriptButton.Text = "browse sql";
			this.browseSqlScriptButton.UseVisualStyleBackColor = true;
			this.browseSqlScriptButton.Click += new System.EventHandler(this.browseSqlScriptButton_Click);
			// 
			// sqlScriptFileTextBox
			// 
			this.sqlScriptFileTextBox.Location = new System.Drawing.Point(12, 195);
			this.sqlScriptFileTextBox.Name = "sqlScriptFileTextBox";
			this.sqlScriptFileTextBox.Size = new System.Drawing.Size(100, 20);
			this.sqlScriptFileTextBox.TabIndex = 13;
			// 
			// runSqlScriptButton
			// 
			this.runSqlScriptButton.Location = new System.Drawing.Point(160, 195);
			this.runSqlScriptButton.Name = "runSqlScriptButton";
			this.runSqlScriptButton.Size = new System.Drawing.Size(75, 23);
			this.runSqlScriptButton.TabIndex = 14;
			this.runSqlScriptButton.Text = "run sql";
			this.runSqlScriptButton.UseVisualStyleBackColor = true;
			this.runSqlScriptButton.Click += new System.EventHandler(this.runSqlScriptButton_Click);
			// 
			// BackupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.runSqlScriptButton);
			this.Controls.Add(this.sqlScriptFileTextBox);
			this.Controls.Add(this.browseSqlScriptButton);
			this.Controls.Add(this.browseRestoreButton);
			this.Controls.Add(this.browseBackupButton);
			this.Controls.Add(this.restoreButton);
			this.Controls.Add(this.backupButton);
			this.Controls.Add(this.disconnectButton);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.loginTextBox);
			this.Controls.Add(this.dataSourceTextBox);
			this.Controls.Add(this.restoreFileTextBox);
			this.Controls.Add(this.backupFileTextBox);
			this.Controls.Add(this.databasesComboBox);
			this.Controls.Add(this.connectButton);
			this.Name = "BackupForm";
			this.Text = "BackupForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.ComboBox databasesComboBox;
		private System.Windows.Forms.TextBox backupFileTextBox;
		private System.Windows.Forms.TextBox restoreFileTextBox;
		private System.Windows.Forms.TextBox dataSourceTextBox;
		private System.Windows.Forms.TextBox loginTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Button disconnectButton;
		private System.Windows.Forms.Button backupButton;
		private System.Windows.Forms.Button restoreButton;
		private System.Windows.Forms.Button browseBackupButton;
		private System.Windows.Forms.Button browseRestoreButton;
		private System.Windows.Forms.Button browseSqlScriptButton;
		private System.Windows.Forms.TextBox sqlScriptFileTextBox;
		private System.Windows.Forms.Button runSqlScriptButton;
	}
}