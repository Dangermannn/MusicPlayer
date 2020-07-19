namespace MusicPlayer.Forms
{
    partial class FormOpenedFiles
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxWithOpenedMusic = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxWithOpenedMusic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 456);
            this.panel1.TabIndex = 0;
            // 
            // listBoxWithOpenedMusic
            // 
            this.listBoxWithOpenedMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxWithOpenedMusic.FormattingEnabled = true;
            this.listBoxWithOpenedMusic.Location = new System.Drawing.Point(0, 0);
            this.listBoxWithOpenedMusic.Name = "listBoxWithOpenedMusic";
            this.listBoxWithOpenedMusic.Size = new System.Drawing.Size(800, 456);
            this.listBoxWithOpenedMusic.TabIndex = 0;
            // 
            // FormOpenedFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.Controls.Add(this.panel1);
            this.Name = "FormOpenedFiles";
            this.Text = "FormOpenedFiles";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxWithOpenedMusic;
    }
}