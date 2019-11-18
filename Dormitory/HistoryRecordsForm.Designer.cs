namespace Dormitory
{
	partial class HistoryRecordsForm
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
			this.historyDataGridView = new System.Windows.Forms.DataGridView();
			this.clearButton = new System.Windows.Forms.Button();
			this.actionTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// historyDataGridView
			// 
			this.historyDataGridView.AllowUserToAddRows = false;
			this.historyDataGridView.AllowUserToDeleteRows = false;
			this.historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.historyDataGridView.Location = new System.Drawing.Point(6, 114);
			this.historyDataGridView.Name = "historyDataGridView";
			this.historyDataGridView.ReadOnly = true;
			this.historyDataGridView.Size = new System.Drawing.Size(873, 324);
			this.historyDataGridView.TabIndex = 0;
			this.historyDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.historyDataGridView_CellClick);
			// 
			// clearButton
			// 
			this.clearButton.Location = new System.Drawing.Point(6, 12);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(75, 23);
			this.clearButton.TabIndex = 1;
			this.clearButton.Text = "Clear";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// actionTextBox
			// 
			this.actionTextBox.Location = new System.Drawing.Point(87, 15);
			this.actionTextBox.Multiline = true;
			this.actionTextBox.Name = "actionTextBox";
			this.actionTextBox.ReadOnly = true;
			this.actionTextBox.Size = new System.Drawing.Size(792, 93);
			this.actionTextBox.TabIndex = 2;
			// 
			// HistoryRecordsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(891, 450);
			this.Controls.Add(this.actionTextBox);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.historyDataGridView);
			this.Name = "HistoryRecordsForm";
			this.Text = "HistoryRecordsForm";
			this.Load += new System.EventHandler(this.HistoryRecordsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView historyDataGridView;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.TextBox actionTextBox;
	}
}