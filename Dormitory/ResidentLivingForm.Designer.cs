namespace Dormitory
{
	partial class ResidentLivingForm
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
			this.rentGroupBox = new System.Windows.Forms.GroupBox();
			this.rentDataGridView = new System.Windows.Forms.DataGridView();
			this.saveLivingButton = new System.Windows.Forms.Button();
			this.rentThingsComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.saveRentButton = new System.Windows.Forms.Button();
			this.endRentDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.startRentDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.livingDataGridView = new System.Windows.Forms.DataGridView();
			this.livingGroupBox = new System.Windows.Forms.GroupBox();
			this.deleteLivingButton = new System.Windows.Forms.Button();
			this.roomIdLabel = new System.Windows.Forms.Label();
			this.residentRoomsIdLabel = new System.Windows.Forms.Label();
			this.bedClothesComboBox = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.settlementDateLabel = new System.Windows.Forms.Label();
			this.bedClothesLabel = new System.Windows.Forms.Label();
			this.cashPaymentComboBox = new System.Windows.Forms.ComboBox();
			this.sectionNumberTextBox = new System.Windows.Forms.TextBox();
			this.cashPaymentLabel = new System.Windows.Forms.Label();
			this.sectionLabel = new System.Windows.Forms.Label();
			this.settlementDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.roomNumberTextBox = new System.Windows.Forms.TextBox();
			this.roomLabel = new System.Windows.Forms.Label();
			this.dateOfEvictionDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.deleteRentButton = new System.Windows.Forms.Button();
			this.rentIdLabel = new System.Windows.Forms.Label();
			this.rentGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rentDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.livingDataGridView)).BeginInit();
			this.livingGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// rentGroupBox
			// 
			this.rentGroupBox.Controls.Add(this.rentDataGridView);
			this.rentGroupBox.Location = new System.Drawing.Point(15, 259);
			this.rentGroupBox.Name = "rentGroupBox";
			this.rentGroupBox.Size = new System.Drawing.Size(677, 192);
			this.rentGroupBox.TabIndex = 17;
			this.rentGroupBox.TabStop = false;
			this.rentGroupBox.Text = "Прокат";
			// 
			// rentDataGridView
			// 
			this.rentDataGridView.AllowUserToAddRows = false;
			this.rentDataGridView.AllowUserToDeleteRows = false;
			this.rentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.rentDataGridView.Location = new System.Drawing.Point(9, 31);
			this.rentDataGridView.Margin = new System.Windows.Forms.Padding(6);
			this.rentDataGridView.Name = "rentDataGridView";
			this.rentDataGridView.ReadOnly = true;
			this.rentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.rentDataGridView.Size = new System.Drawing.Size(659, 215);
			this.rentDataGridView.TabIndex = 17;
			this.rentDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rentDataGridView_CellClick);
			// 
			// saveLivingButton
			// 
			this.saveLivingButton.Location = new System.Drawing.Point(11, 213);
			this.saveLivingButton.Name = "saveLivingButton";
			this.saveLivingButton.Size = new System.Drawing.Size(199, 48);
			this.saveLivingButton.TabIndex = 55;
			this.saveLivingButton.Text = "Сохранить";
			this.saveLivingButton.UseVisualStyleBackColor = true;
			this.saveLivingButton.Click += new System.EventHandler(this.saveLivingButton_Click);
			// 
			// rentThingsComboBox
			// 
			this.rentThingsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rentThingsComboBox.FormattingEnabled = true;
			this.rentThingsComboBox.Location = new System.Drawing.Point(243, 46);
			this.rentThingsComboBox.Name = "rentThingsComboBox";
			this.rentThingsComboBox.Size = new System.Drawing.Size(176, 32);
			this.rentThingsComboBox.Sorted = true;
			this.rentThingsComboBox.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 24);
			this.label2.TabIndex = 53;
			this.label2.Text = "С";
			// 
			// saveRentButton
			// 
			this.saveRentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.saveRentButton.Location = new System.Drawing.Point(9, 101);
			this.saveRentButton.Margin = new System.Windows.Forms.Padding(6);
			this.saveRentButton.Name = "saveRentButton";
			this.saveRentButton.Size = new System.Drawing.Size(199, 48);
			this.saveRentButton.TabIndex = 21;
			this.saveRentButton.Text = "Сохранить";
			this.saveRentButton.UseVisualStyleBackColor = true;
			this.saveRentButton.Click += new System.EventHandler(this.saveRentButton_Click);
			// 
			// endRentDateTimePicker
			// 
			this.endRentDateTimePicker.Location = new System.Drawing.Point(37, 63);
			this.endRentDateTimePicker.Name = "endRentDateTimePicker";
			this.endRentDateTimePicker.Size = new System.Drawing.Size(200, 29);
			this.endRentDateTimePicker.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 24);
			this.label3.TabIndex = 54;
			this.label3.Text = "По";
			// 
			// startRentDateTimePicker
			// 
			this.startRentDateTimePicker.Location = new System.Drawing.Point(37, 27);
			this.startRentDateTimePicker.Name = "startRentDateTimePicker";
			this.startRentDateTimePicker.Size = new System.Drawing.Size(200, 29);
			this.startRentDateTimePicker.TabIndex = 18;
			// 
			// livingDataGridView
			// 
			this.livingDataGridView.AllowUserToAddRows = false;
			this.livingDataGridView.AllowUserToDeleteRows = false;
			this.livingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.livingDataGridView.Location = new System.Drawing.Point(15, 15);
			this.livingDataGridView.Margin = new System.Windows.Forms.Padding(6);
			this.livingDataGridView.Name = "livingDataGridView";
			this.livingDataGridView.ReadOnly = true;
			this.livingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.livingDataGridView.Size = new System.Drawing.Size(674, 235);
			this.livingDataGridView.TabIndex = 56;
			this.livingDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.livingDataGridView_CellClick);
			// 
			// livingGroupBox
			// 
			this.livingGroupBox.Controls.Add(this.deleteLivingButton);
			this.livingGroupBox.Controls.Add(this.roomIdLabel);
			this.livingGroupBox.Controls.Add(this.saveLivingButton);
			this.livingGroupBox.Controls.Add(this.residentRoomsIdLabel);
			this.livingGroupBox.Controls.Add(this.bedClothesComboBox);
			this.livingGroupBox.Controls.Add(this.label6);
			this.livingGroupBox.Controls.Add(this.settlementDateLabel);
			this.livingGroupBox.Controls.Add(this.bedClothesLabel);
			this.livingGroupBox.Controls.Add(this.cashPaymentComboBox);
			this.livingGroupBox.Controls.Add(this.sectionNumberTextBox);
			this.livingGroupBox.Controls.Add(this.cashPaymentLabel);
			this.livingGroupBox.Controls.Add(this.sectionLabel);
			this.livingGroupBox.Controls.Add(this.settlementDateDateTimePicker);
			this.livingGroupBox.Controls.Add(this.roomNumberTextBox);
			this.livingGroupBox.Controls.Add(this.roomLabel);
			this.livingGroupBox.Controls.Add(this.dateOfEvictionDateTimePicker);
			this.livingGroupBox.Location = new System.Drawing.Point(698, 15);
			this.livingGroupBox.Name = "livingGroupBox";
			this.livingGroupBox.Size = new System.Drawing.Size(430, 273);
			this.livingGroupBox.TabIndex = 57;
			this.livingGroupBox.TabStop = false;
			this.livingGroupBox.Text = "Проживание";
			// 
			// deleteLivingButton
			// 
			this.deleteLivingButton.Location = new System.Drawing.Point(217, 213);
			this.deleteLivingButton.Name = "deleteLivingButton";
			this.deleteLivingButton.Size = new System.Drawing.Size(201, 48);
			this.deleteLivingButton.TabIndex = 67;
			this.deleteLivingButton.Text = "Удалить";
			this.deleteLivingButton.UseVisualStyleBackColor = true;
			this.deleteLivingButton.Click += new System.EventHandler(this.deleteLivingButton_Click);
			// 
			// roomIdLabel
			// 
			this.roomIdLabel.AutoSize = true;
			this.roomIdLabel.Location = new System.Drawing.Point(103, 67);
			this.roomIdLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.roomIdLabel.Name = "roomIdLabel";
			this.roomIdLabel.Size = new System.Drawing.Size(31, 24);
			this.roomIdLabel.TabIndex = 66;
			this.roomIdLabel.Text = "rId";
			this.roomIdLabel.Visible = false;
			// 
			// residentRoomsIdLabel
			// 
			this.residentRoomsIdLabel.AutoSize = true;
			this.residentRoomsIdLabel.Location = new System.Drawing.Point(103, 34);
			this.residentRoomsIdLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.residentRoomsIdLabel.Name = "residentRoomsIdLabel";
			this.residentRoomsIdLabel.Size = new System.Drawing.Size(25, 24);
			this.residentRoomsIdLabel.TabIndex = 65;
			this.residentRoomsIdLabel.Text = "Id";
			this.residentRoomsIdLabel.Visible = false;
			// 
			// bedClothesComboBox
			// 
			this.bedClothesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bedClothesComboBox.FormattingEnabled = true;
			this.bedClothesComboBox.Location = new System.Drawing.Point(139, 105);
			this.bedClothesComboBox.Name = "bedClothesComboBox";
			this.bedClothesComboBox.Size = new System.Drawing.Size(279, 32);
			this.bedClothesComboBox.Sorted = true;
			this.bedClothesComboBox.TabIndex = 64;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 182);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 24);
			this.label6.TabIndex = 63;
			this.label6.Text = "Выселение";
			// 
			// settlementDateLabel
			// 
			this.settlementDateLabel.AutoSize = true;
			this.settlementDateLabel.Location = new System.Drawing.Point(9, 147);
			this.settlementDateLabel.Name = "settlementDateLabel";
			this.settlementDateLabel.Size = new System.Drawing.Size(108, 24);
			this.settlementDateLabel.TabIndex = 62;
			this.settlementDateLabel.Text = "Заселение";
			// 
			// bedClothesLabel
			// 
			this.bedClothesLabel.AutoSize = true;
			this.bedClothesLabel.Location = new System.Drawing.Point(9, 108);
			this.bedClothesLabel.Name = "bedClothesLabel";
			this.bedClothesLabel.Size = new System.Drawing.Size(119, 24);
			this.bedClothesLabel.TabIndex = 61;
			this.bedClothesLabel.Text = "Постельное";
			// 
			// cashPaymentComboBox
			// 
			this.cashPaymentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cashPaymentComboBox.FormattingEnabled = true;
			this.cashPaymentComboBox.Location = new System.Drawing.Point(139, 67);
			this.cashPaymentComboBox.Name = "cashPaymentComboBox";
			this.cashPaymentComboBox.Size = new System.Drawing.Size(279, 32);
			this.cashPaymentComboBox.Sorted = true;
			this.cashPaymentComboBox.TabIndex = 58;
			// 
			// sectionNumberTextBox
			// 
			this.sectionNumberTextBox.Location = new System.Drawing.Point(139, 31);
			this.sectionNumberTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.sectionNumberTextBox.Name = "sectionNumberTextBox";
			this.sectionNumberTextBox.Size = new System.Drawing.Size(87, 29);
			this.sectionNumberTextBox.TabIndex = 6;
			// 
			// cashPaymentLabel
			// 
			this.cashPaymentLabel.AutoSize = true;
			this.cashPaymentLabel.Location = new System.Drawing.Point(9, 70);
			this.cashPaymentLabel.Name = "cashPaymentLabel";
			this.cashPaymentLabel.Size = new System.Drawing.Size(76, 24);
			this.cashPaymentLabel.TabIndex = 59;
			this.cashPaymentLabel.Text = "Оплата";
			// 
			// sectionLabel
			// 
			this.sectionLabel.AutoSize = true;
			this.sectionLabel.Location = new System.Drawing.Point(9, 34);
			this.sectionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.sectionLabel.Name = "sectionLabel";
			this.sectionLabel.Size = new System.Drawing.Size(75, 24);
			this.sectionLabel.TabIndex = 5;
			this.sectionLabel.Text = "Секция";
			// 
			// settlementDateDateTimePicker
			// 
			this.settlementDateDateTimePicker.Location = new System.Drawing.Point(139, 143);
			this.settlementDateDateTimePicker.Name = "settlementDateDateTimePicker";
			this.settlementDateDateTimePicker.Size = new System.Drawing.Size(279, 29);
			this.settlementDateDateTimePicker.TabIndex = 57;
			// 
			// roomNumberTextBox
			// 
			this.roomNumberTextBox.Location = new System.Drawing.Point(331, 31);
			this.roomNumberTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.roomNumberTextBox.Name = "roomNumberTextBox";
			this.roomNumberTextBox.Size = new System.Drawing.Size(87, 29);
			this.roomNumberTextBox.TabIndex = 8;
			// 
			// roomLabel
			// 
			this.roomLabel.AutoSize = true;
			this.roomLabel.Location = new System.Drawing.Point(231, 34);
			this.roomLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.roomLabel.Name = "roomLabel";
			this.roomLabel.Size = new System.Drawing.Size(87, 24);
			this.roomLabel.TabIndex = 7;
			this.roomLabel.Text = "Комната";
			// 
			// dateOfEvictionDateTimePicker
			// 
			this.dateOfEvictionDateTimePicker.Location = new System.Drawing.Point(139, 178);
			this.dateOfEvictionDateTimePicker.Name = "dateOfEvictionDateTimePicker";
			this.dateOfEvictionDateTimePicker.ShowCheckBox = true;
			this.dateOfEvictionDateTimePicker.Size = new System.Drawing.Size(279, 29);
			this.dateOfEvictionDateTimePicker.TabIndex = 56;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.deleteRentButton);
			this.groupBox1.Controls.Add(this.saveRentButton);
			this.groupBox1.Controls.Add(this.rentThingsComboBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.rentIdLabel);
			this.groupBox1.Controls.Add(this.endRentDateTimePicker);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.startRentDateTimePicker);
			this.groupBox1.Location = new System.Drawing.Point(698, 294);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(430, 157);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Прокат";
			// 
			// deleteRentButton
			// 
			this.deleteRentButton.Location = new System.Drawing.Point(217, 101);
			this.deleteRentButton.Name = "deleteRentButton";
			this.deleteRentButton.Size = new System.Drawing.Size(199, 48);
			this.deleteRentButton.TabIndex = 55;
			this.deleteRentButton.Text = "Удалить";
			this.deleteRentButton.UseVisualStyleBackColor = true;
			this.deleteRentButton.Click += new System.EventHandler(this.deleteRentButton_Click);
			// 
			// rentIdLabel
			// 
			this.rentIdLabel.AutoSize = true;
			this.rentIdLabel.Location = new System.Drawing.Point(256, 19);
			this.rentIdLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.rentIdLabel.Name = "rentIdLabel";
			this.rentIdLabel.Size = new System.Drawing.Size(25, 24);
			this.rentIdLabel.TabIndex = 65;
			this.rentIdLabel.Text = "Id";
			this.rentIdLabel.Visible = false;
			// 
			// ResidentLivingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1139, 461);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.livingGroupBox);
			this.Controls.Add(this.livingDataGridView);
			this.Controls.Add(this.rentGroupBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "ResidentLivingForm";
			this.Text = "Проживание и прокат";
			this.Load += new System.EventHandler(this.ResidentLivingForm_Load);
			this.rentGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rentDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.livingDataGridView)).EndInit();
			this.livingGroupBox.ResumeLayout(false);
			this.livingGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox rentGroupBox;
		private System.Windows.Forms.Button saveLivingButton;
		private System.Windows.Forms.DataGridView rentDataGridView;
		private System.Windows.Forms.ComboBox rentThingsComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button saveRentButton;
		private System.Windows.Forms.DateTimePicker endRentDateTimePicker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker startRentDateTimePicker;
		private System.Windows.Forms.DataGridView livingDataGridView;
		private System.Windows.Forms.GroupBox livingGroupBox;
		private System.Windows.Forms.ComboBox cashPaymentComboBox;
		private System.Windows.Forms.TextBox sectionNumberTextBox;
		private System.Windows.Forms.Label cashPaymentLabel;
		private System.Windows.Forms.Label sectionLabel;
		private System.Windows.Forms.DateTimePicker settlementDateDateTimePicker;
		private System.Windows.Forms.TextBox roomNumberTextBox;
		private System.Windows.Forms.Label roomLabel;
		private System.Windows.Forms.DateTimePicker dateOfEvictionDateTimePicker;
		private System.Windows.Forms.ComboBox bedClothesComboBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label settlementDateLabel;
		private System.Windows.Forms.Label bedClothesLabel;
		private System.Windows.Forms.Label residentRoomsIdLabel;
		private System.Windows.Forms.Label roomIdLabel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button deleteRentButton;
		private System.Windows.Forms.Label rentIdLabel;
		private System.Windows.Forms.Button deleteLivingButton;
	}
}