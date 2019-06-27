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
			this.checkUserServerConnectionButton = new System.Windows.Forms.Button();
			this.userServerNameTextBox = new System.Windows.Forms.TextBox();
			this.userServerDatabaseTextBox = new System.Windows.Forms.TextBox();
			this.saveSettingsButton = new System.Windows.Forms.Button();
			this.sqlScriptFileTextBox = new System.Windows.Forms.TextBox();
			this.browseSqlScriptButton = new System.Windows.Forms.Button();
			this.runSqlScriptButton = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// backupsFolderPathTextBox
			// 
			this.backupsFolderPathTextBox.Location = new System.Drawing.Point(9, 74);
			this.backupsFolderPathTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.backupsFolderPathTextBox.Name = "backupsFolderPathTextBox";
			this.backupsFolderPathTextBox.Size = new System.Drawing.Size(276, 29);
			this.backupsFolderPathTextBox.TabIndex = 11;
			// 
			// restoreFilePathTextBox
			// 
			this.restoreFilePathTextBox.Location = new System.Drawing.Point(9, 164);
			this.restoreFilePathTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.restoreFilePathTextBox.Name = "restoreFilePathTextBox";
			this.restoreFilePathTextBox.Size = new System.Drawing.Size(276, 29);
			this.restoreFilePathTextBox.TabIndex = 14;
			// 
			// backupButton
			// 
			this.backupButton.Location = new System.Drawing.Point(300, 73);
			this.backupButton.Margin = new System.Windows.Forms.Padding(6);
			this.backupButton.Name = "backupButton";
			this.backupButton.Size = new System.Drawing.Size(117, 33);
			this.backupButton.TabIndex = 13;
			this.backupButton.Text = "Сохранить";
			this.backupButton.UseVisualStyleBackColor = true;
			this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
			// 
			// restoreButton
			// 
			this.restoreButton.Location = new System.Drawing.Point(300, 163);
			this.restoreButton.Margin = new System.Windows.Forms.Padding(6);
			this.restoreButton.Name = "restoreButton";
			this.restoreButton.Size = new System.Drawing.Size(117, 33);
			this.restoreButton.TabIndex = 16;
			this.restoreButton.Text = "Загрузить";
			this.restoreButton.UseVisualStyleBackColor = true;
			this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
			// 
			// browseBackupButton
			// 
			this.browseBackupButton.Location = new System.Drawing.Point(300, 29);
			this.browseBackupButton.Margin = new System.Windows.Forms.Padding(6);
			this.browseBackupButton.Name = "browseBackupButton";
			this.browseBackupButton.Size = new System.Drawing.Size(117, 32);
			this.browseBackupButton.TabIndex = 12;
			this.browseBackupButton.Text = "Обзор";
			this.browseBackupButton.UseVisualStyleBackColor = true;
			this.browseBackupButton.Click += new System.EventHandler(this.browseBackupButton_Click);
			// 
			// browseRestoreButton
			// 
			this.browseRestoreButton.Location = new System.Drawing.Point(300, 118);
			this.browseRestoreButton.Margin = new System.Windows.Forms.Padding(6);
			this.browseRestoreButton.Name = "browseRestoreButton";
			this.browseRestoreButton.Size = new System.Drawing.Size(117, 32);
			this.browseRestoreButton.TabIndex = 15;
			this.browseRestoreButton.Text = "Обзор";
			this.browseRestoreButton.UseVisualStyleBackColor = true;
			this.browseRestoreButton.Click += new System.EventHandler(this.browseRestoreButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.backupButton);
			this.groupBox1.Controls.Add(this.backupsFolderPathTextBox);
			this.groupBox1.Controls.Add(this.browseRestoreButton);
			this.groupBox1.Controls.Add(this.browseBackupButton);
			this.groupBox1.Controls.Add(this.restoreFilePathTextBox);
			this.groupBox1.Controls.Add(this.restoreButton);
			this.groupBox1.Location = new System.Drawing.Point(12, 274);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(428, 209);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Настройка резервного копирования";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(279, 24);
			this.label2.TabIndex = 13;
			this.label2.Text = "Путь к файлу восстановления";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 24);
			this.label1.TabIndex = 12;
			this.label1.Text = "Путь к папке сохранения";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(694, 256);
			this.groupBox2.TabIndex = 1;
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
			this.groupBox4.Location = new System.Drawing.Point(360, 28);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(328, 206);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Администратор";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(96, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(130, 24);
			this.label8.TabIndex = 8;
			this.label8.Text = " База данных";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(80, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(177, 24);
			this.label6.TabIndex = 1;
			this.label6.Text = "Название сервера";
			// 
			// checkAdminServerConnectionButton
			// 
			this.checkAdminServerConnectionButton.Location = new System.Drawing.Point(100, 155);
			this.checkAdminServerConnectionButton.Name = "checkAdminServerConnectionButton";
			this.checkAdminServerConnectionButton.Size = new System.Drawing.Size(126, 32);
			this.checkAdminServerConnectionButton.TabIndex = 9;
			this.checkAdminServerConnectionButton.Text = "Проверка";
			this.checkAdminServerConnectionButton.UseVisualStyleBackColor = true;
			this.checkAdminServerConnectionButton.Click += new System.EventHandler(this.checkAdminServerConnectionButton_Click);
			// 
			// adminServerDatabaseTextBox
			// 
			this.adminServerDatabaseTextBox.Location = new System.Drawing.Point(6, 120);
			this.adminServerDatabaseTextBox.Name = "adminServerDatabaseTextBox";
			this.adminServerDatabaseTextBox.Size = new System.Drawing.Size(316, 29);
			this.adminServerDatabaseTextBox.TabIndex = 8;
			// 
			// adminServerNameTextBox
			// 
			this.adminServerNameTextBox.Location = new System.Drawing.Point(6, 61);
			this.adminServerNameTextBox.Name = "adminServerNameTextBox";
			this.adminServerNameTextBox.Size = new System.Drawing.Size(316, 29);
			this.adminServerNameTextBox.TabIndex = 7;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.checkUserServerConnectionButton);
			this.groupBox3.Controls.Add(this.userServerNameTextBox);
			this.groupBox3.Controls.Add(this.userServerDatabaseTextBox);
			this.groupBox3.Location = new System.Drawing.Point(10, 28);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(328, 206);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Пользователь";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(101, 93);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(130, 24);
			this.label7.TabIndex = 7;
			this.label7.Text = " База данных";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(83, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(177, 24);
			this.label5.TabIndex = 0;
			this.label5.Text = "Название сервера";
			// 
			// checkUserServerConnectionButton
			// 
			this.checkUserServerConnectionButton.Location = new System.Drawing.Point(105, 155);
			this.checkUserServerConnectionButton.Name = "checkUserServerConnectionButton";
			this.checkUserServerConnectionButton.Size = new System.Drawing.Size(126, 32);
			this.checkUserServerConnectionButton.TabIndex = 5;
			this.checkUserServerConnectionButton.Text = "Проверка";
			this.checkUserServerConnectionButton.UseVisualStyleBackColor = true;
			this.checkUserServerConnectionButton.Click += new System.EventHandler(this.checkUserServerConnectionButton_Click);
			// 
			// userServerNameTextBox
			// 
			this.userServerNameTextBox.Location = new System.Drawing.Point(6, 61);
			this.userServerNameTextBox.Name = "userServerNameTextBox";
			this.userServerNameTextBox.Size = new System.Drawing.Size(316, 29);
			this.userServerNameTextBox.TabIndex = 3;
			// 
			// userServerDatabaseTextBox
			// 
			this.userServerDatabaseTextBox.Location = new System.Drawing.Point(6, 120);
			this.userServerDatabaseTextBox.Name = "userServerDatabaseTextBox";
			this.userServerDatabaseTextBox.Size = new System.Drawing.Size(316, 29);
			this.userServerDatabaseTextBox.TabIndex = 4;
			// 
			// saveSettingsButton
			// 
			this.saveSettingsButton.Location = new System.Drawing.Point(448, 441);
			this.saveSettingsButton.Name = "saveSettingsButton";
			this.saveSettingsButton.Size = new System.Drawing.Size(258, 42);
			this.saveSettingsButton.TabIndex = 21;
			this.saveSettingsButton.Text = "Сохранить настройки";
			this.saveSettingsButton.UseVisualStyleBackColor = true;
			this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
			// 
			// sqlScriptFileTextBox
			// 
			this.sqlScriptFileTextBox.Location = new System.Drawing.Point(9, 65);
			this.sqlScriptFileTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.sqlScriptFileTextBox.Name = "sqlScriptFileTextBox";
			this.sqlScriptFileTextBox.Size = new System.Drawing.Size(246, 29);
			this.sqlScriptFileTextBox.TabIndex = 18;
			// 
			// browseSqlScriptButton
			// 
			this.browseSqlScriptButton.Location = new System.Drawing.Point(9, 106);
			this.browseSqlScriptButton.Margin = new System.Windows.Forms.Padding(6);
			this.browseSqlScriptButton.Name = "browseSqlScriptButton";
			this.browseSqlScriptButton.Size = new System.Drawing.Size(119, 32);
			this.browseSqlScriptButton.TabIndex = 19;
			this.browseSqlScriptButton.Text = "Обзор";
			this.browseSqlScriptButton.UseVisualStyleBackColor = true;
			this.browseSqlScriptButton.Click += new System.EventHandler(this.browseSqlScriptButton_Click);
			// 
			// runSqlScriptButton
			// 
			this.runSqlScriptButton.Location = new System.Drawing.Point(136, 106);
			this.runSqlScriptButton.Margin = new System.Windows.Forms.Padding(6);
			this.runSqlScriptButton.Name = "runSqlScriptButton";
			this.runSqlScriptButton.Size = new System.Drawing.Size(119, 32);
			this.runSqlScriptButton.TabIndex = 20;
			this.runSqlScriptButton.Text = "Выполнить";
			this.runSqlScriptButton.UseVisualStyleBackColor = true;
			this.runSqlScriptButton.Click += new System.EventHandler(this.runSqlScriptButton_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.sqlScriptFileTextBox);
			this.groupBox5.Controls.Add(this.browseSqlScriptButton);
			this.groupBox5.Controls.Add(this.runSqlScriptButton);
			this.groupBox5.Location = new System.Drawing.Point(446, 274);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(260, 150);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Создание базы данных";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 35);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(114, 24);
			this.label9.TabIndex = 0;
			this.label9.Text = "SQL скрипт";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 492);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.saveSettingsButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Настройки";
			this.Load += new System.EventHandler(this.BackupForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.TextBox sqlScriptFileTextBox;
		private System.Windows.Forms.Button browseSqlScriptButton;
		private System.Windows.Forms.Button runSqlScriptButton;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label9;
	}
}