namespace MusicPlayer.Forms
{
    partial class FormCreatePlaylist
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
            this.labelPlaylistName = new System.Windows.Forms.Label();
            this.textBoxPlaylistName = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPlaylistName
            // 
            this.labelPlaylistName.AutoSize = true;
            this.labelPlaylistName.Location = new System.Drawing.Point(13, 13);
            this.labelPlaylistName.Name = "labelPlaylistName";
            this.labelPlaylistName.Size = new System.Drawing.Size(71, 13);
            this.labelPlaylistName.TabIndex = 0;
            this.labelPlaylistName.Text = "Playlist name:";
            // 
            // textBoxPlaylistName
            // 
            this.textBoxPlaylistName.Location = new System.Drawing.Point(101, 13);
            this.textBoxPlaylistName.Name = "textBoxPlaylistName";
            this.textBoxPlaylistName.Size = new System.Drawing.Size(287, 20);
            this.textBoxPlaylistName.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(220, 56);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(101, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormCreatePlaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 96);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.textBoxPlaylistName);
            this.Controls.Add(this.labelPlaylistName);
            this.Name = "FormCreatePlaylist";
            this.Text = "FormCreatePlaylist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlaylistName;
        private System.Windows.Forms.TextBox textBoxPlaylistName;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}