namespace FileRelatedParts
{
    partial class Form1
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
            this.WriteFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WriteFile
            // 
            this.WriteFile.Location = new System.Drawing.Point(87, 55);
            this.WriteFile.Name = "WriteFile";
            this.WriteFile.Size = new System.Drawing.Size(101, 50);
            this.WriteFile.TabIndex = 0;
            this.WriteFile.Text = "WriteFile";
            this.WriteFile.UseVisualStyleBackColor = true;
            this.WriteFile.Click += new System.EventHandler(this.WriteFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 202);
            this.Controls.Add(this.WriteFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WriteFile;
    }
}

