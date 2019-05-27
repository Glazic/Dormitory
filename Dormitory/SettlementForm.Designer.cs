namespace Dormitory
{
	partial class SettlementForm
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
			this.residentIdLabel = new System.Windows.Forms.Label();
			this.residentButton = new System.Windows.Forms.Button();
			this.organizationTextBox = new System.Windows.Forms.TextBox();
			this.organizationLabel = new System.Windows.Forms.Label();
			this.patronymicTextBox = new System.Windows.Forms.TextBox();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.surnameTextBox = new System.Windows.Forms.TextBox();
			this.patronymicLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.surnameLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.settlementDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.settlementDateLabel = new System.Windows.Forms.Label();
			this.settleButton = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// residentIdLabel
			// 
			this.residentIdLabel.AutoSize = true;
			this.residentIdLabel.Location = new System.Drawing.Point(77, 151);
			this.residentIdLabel.Name = "residentIdLabel";
			this.residentIdLabel.Size = new System.Drawing.Size(35, 13);
			this.residentIdLabel.TabIndex = 0;
			this.residentIdLabel.Text = "label1";
			// 
			// residentButton
			// 
			this.residentButton.Location = new System.Drawing.Point(12, 146);
			this.residentButton.Name = "residentButton";
			this.residentButton.Size = new System.Drawing.Size(59, 23);
			this.residentButton.TabIndex = 31;
			this.residentButton.Text = "Выбрать";
			this.residentButton.UseVisualStyleBackColor = true;
			this.residentButton.Click += new System.EventHandler(this.residentButton_Click);
			// 
			// organizationTextBox
			// 
			this.organizationTextBox.Location = new System.Drawing.Point(102, 84);
			this.organizationTextBox.Name = "organizationTextBox";
			this.organizationTextBox.ReadOnly = true;
			this.organizationTextBox.Size = new System.Drawing.Size(200, 20);
			this.organizationTextBox.TabIndex = 41;
			// 
			// organizationLabel
			// 
			this.organizationLabel.AutoSize = true;
			this.organizationLabel.Location = new System.Drawing.Point(12, 87);
			this.organizationLabel.Name = "organizationLabel";
			this.organizationLabel.Size = new System.Drawing.Size(74, 13);
			this.organizationLabel.TabIndex = 39;
			this.organizationLabel.Text = "Организация";
			// 
			// patronymicTextBox
			// 
			this.patronymicTextBox.Location = new System.Drawing.Point(102, 58);
			this.patronymicTextBox.Name = "patronymicTextBox";
			this.patronymicTextBox.ReadOnly = true;
			this.patronymicTextBox.Size = new System.Drawing.Size(200, 20);
			this.patronymicTextBox.TabIndex = 38;
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(102, 32);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.ReadOnly = true;
			this.nameTextBox.Size = new System.Drawing.Size(200, 20);
			this.nameTextBox.TabIndex = 37;
			// 
			// surnameTextBox
			// 
			this.surnameTextBox.Location = new System.Drawing.Point(102, 6);
			this.surnameTextBox.Name = "surnameTextBox";
			this.surnameTextBox.ReadOnly = true;
			this.surnameTextBox.Size = new System.Drawing.Size(200, 20);
			this.surnameTextBox.TabIndex = 36;
			// 
			// patronymicLabel
			// 
			this.patronymicLabel.AutoSize = true;
			this.patronymicLabel.Location = new System.Drawing.Point(12, 61);
			this.patronymicLabel.Name = "patronymicLabel";
			this.patronymicLabel.Size = new System.Drawing.Size(54, 13);
			this.patronymicLabel.TabIndex = 35;
			this.patronymicLabel.Text = "Отчество";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(12, 35);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(29, 13);
			this.nameLabel.TabIndex = 34;
			this.nameLabel.Text = "Имя";
			// 
			// surnameLabel
			// 
			this.surnameLabel.AutoSize = true;
			this.surnameLabel.Location = new System.Drawing.Point(12, 9);
			this.surnameLabel.Name = "surnameLabel";
			this.surnameLabel.Size = new System.Drawing.Size(56, 13);
			this.surnameLabel.TabIndex = 33;
			this.surnameLabel.Text = "Фамилия";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "Id";
			this.label1.Visible = false;
			// 
			// settlementDateTimePicker
			// 
			this.settlementDateTimePicker.Location = new System.Drawing.Point(102, 111);
			this.settlementDateTimePicker.Name = "settlementDateTimePicker";
			this.settlementDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.settlementDateTimePicker.TabIndex = 43;
			// 
			// settlementDateLabel
			// 
			this.settlementDateLabel.AutoSize = true;
			this.settlementDateLabel.Location = new System.Drawing.Point(12, 117);
			this.settlementDateLabel.Name = "settlementDateLabel";
			this.settlementDateLabel.Size = new System.Drawing.Size(90, 13);
			this.settlementDateLabel.TabIndex = 42;
			this.settlementDateLabel.Text = "Дата заселения";
			// 
			// settleButton
			// 
			this.settleButton.Location = new System.Drawing.Point(238, 146);
			this.settleButton.Name = "settleButton";
			this.settleButton.Size = new System.Drawing.Size(64, 23);
			this.settleButton.TabIndex = 44;
			this.settleButton.Text = "Заселить";
			this.settleButton.UseVisualStyleBackColor = true;
			this.settleButton.Click += new System.EventHandler(this.settleButton_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(12, 186);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(87, 17);
			this.checkBox1.TabIndex = 45;
			this.checkBox1.Text = "Постельное";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// SettlementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.settleButton);
			this.Controls.Add(this.settlementDateTimePicker);
			this.Controls.Add(this.settlementDateLabel);
			this.Controls.Add(this.organizationTextBox);
			this.Controls.Add(this.organizationLabel);
			this.Controls.Add(this.patronymicTextBox);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.surnameTextBox);
			this.Controls.Add(this.patronymicLabel);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.surnameLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.residentButton);
			this.Controls.Add(this.residentIdLabel);
			this.Name = "SettlementForm";
			this.Text = "SettlementForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label residentIdLabel;
		private System.Windows.Forms.Button residentButton;
		private System.Windows.Forms.TextBox organizationTextBox;
		private System.Windows.Forms.Label organizationLabel;
		private System.Windows.Forms.TextBox patronymicTextBox;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox surnameTextBox;
		private System.Windows.Forms.Label patronymicLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label surnameLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker settlementDateTimePicker;
		private System.Windows.Forms.Label settlementDateLabel;
		private System.Windows.Forms.Button settleButton;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}