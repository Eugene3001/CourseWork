namespace CourseWork
{
    partial class Reference
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
            this.Ref = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Ref
            // 
            this.Ref.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ref.Location = new System.Drawing.Point(12, 12);
            this.Ref.Name = "Ref";
            this.Ref.Size = new System.Drawing.Size(877, 298);
            this.Ref.TabIndex = 0;
            this.Ref.Text = "";
            // 
            // Reference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 320);
            this.Controls.Add(this.Ref);
            this.Name = "Reference";
            this.Text = "Reference";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Ref;
    }
}