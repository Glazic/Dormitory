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
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "mainFormMenuStrip";
			// 
			// organizationsToolStripMenuItem
			// 
			this.organizationsToolStripMenuItem.Name = "organizationsToolStripMenuItem";
			this.organizationsToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
			this.organizationsToolStripMenuItem.Text = "Организации";
			this.organizationsToolStripMenuItem.Click += new System.EventHandler(this.OrganizationsToolStripMenuItem_Click);
			// 
			// residentsToolStripMenuItem
			// 
			this.residentsToolStripMenuItem.Name = "residentsToolStripMenuItem";
			this.residentsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.residentsToolStripMenuItem.Text = "Жители";
			this.residentsToolStripMenuItem.Click += new System.EventHandler(this.residentsToolStripMenuItem_Click);
			// 
			// backupToolStripMenuItem
			// 
			this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
			this.backupToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
			this.backupToolStripMenuItem.Text = "Копирование БД";
			this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
			// 
			// sectionsTabControl
			// 
			this.sectionsTabControl.Location = new System.Drawing.Point(13, 40);
			this.sectionsTabControl.Name = "sectionsTabControl";
			this.sectionsTabControl.SelectedIndex = 0;
			this.sectionsTabControl.Size = new System.Drawing.Size(700, 400);
			this.sectionsTabControl.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(107, 462);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.sectionsTabControl);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
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

