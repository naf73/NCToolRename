namespace NCToolRename
{
    partial class FormMain
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
            this.rootFolderTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserButton = new System.Windows.Forms.Button();
            this.renameToolsButton = new System.Windows.Forms.Button();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.renameNCToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.springToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.versionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootFolderTextBox
            // 
            this.rootFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootFolderTextBox.Location = new System.Drawing.Point(12, 12);
            this.rootFolderTextBox.Name = "rootFolderTextBox";
            this.rootFolderTextBox.Size = new System.Drawing.Size(474, 20);
            this.rootFolderTextBox.TabIndex = 0;
            // 
            // folderBrowserButton
            // 
            this.folderBrowserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderBrowserButton.Location = new System.Drawing.Point(492, 10);
            this.folderBrowserButton.Name = "folderBrowserButton";
            this.folderBrowserButton.Size = new System.Drawing.Size(75, 23);
            this.folderBrowserButton.TabIndex = 1;
            this.folderBrowserButton.Text = "Обзор";
            this.folderBrowserButton.UseVisualStyleBackColor = true;
            this.folderBrowserButton.Click += new System.EventHandler(this.FolderBrowserButton_Click);
            // 
            // renameToolsButton
            // 
            this.renameToolsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renameToolsButton.Location = new System.Drawing.Point(12, 38);
            this.renameToolsButton.Name = "renameToolsButton";
            this.renameToolsButton.Size = new System.Drawing.Size(555, 23);
            this.renameToolsButton.TabIndex = 2;
            this.renameToolsButton.Text = "Переименовать инструменты в УП";
            this.renameToolsButton.UseVisualStyleBackColor = true;
            this.renameToolsButton.Click += new System.EventHandler(this.RenameToolsButton_Click);
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputRichTextBox.Location = new System.Drawing.Point(12, 67);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.Size = new System.Drawing.Size(555, 345);
            this.outputRichTextBox.TabIndex = 3;
            this.outputRichTextBox.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameNCToolStripProgressBar,
            this.springToolStripStatusLabel,
            this.versionToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(579, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // renameNCToolStripProgressBar
            // 
            this.renameNCToolStripProgressBar.AutoToolTip = true;
            this.renameNCToolStripProgressBar.Name = "renameNCToolStripProgressBar";
            this.renameNCToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // springToolStripStatusLabel
            // 
            this.springToolStripStatusLabel.Name = "springToolStripStatusLabel";
            this.springToolStripStatusLabel.Size = new System.Drawing.Size(247, 17);
            this.springToolStripStatusLabel.Spring = true;
            // 
            // versionToolStripStatusLabel
            // 
            this.versionToolStripStatusLabel.Name = "versionToolStripStatusLabel";
            this.versionToolStripStatusLabel.Size = new System.Drawing.Size(84, 17);
            this.versionToolStripStatusLabel.Text = "version: 1.0.0.0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 437);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.outputRichTextBox);
            this.Controls.Add(this.renameToolsButton);
            this.Controls.Add(this.folderBrowserButton);
            this.Controls.Add(this.rootFolderTextBox);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCToolRename";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rootFolderTextBox;
        private System.Windows.Forms.Button folderBrowserButton;
        private System.Windows.Forms.Button renameToolsButton;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar renameNCToolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel springToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel versionToolStripStatusLabel;
    }
}

