namespace MusicPlayer.Forms
{
    partial class FormAllPlaylists
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
            this.flowLayoutPanelWithPlaylists = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelWithPlaylists
            // 
            this.flowLayoutPanelWithPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelWithPlaylists.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelWithPlaylists.Name = "flowLayoutPanelWithPlaylists";
            this.flowLayoutPanelWithPlaylists.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanelWithPlaylists.TabIndex = 0;
            // 
            // FormAllPlaylists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelWithPlaylists);
            this.Name = "FormAllPlaylists";
            this.Text = "FormAllPlaylists";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelWithPlaylists;
    }
}