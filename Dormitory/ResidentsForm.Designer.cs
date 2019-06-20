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
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.residentsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// residentsDataGridView
			// 
			this.residentsDataGridView.AllowUserToAddRows = false;
			this.residentsDataGridView.AllowUserToDeleteRows = false;
			this.residentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.residentsDataGridView.Location = new System.Drawing.Point(15, 103);
			this.residentsDataGridView.Margin = new System.Windows.Forms.Padding(6);
			this.residentsDataGridView.MultiSelect = false;
			this.residentsDataGridView.Name = "residentsDataGridView";
			this.residentsDataGridView.ReadOnly = true;
			this.residentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.residentsDataGridView.Size = new System.Drawing.Size(1075, 407);
			this.residentsDataGridView.TabIndex = 0;
			this.residentsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.residentsDataGridView_CellClick);
			// 
			// residentIdLabel
			// 
			this.residentIdLabel.AutoSize = true;
			this.residentIdLabel.Location = new System.Drawing.Point(817, 73);
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
			this.selectButton.Location = new System.Drawing.Point(15, 15);
			this.selectButton.Margin = new System.Windows.Forms.Padding(6);
			this.selectButton.Name = "selectButton";
			this.selectButton.Size = new System.Drawing.Size(177, 35);
			this.selectButton.TabIndex = 2;
			this.selectButton.Text = "Выбрать";
			this.selectButton.UseVisualStyleBackColor = true;
			this.selectButton.Click += new System.EventHandler(this.settleButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(204, 15);
			this.addButton.Margin = new System.Windows.Forms.Padding(6);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(180, 35);
			this.addButton.TabIndex = 3;
			this.addButton.Text = "Добавить нового";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// nameFilterTextBox
			// 
			this.nameFilterTextBox.Location = new System.Drawing.Point(204, 62);
			this.nameFilterTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.nameFilterTextBox.Name = "nameFilterTextBox";
			this.nameFilterTextBox.Size = new System.Drawing.Size(180, 29);
			this.nameFilterTextBox.TabIndex = 4;
			this.nameFilterTextBox.TextChanged += new System.EventHandler(this.nameFilterTextBox_TextChanged);
			// 
			// searchSurnameLabel
			// 
			this.searchSurnameLabel.AutoSize = true;
			this.searchSurnameLabel.Location = new System.Drawing.Point(11, 65);
			this.searchSurnameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.searchSurnameLabel.Name = "searchSurnameLabel";
			this.searchSurnameLabel.Size = new System.Drawing.Size(181, 24);
			this.searchSurnameLabel.TabIndex = 5;
			this.searchSurnameLabel.Text = "Поиск по фамилии:";
			// 
			// searchOrganizationLabel
			// 
			this.searchOrganizationLabel.AutoSize = true;
			this.searchOrganizationLabel.Location = new System.Drawing.Point(396, 65);
			this.searchOrganizationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.searchOrganizationLabel.Name = "searchOrganizationLabel";
			this.searchOrganizationLabel.Size = new System.Drawing.Size(217, 24);
			this.searchOrganizationLabel.TabIndex = 6;
			this.searchOrganizationLabel.Text = "Поиск по организации:";
			// 
			// organizationFilterTextBox
			// 
			this.organizationFilterTextBox.Location = new System.Drawing.Point(625, 62);
			this.organizationFilterTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.organizationFilterTextBox.Name = "organizationFilterTextBox";
			this.organizationFilterTextBox.Size = new System.Drawing.Size(180, 29);
			this.organizationFilterTextBox.TabIndex = 7;
			this.organizationFilterTextBox.TextChanged += new System.EventHandler(this.organizationFilterTextBox_TextChanged);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(625, 18);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(180, 35);
			this.deleteButton.TabIndex = 8;
			this.deleteButton.Text = "Удалить";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// changeButton
			// 
			this.changeButton.Location = new System.Drawing.Point(415, 15);
			this.changeButton.Name = "changeButton";
			this.changeButton.Size = new System.Drawing.Size(180, 35);
			this.changeButton.TabIndex = 9;
			this.changeButton.Text = "Подробнее";
			this.changeButton.UseVisualStyleBackColor = true;
			this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label1.Location = new System.Drawing.Point(841, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(218, 61);
			this.label1.TabIndex = 10;
			this.label1.Text = "Жители";
			// 
			// ResidentsForm
			// 
			this.AcceptButton = this.selectButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1098, 525);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.changeButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.organizationFilterTextBox);
			this.Controls.Add(this.searchOrganizationLabel);
			this.Controls.Add(this.searchSurnameLabel);
			this.Controls.Add(this.nameFilterTextBox);
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
		private System.Windows.Forms.Label label1;
	}
}