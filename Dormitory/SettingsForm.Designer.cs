namespace Dormitory
{
	partial class SettingsForm
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
			this.backupsFolderPathTextBox = new System.Windows.Forms.TextBox();
			this.restoreFilePathTextBox = new System.Windows.Forms.TextBox();
			this.backupButton = new System.Windows.Forms.Button();
			this.restoreButton = new System.Windows.Forms.Button();
			this.browseBackupButton = new System.Windows.Forms.Button();
			this.browseRestoreButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.savesDurationHoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.savesIntervalHoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.checkAdminServerConnectionButton = new System.Windows.Forms.Button();
			this.adminServerDatabaseTextBox = new System.Windows.Forms.TextBox();
			this.adminServerNameTextBox = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.userServerNameTextBox = new System.Windows.Forms.TextBox();
			this.userServerDatabaseTextBox = new System.Windows.Forms.TextBox();
			this.checkUserServerConnectionButton = new System.Windows.Forms.Button();
			this.saveSettingsButton = new System.Windows.Forms.Button();
			this.organizationsDataGridView = new System.Windows.Forms.DataGridView();
			this.sqlScriptFileTextBox = new System.Windows.Forms.TextBox();
			this.browseSqlScriptButton = new System.Windows.Forms.Button();
			this.runSqlScriptButton = new System.Windows.Forms.Button();
			this.connectBut = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.savesDurationHoursNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.savesIntervalHoursNumericUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.organizationsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// backupsFolderPathTextBox
			// 
			this.backupsFolderPathTextBox.Location = new System.Drawing.Point(9, 71);
			this.backupsFolderPathTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.backupsFolderPathTextBox.Name = "backupsFolderPathTextBox";
			this.backupsFolderPathTextBox.Size = new System.Drawing.Size(309, 29);
			this.backupsFolderPathTextBox.TabIndex = 2;
			// 
			// restoreFilePathTextBox
			// 
			this.restoreFilePathTextBox.Location = new System.Drawing.Point(9, 136);
			this.restoreFilePathTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.restoreFilePathTextBox.Name = "restoreFilePathTextBox";
			this.restoreFilePathTextBox.Size = new System.Drawing.Size(309, 29);
			this.restoreFilePathTextBox.TabIndex = 3;
			// 
			// backupButton
			// 
			this.backupButton.Location = new System.Drawing.Point(480, 70);
			this.backupButton.Margin = new System.Windows.Forms.Padding(6);
			this.backupButton.Name = "backupButton";
			this.backupButton.Size = new System.Drawing.Size(138, 33);
			this.backupButton.TabIndex = 8;
			this.backupButton.Text = "Сохранить";
			this.backupButton.UseVisualStyleBackColor = true;
			this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
			// 
			// restoreButton
			// 
			this.restoreButton.Location = new System.Drawing.Point(480, 136);
			this.restoreButton.Margin = new System.Windows.Forms.Padding(6);
			this.restoreButton.Name = "restoreButton";
			this.restoreButton.Size = new System.Drawing.Size(138, 33);
			this.restoreButton.TabIndex = 9;
			this.restoreButton.Text = "Загрузить";
			this.restoreButton.UseVisualStyleBackColor = true;
			this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
			// 
			// browseBackupButton
			// 
			this.browseBackupButton.Location = new System.Drawing.Point(330, 70);
			this.browseBackupButton.Margin = new System.Windows.Forms.Padding(6);
			this.browseBackupButton.Name = "browseBackupButton";
			this.browseBackupButton.Size = new System.Drawing.Size(138, 33);
			this.browseBackupButton.TabIndex = 10;
			this.browseBackupButton.Text = "Обзор";
			this.browseBackupButton.UseVisualStyleBackColor = true;
			this.browseBackupButton.Click += new System.EventHandler(this.browseBackupButton_Click);
			// 
			// browseRestoreButton
			// 
			this.browseRestoreButton.Location = new System.Drawing.Point(330, 135);
			this.browseRestoreButton.Margin = new System.Windows.Forms.Padding(6);
			this.browseRestoreButton.Name = "browseRestoreButton";
			this.browseRestoreButton.Size = new System.Drawing.Size(138, 33);
			this.browseRestoreButton.TabIndex = 11;
			this.browseRestoreButton.Text = "Обзор";
			this.browseRestoreButton.UseVisualStyleBackColor = true;
			this.browseRestoreButton.Click += new System.EventHandler(this.browseRestoreButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.savesDurationHoursNumericUpDown);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.savesIntervalHoursNumericUpDown);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.backupButton);
			this.groupBox1.Controls.Add(this.backupsFolderPathTextBox);
			this.groupBox1.Controls.Add(this.restoreFilePathTextBox);
			this.groupBox1.Controls.Add(this.restoreButton);
			this.groupBox1.Controls.Add(this.browseBackupButton);
			this.groupBox1.Controls.Add(this.browseRestoreButton);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(644, 267);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Настройка резервного копирования";
			// 
			// savesDurationHoursNumericUpDown
			// 
			this.savesDurationHoursNumericUpDown.Location = new System.Drawing.Point(330, 221);
			this.savesDurationHoursNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.savesDurationHoursNumericUpDown.Name = "savesDurationHoursNumericUpDown";
			this.savesDurationHoursNumericUpDown.Size = new System.Drawing.Size(120, 29);
			this.savesDurationHoursNumericUpDown.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 221);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(306, 24);
			this.label4.TabIndex = 16;
			this.label4.Text = "Длительность хранения (в днях)";
			// 
			// savesIntervalHoursNumericUpDown
			// 
			this.savesIntervalHoursNumericUpDown.Location = new System.Drawing.Point(330, 179);
			this.savesIntervalHoursNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.savesIntervalHoursNumericUpDown.Name = "savesIntervalHoursNumericUpDown";
			this.savesIntervalHoursNumericUpDown.Size = new System.Drawing.Size(120, 29);
			this.savesIntervalHoursNumericUpDown.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 181);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(291, 24);
			this.label3.TabIndex = 14;
			this.label3.Text = "Интервал сохранения (в часах)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(279, 24);
			this.label2.TabIndex = 13;
			this.label2.Text = "Путь к файлу восстановления";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 24);
			this.label1.TabIndex = 12;
			this.label1.Text = "Путь к папке сохранения";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(12, 285);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(531, 271);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Настройки подключения";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.checkAdminServerConnectionButton);
			this.groupBox4.Controls.Add(this.adminServerDatabaseTextBox);
			this.groupBox4.Controls.Add(this.adminServerNameTextBox);
			this.groupBox4.Location = new System.Drawing.Point(272, 28);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(245, 215);
			this.groupBox4.TabIndex = 9;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Администратор";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(59, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(130, 24);
			this.label8.TabIndex = 8;
			this.label8.Text = " База данных";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(30, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(177, 24);
			this.label6.TabIndex = 1;
			this.label6.Text = "Название сервера";
			// 
			// checkAdminServerConnectionButton
			// 
			this.checkAdminServerConnectionButton.Location = new System.Drawing.Point(28, 159);
			this.checkAdminServerConnectionButton.Name = "checkAdminServerConnectionButton";
			this.checkAdminServerConnectionButton.Size = new System.Drawing.Size(179, 29);
			this.checkAdminServerConnectionButton.TabIndex = 7;
			this.checkAdminServerConnectionButton.Text = "Проверка";
			this.checkAdminServerConnectionButton.UseVisualStyleBackColor = true;
			this.checkAdminServerConnectionButton.Click += new System.EventHandler(this.checkAdminServerConnectionButton_Click);
			// 
			// adminServerDatabaseTextBox
			// 
			this.adminServerDatabaseTextBox.Location = new System.Drawing.Point(6, 120);
			this.adminServerDatabaseTextBox.Name = "adminServerDatabaseTextBox";
			this.adminServerDatabaseTextBox.Size = new System.Drawing.Size(233, 29);
			this.adminServerDatabaseTextBox.TabIndex = 5;
			// 
			// adminServerNameTextBox
			// 
			this.adminServerNameTextBox.Location = new System.Drawing.Point(6, 61);
			this.adminServerNameTextBox.Name = "adminServerNameTextBox";
			this.adminServerNameTextBox.Size = new System.Drawing.Size(233, 29);
			this.adminServerNameTextBox.TabIndex = 3;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.userServerNameTextBox);
			this.groupBox3.Controls.Add(this.userServerDatabaseTextBox);
			this.groupBox3.Controls.Add(this.checkUserServerConnectionButton);
			this.groupBox3.Location = new System.Drawing.Point(10, 28);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(245, 215);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Пользователь";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(53, 93);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 24);
			this.label7.TabIndex = 7;
			this.label7.Text = " База данных";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(44, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(177, 24);
			this.label5.TabIndex = 0;
			this.label5.Text = "Название сервера";
			// 
			// userServerNameTextBox
			// 
			this.userServerNameTextBox.Location = new System.Drawing.Point(6, 61);
			this.userServerNameTextBox.Name = "userServerNameTextBox";
			this.userServerNameTextBox.Size = new System.Drawing.Size(233, 29);
			this.userServerNameTextBox.TabIndex = 2;
			// 
			// userServerDatabaseTextBox
			// 
			this.userServerDatabaseTextBox.Location = new System.Drawing.Point(6, 120);
			this.userServerDatabaseTextBox.Name = "userServerDatabaseTextBox";
			this.userServerDatabaseTextBox.Size = new System.Drawing.Size(233, 29);
			this.userServerDatabaseTextBox.TabIndex = 4;
			// 
			// checkUserServerConnectionButton
			// 
			this.checkUserServerConnectionButton.Location = new System.Drawing.Point(26, 158);
			this.checkUserServerConnectionButton.Name = "checkUserServerConnectionButton";
			this.checkUserServerConnectionButton.Size = new System.Drawing.Size(179, 29);
			this.checkUserServerConnectionButton.TabIndex = 6;
			this.checkUserServerConnectionButton.Text = "Проверка";
			this.checkUserServerConnectionButton.UseVisualStyleBackColor = true;
			this.checkUserServerConnectionButton.Click += new System.EventHandler(this.checkUserServerConnectionButton_Click);
			// 
			// saveSettingsButton
			// 
			this.saveSettingsButton.Location = new System.Drawing.Point(554, 407);
			this.saveSettingsButton.Name = "saveSettingsButton";
			this.saveSettingsButton.Size = new System.Drawing.Size(118, 42);
			this.saveSettingsButton.TabIndex = 20;
			this.saveSettingsButton.Text = "Сохранить";
			this.saveSettingsButton.UseVisualStyleBackColor = true;
			this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
			// 
			// organizationsDataGridView
			// 
			this.organizationsDataGridView.AllowUserToAddRows = false;
			this.organizationsDataGridView.AllowUserToDeleteRows = false;
			this.organizationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.organizationsDataGridView.Location = new System.Drawing.Point(48, 565);
			this.organizationsDataGridView.Margin = new System.Windows.Forms.Padding(6);
			this.organizationsDataGridView.MultiSelect = false;
			this.organizationsDataGridView.Name = "organizationsDataGridView";
			this.organizationsDataGridView.ReadOnly = true;
			this.organizationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.organizationsDataGridView.Size = new System.Drawing.Size(539, 102);
			this.organizationsDataGridView.TabIndex = 17;
			// 
			// sqlScriptFileTextBox
			// 
			this.sqlScriptFileTextBox.Location = new System.Drawing.Point(554, 288);
			this.sqlScriptFileTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.sqlScriptFileTextBox.Name = "sqlScriptFileTextBox";
			this.sqlScriptFileTextBox.Size = new System.Drawing.Size(114, 29);
			this.sqlScriptFileTextBox.TabIndex = 13;
			// 
			// browseSqlScriptButton
			// 
			this.browseSqlScriptButton.Location = new System.Drawing.Point(554, 366);
			this.browseSqlScriptButton.Margin = new System.Windows.Forms.Padding(6);
			this.browseSqlScriptButton.Name = "browseSqlScriptButton";
			this.browseSqlScriptButton.Size = new System.Drawing.Size(118, 32);
			this.browseSqlScriptButton.TabIndex = 12;
			this.browseSqlScriptButton.Text = "browse sql";
			this.browseSqlScriptButton.UseVisualStyleBackColor = true;
			this.browseSqlScriptButton.Click += new System.EventHandler(this.browseSqlScriptButton_Click);
			// 
			// runSqlScriptButton
			// 
			this.runSqlScriptButton.Location = new System.Drawing.Point(554, 329);
			this.runSqlScriptButton.Margin = new System.Windows.Forms.Padding(6);
			this.runSqlScriptButton.Name = "runSqlScriptButton";
			this.runSqlScriptButton.Size = new System.Drawing.Size(76, 29);
			this.runSqlScriptButton.TabIndex = 14;
			this.runSqlScriptButton.Text = "run sql";
			this.runSqlScriptButton.UseVisualStyleBackColor = true;
			this.runSqlScriptButton.Click += new System.EventHandler(this.runSqlScriptButton_Click);
			// 
			// connectBut
			// 
			this.connectBut.Location = new System.Drawing.Point(552, 499);
			this.connectBut.Margin = new System.Windows.Forms.Padding(6);
			this.connectBut.Name = "connectBut";
			this.connectBut.Size = new System.Drawing.Size(96, 42);
			this.connectBut.TabIndex = 15;
			this.connectBut.Text = "Подключение";
			this.connectBut.UseVisualStyleBackColor = true;
			this.connectBut.Click += new System.EventHandler(this.connectBut_Click);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 692);
			this.Controls.Add(this.saveSettingsButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.sqlScriptFileTextBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.organizationsDataGridView);
			this.Controls.Add(this.connectBut);
			this.Controls.Add(this.runSqlScriptButton);
			this.Controls.Add(this.browseSqlScriptButton);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "SettingsForm";
			this.Text = "Настройки";
			this.Load += new System.EventHandler(this.BackupForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.savesDurationHoursNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.savesIntervalHoursNumericUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.organizationsDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox backupsFolderPathTextBox;
		private System.Windows.Forms.TextBox restoreFilePathTextBox;
		private System.Windows.Forms.Button backupButton;
		private System.Windows.Forms.Button restoreButton;
		private System.Windows.Forms.Button browseBackupButton;
		private System.Windows.Forms.Button browseRestoreButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown savesIntervalHoursNumericUpDown;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown savesDurationHoursNumericUpDown;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox adminServerDatabaseTextBox;
		private System.Windows.Forms.TextBox userServerDatabaseTextBox;
		private System.Windows.Forms.TextBox adminServerNameTextBox;
		private System.Windows.Forms.TextBox userServerNameTextBox;
		private System.Windows.Forms.Button checkAdminServerConnectionButton;
		private System.Windows.Forms.Button checkUserServerConnectionButton;
		private System.Windows.Forms.Button saveSettingsButton;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridView organizationsDataGridView;
		private System.Windows.Forms.TextBox sqlScriptFileTextBox;
		private System.Windows.Forms.Button browseSqlScriptButton;
		private System.Windows.Forms.Button runSqlScriptButton;
		private System.Windows.Forms.Button connectBut;
	}
}