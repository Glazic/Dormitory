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
			this.settleButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.nameFilterTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.residentsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// residentsDataGridView
			// 
			this.residentsDataGridView.AllowUserToAddRows = false;
			this.residentsDataGridView.AllowUserToDeleteRows = false;
			this.residentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.residentsDataGridView.Location = new System.Drawing.Point(12, 12);
			this.residentsDataGridView.MultiSelect = false;
			this.residentsDataGridView.Name = "residentsDataGridView";
			this.residentsDataGridView.ReadOnly = true;
			this.residentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.residentsDataGridView.Size = new System.Drawing.Size(714, 216);
			this.residentsDataGridView.TabIndex = 0;
			this.residentsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.residentsDataGridView_CellClick);
			// 
			// residentIdLabel
			// 
			this.residentIdLabel.AutoSize = true;
			this.residentIdLabel.Location = new System.Drawing.Point(52, 261);
			this.residentIdLabel.Name = "residentIdLabel";
			this.residentIdLabel.Size = new System.Drawing.Size(53, 13);
			this.residentIdLabel.TabIndex = 1;
			this.residentIdLabel.Text = "residentId";
			// 
			// settleButton
			// 
			this.settleButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.settleButton.Location = new System.Drawing.Point(406, 275);
			this.settleButton.Name = "settleButton";
			this.settleButton.Size = new System.Drawing.Size(75, 23);
			this.settleButton.TabIndex = 2;
			this.settleButton.Text = "settleButton";
			this.settleButton.UseVisualStyleBackColor = true;
			this.settleButton.Click += new System.EventHandler(this.settleButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(220, 342);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(116, 23);
			this.addButton.TabIndex = 3;
			this.addButton.Text = "Добавить нового";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// nameFilterTextBox
			// 
			this.nameFilterTextBox.Location = new System.Drawing.Point(45, 326);
			this.nameFilterTextBox.Name = "nameFilterTextBox";
			this.nameFilterTextBox.Size = new System.Drawing.Size(100, 20);
			this.nameFilterTextBox.TabIndex = 4;
			this.nameFilterTextBox.TextChanged += new System.EventHandler(this.nameFilterTextBox_TextChanged);
			// 
			// ResidentsForm
			// 
			this.AcceptButton = this.settleButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.nameFilterTextBox);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.settleButton);
			this.Controls.Add(this.residentIdLabel);
			this.Controls.Add(this.residentsDataGridView);
			this.Name = "ResidentsForm";
			this.Text = "ResidentsForm";
			this.Load += new System.EventHandler(this.residentsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.residentsDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView residentsDataGridView;
		private System.Windows.Forms.Label residentIdLabel;
		private System.Windows.Forms.Button settleButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.TextBox nameFilterTextBox;
	}
}