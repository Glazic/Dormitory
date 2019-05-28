namespace Dormitory
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.organizationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.residentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sectionsTabControl = new System.Windows.Forms.TabControl();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizationsToolStripMenuItem,
            this.residentsToolStripMenuItem,
            this.backupToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
			this.menuStrip1.Size = new System.Drawing.Size(951, 37);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "mainFormMenuStrip";
			// 
			// organizationsToolStripMenuItem
			// 
			this.organizationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.organizationsToolStripMenuItem.Name = "organizationsToolStripMenuItem";
			this.organizationsToolStripMenuItem.Size = new System.Drawing.Size(139, 29);
			this.organizationsToolStripMenuItem.Text = "Организации";
			this.organizationsToolStripMenuItem.Click += new System.EventHandler(this.OrganizationsToolStripMenuItem_Click);
			// 
			// residentsToolStripMenuItem
			// 
			this.residentsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.residentsToolStripMenuItem.Name = "residentsToolStripMenuItem";
			this.residentsToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
			this.residentsToolStripMenuItem.Text = "Жители";
			this.residentsToolStripMenuItem.Click += new System.EventHandler(this.residentsToolStripMenuItem_Click);
			// 
			// backupToolStripMenuItem
			// 
			this.backupToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
			this.backupToolStripMenuItem.Size = new System.Drawing.Size(171, 29);
			this.backupToolStripMenuItem.Text = "Копирование БД";
			this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
			// 
			// sectionsTabControl
			// 
			this.sectionsTabControl.ItemSize = new System.Drawing.Size(0, 29);
			this.sectionsTabControl.Location = new System.Drawing.Point(15, 43);
			this.sectionsTabControl.Margin = new System.Windows.Forms.Padding(6);
			this.sectionsTabControl.Name = "sectionsTabControl";
			this.sectionsTabControl.SelectedIndex = 0;
			this.sectionsTabControl.Size = new System.Drawing.Size(921, 593);
			this.sectionsTabControl.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(649, 0);
			this.button1.Margin = new System.Windows.Forms.Padding(6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 42);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(951, 644);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.sectionsTabControl);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Общежитие";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem organizationsToolStripMenuItem;
		private System.Windows.Forms.TabControl sectionsTabControl;
		private System.Windows.Forms.ToolStripMenuItem residentsToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
	}
}

