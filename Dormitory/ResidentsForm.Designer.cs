namespace Dormitory
{
	partial class ResidentsForm
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
			this.residentsDataGridView = new System.Windows.Forms.DataGridView();
			this.residentIdLabel = new System.Windows.Forms.Label();
			this.selectButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.nameFilterTextBox = new System.Windows.Forms.TextBox();
			this.searchSurnameLabel = new System.Windows.Forms.Label();
			this.searchOrganizationLabel = new System.Windows.Forms.Label();
			this.organizationFilterTextBox = new System.Windows.Forms.TextBox();
			this.deleteButton = new System.Windows.Forms.Button();
			this.changeButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.searchButton = new System.Windows.Forms.Button();
			this.updateButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.residentsDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// residentsDataGridView
			// 
			this.residentsDataGridView.AllowUserToAddRows = false;
			this.residentsDataGridView.AllowUserToDeleteRows = false;
			this.residentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.residentsDataGridView.Location = new System.Drawing.Point(15, 106);
			this.residentsDataGridView.Margin = new System.Windows.Forms.Padding(6);
			this.residentsDataGridView.MultiSelect = false;
			this.residentsDataGridView.Name = "residentsDataGridView";
			this.residentsDataGridView.ReadOnly = true;
			this.residentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.residentsDataGridView.Size = new System.Drawing.Size(1075, 404);
			this.residentsDataGridView.TabIndex = 0;
			this.residentsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.residentsDataGridView_CellClick);
			// 
			// residentIdLabel
			// 
			this.residentIdLabel.AutoSize = true;
			this.residentIdLabel.Location = new System.Drawing.Point(991, 76);
			this.residentIdLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.residentIdLabel.Name = "residentIdLabel";
			this.residentIdLabel.Size = new System.Drawing.Size(92, 24);
			this.residentIdLabel.TabIndex = 1;
			this.residentIdLabel.Text = "residentId";
			this.residentIdLabel.Visible = false;
			// 
			// selectButton
			// 
			this.selectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.selectButton.Location = new System.Drawing.Point(15, 58);
			this.selectButton.Margin = new System.Windows.Forms.Padding(6);
			this.selectButton.Name = "selectButton";
			this.selectButton.Size = new System.Drawing.Size(183, 36);
			this.selectButton.TabIndex = 2;
			this.selectButton.Text = "Выбрать";
			this.selectButton.UseVisualStyleBackColor = true;
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(15, 12);
			this.addButton.Margin = new System.Windows.Forms.Padding(6);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(183, 38);
			this.addButton.TabIndex = 3;
			this.addButton.Text = "Добавить нового";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// nameFilterTextBox
			// 
			this.nameFilterTextBox.Location = new System.Drawing.Point(181, 20);
			this.nameFilterTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.nameFilterTextBox.Name = "nameFilterTextBox";
			this.nameFilterTextBox.Size = new System.Drawing.Size(209, 29);
			this.nameFilterTextBox.TabIndex = 4;
			// 
			// searchSurnameLabel
			// 
			this.searchSurnameLabel.AutoSize = true;
			this.searchSurnameLabel.Location = new System.Drawing.Point(9, 25);
			this.searchSurnameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.searchSurnameLabel.Name = "searchSurnameLabel";
			this.searchSurnameLabel.Size = new System.Drawing.Size(124, 24);
			this.searchSurnameLabel.TabIndex = 5;
			this.searchSurnameLabel.Text = "По фамилии:";
			// 
			// searchOrganizationLabel
			// 
			this.searchOrganizationLabel.AutoSize = true;
			this.searchOrganizationLabel.Location = new System.Drawing.Point(9, 57);
			this.searchOrganizationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.searchOrganizationLabel.Name = "searchOrganizationLabel";
			this.searchOrganizationLabel.Size = new System.Drawing.Size(160, 24);
			this.searchOrganizationLabel.TabIndex = 6;
			this.searchOrganizationLabel.Text = "По организации:";
			// 
			// organizationFilterTextBox
			// 
			this.organizationFilterTextBox.Location = new System.Drawing.Point(181, 52);
			this.organizationFilterTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.organizationFilterTextBox.Name = "organizationFilterTextBox";
			this.organizationFilterTextBox.Size = new System.Drawing.Size(209, 29);
			this.organizationFilterTextBox.TabIndex = 7;
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(207, 12);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(175, 35);
			this.deleteButton.TabIndex = 8;
			this.deleteButton.Text = "Удалить";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// changeButton
			// 
			this.changeButton.Location = new System.Drawing.Point(207, 58);
			this.changeButton.Name = "changeButton";
			this.changeButton.Size = new System.Drawing.Size(175, 35);
			this.changeButton.TabIndex = 9;
			this.changeButton.Text = "Подробнее";
			this.changeButton.UseVisualStyleBackColor = true;
			this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.searchButton);
			this.groupBox1.Controls.Add(this.nameFilterTextBox);
			this.groupBox1.Controls.Add(this.searchSurnameLabel);
			this.groupBox1.Controls.Add(this.searchOrganizationLabel);
			this.groupBox1.Controls.Add(this.organizationFilterTextBox);
			this.groupBox1.Location = new System.Drawing.Point(388, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(545, 90);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Фильтр";
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(395, 20);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(144, 62);
			this.searchButton.TabIndex = 8;
			this.searchButton.Text = "Поиск";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(939, 23);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(144, 61);
			this.updateButton.TabIndex = 9;
			this.updateButton.Text = "Обновить";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// ResidentsForm
			// 
			this.AcceptButton = this.selectButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1098, 525);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.changeButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.selectButton);
			this.Controls.Add(this.residentIdLabel);
			this.Controls.Add(this.residentsDataGridView);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "ResidentsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Жители";
			this.Load += new System.EventHandler(this.residentsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.residentsDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView residentsDataGridView;
		private System.Windows.Forms.Label residentIdLabel;
		private System.Windows.Forms.Button selectButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.TextBox nameFilterTextBox;
		private System.Windows.Forms.Label searchSurnameLabel;
		private System.Windows.Forms.Label searchOrganizationLabel;
		private System.Windows.Forms.TextBox organizationFilterTextBox;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button changeButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Button updateButton;
	}
}