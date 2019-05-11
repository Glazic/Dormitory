namespace Dormitory
{
	partial class OrganizationsForm
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
			this.organizationsDataGridView = new System.Windows.Forms.DataGridView();
			this.addButton = new System.Windows.Forms.Button();
			this.nameLabel = new System.Windows.Forms.Label();
			this.addressLabel = new System.Windows.Forms.Label();
			this.requisitesLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.addressTextBox = new System.Windows.Forms.TextBox();
			this.requisitesTextBox = new System.Windows.Forms.TextBox();
			this.deleteButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.acceptButton = new System.Windows.Forms.Button();
			this.organizationIdLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.organizationsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// organizationsDataGridView
			// 
			this.organizationsDataGridView.AllowUserToAddRows = false;
			this.organizationsDataGridView.AllowUserToDeleteRows = false;
			this.organizationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.organizationsDataGridView.Location = new System.Drawing.Point(12, 12);
			this.organizationsDataGridView.MultiSelect = false;
			this.organizationsDataGridView.Name = "organizationsDataGridView";
			this.organizationsDataGridView.ReadOnly = true;
			this.organizationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.organizationsDataGridView.Size = new System.Drawing.Size(433, 150);
			this.organizationsDataGridView.TabIndex = 0;
			this.organizationsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.organizationsDataGridView_CellClick);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(556, 203);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(511, 12);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(57, 13);
			this.nameLabel.TabIndex = 2;
			this.nameLabel.Text = "Название";
			// 
			// addressLabel
			// 
			this.addressLabel.AutoSize = true;
			this.addressLabel.Location = new System.Drawing.Point(511, 38);
			this.addressLabel.Name = "addressLabel";
			this.addressLabel.Size = new System.Drawing.Size(38, 13);
			this.addressLabel.TabIndex = 3;
			this.addressLabel.Text = "Адрес";
			// 
			// requisitesLabel
			// 
			this.requisitesLabel.AutoSize = true;
			this.requisitesLabel.Location = new System.Drawing.Point(511, 64);
			this.requisitesLabel.Name = "requisitesLabel";
			this.requisitesLabel.Size = new System.Drawing.Size(63, 13);
			this.requisitesLabel.TabIndex = 4;
			this.requisitesLabel.Text = "Реквизиты";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(595, 9);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(173, 20);
			this.nameTextBox.TabIndex = 5;
			// 
			// addressTextBox
			// 
			this.addressTextBox.Location = new System.Drawing.Point(595, 35);
			this.addressTextBox.Name = "addressTextBox";
			this.addressTextBox.Size = new System.Drawing.Size(173, 20);
			this.addressTextBox.TabIndex = 6;
			// 
			// requisitesTextBox
			// 
			this.requisitesTextBox.Location = new System.Drawing.Point(595, 61);
			this.requisitesTextBox.Name = "requisitesTextBox";
			this.requisitesTextBox.Size = new System.Drawing.Size(173, 20);
			this.requisitesTextBox.TabIndex = 7;
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(718, 203);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 9;
			this.deleteButton.Text = "Удалить";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(637, 203);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 10;
			this.saveButton.Text = "Сохранить";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// acceptButton
			// 
			this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.acceptButton.Location = new System.Drawing.Point(514, 109);
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.Size = new System.Drawing.Size(75, 23);
			this.acceptButton.TabIndex = 11;
			this.acceptButton.Text = "Выбрать";
			this.acceptButton.UseVisualStyleBackColor = true;
			this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
			// 
			// organizationIdLabel
			// 
			this.organizationIdLabel.AutoSize = true;
			this.organizationIdLabel.Location = new System.Drawing.Point(595, 109);
			this.organizationIdLabel.Name = "organizationIdLabel";
			this.organizationIdLabel.Size = new System.Drawing.Size(94, 13);
			this.organizationIdLabel.TabIndex = 12;
			this.organizationIdLabel.Text = "Организация ИД";
			// 
			// OrganizationsForm
			// 
			this.AcceptButton = this.acceptButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.organizationIdLabel);
			this.Controls.Add(this.acceptButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.requisitesTextBox);
			this.Controls.Add(this.addressTextBox);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.requisitesLabel);
			this.Controls.Add(this.addressLabel);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.organizationsDataGridView);
			this.Name = "OrganizationsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Организации";
			this.Load += new System.EventHandler(this.OrganizationsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.organizationsDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView organizationsDataGridView;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label addressLabel;
		private System.Windows.Forms.Label requisitesLabel;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox addressTextBox;
		private System.Windows.Forms.TextBox requisitesTextBox;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button acceptButton;
		private System.Windows.Forms.Label organizationIdLabel;
	}
}