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
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.acceptButton = new System.Windows.Forms.Button();
			this.organizationIdLabel = new System.Windows.Forms.Label();
			this.updateButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.organizationsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// organizationsDataGridView
			// 
			this.organizationsDataGridView.AllowUserToAddRows = false;
			this.organizationsDataGridView.AllowUserToDeleteRows = false;
			this.organizationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.organizationsDataGridView.Location = new System.Drawing.Point(15, 62);
			this.organizationsDataGridView.Margin = new System.Windows.Forms.Padding(6);
			this.organizationsDataGridView.MultiSelect = false;
			this.organizationsDataGridView.Name = "organizationsDataGridView";
			this.organizationsDataGridView.ReadOnly = true;
			this.organizationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.organizationsDataGridView.Size = new System.Drawing.Size(675, 292);
			this.organizationsDataGridView.TabIndex = 0;
			this.organizationsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.organizationsDataGridView_CellClick);
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(165, 20);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(97, 24);
			this.nameLabel.TabIndex = 2;
			this.nameLabel.Text = "Название";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(274, 20);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(266, 29);
			this.nameTextBox.TabIndex = 5;
			// 
			// acceptButton
			// 
			this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.acceptButton.Location = new System.Drawing.Point(15, 15);
			this.acceptButton.Margin = new System.Windows.Forms.Padding(6);
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.Size = new System.Drawing.Size(138, 35);
			this.acceptButton.TabIndex = 11;
			this.acceptButton.Text = "Выбрать";
			this.acceptButton.UseVisualStyleBackColor = true;
			this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
			// 
			// organizationIdLabel
			// 
			this.organizationIdLabel.AutoSize = true;
			this.organizationIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.organizationIdLabel.Location = new System.Drawing.Point(152, 3);
			this.organizationIdLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.organizationIdLabel.Name = "organizationIdLabel";
			this.organizationIdLabel.Size = new System.Drawing.Size(40, 17);
			this.organizationIdLabel.TabIndex = 12;
			this.organizationIdLabel.Text = "ОИД";
			this.organizationIdLabel.Visible = false;
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(552, 15);
			this.updateButton.Margin = new System.Windows.Forms.Padding(6);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(138, 35);
			this.updateButton.TabIndex = 13;
			this.updateButton.Text = "Обновить";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// OrganizationsForm
			// 
			this.AcceptButton = this.acceptButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(705, 361);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.organizationIdLabel);
			this.Controls.Add(this.acceptButton);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.organizationsDataGridView);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(6);
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
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Button acceptButton;
		private System.Windows.Forms.Label organizationIdLabel;
		private System.Windows.Forms.Button updateButton;
	}
}