namespace Dormitory
{
	partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.enterButton = new System.Windows.Forms.Button();
			this.loginLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.settingsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// enterButton
			// 
			this.enterButton.Location = new System.Drawing.Point(158, 266);
			this.enterButton.Margin = new System.Windows.Forms.Padding(6);
			this.enterButton.Name = "enterButton";
			this.enterButton.Size = new System.Drawing.Size(138, 42);
			this.enterButton.TabIndex = 5;
			this.enterButton.Text = "Вход";
			this.enterButton.UseVisualStyleBackColor = true;
			this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
			// 
			// loginLabel
			// 
			this.loginLabel.AutoSize = true;
			this.loginLabel.Location = new System.Drawing.Point(57, 70);
			this.loginLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.loginLabel.Name = "loginLabel";
			this.loginLabel.Size = new System.Drawing.Size(64, 24);
			this.loginLabel.TabIndex = 1;
			this.loginLabel.Text = "Логин";
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(57, 177);
			this.passwordLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(76, 24);
			this.passwordLabel.TabIndex = 2;
			this.passwordLabel.Text = "Пароль";
			// 
			// userNameTextBox
			// 
			this.userNameTextBox.Location = new System.Drawing.Point(158, 67);
			this.userNameTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Size = new System.Drawing.Size(308, 29);
			this.userNameTextBox.TabIndex = 3;
			this.userNameTextBox.Text = "zaq";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(158, 174);
			this.passwordTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(308, 29);
			this.passwordTextBox.TabIndex = 4;
			this.passwordTextBox.Text = "zaq";
			// 
			// settingsButton
			// 
			this.settingsButton.Location = new System.Drawing.Point(305, 266);
			this.settingsButton.Name = "settingsButton";
			this.settingsButton.Size = new System.Drawing.Size(138, 42);
			this.settingsButton.TabIndex = 6;
			this.settingsButton.Text = "Настройки";
			this.settingsButton.UseVisualStyleBackColor = true;
			this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 323);
			this.Controls.Add(this.settingsButton);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.userNameTextBox);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.loginLabel);
			this.Controls.Add(this.enterButton);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Авторизация";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button enterButton;
		private System.Windows.Forms.Label loginLabel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.TextBox userNameTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Button settingsButton;
	}
}