namespace async_delete_many_files
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
            this.buttonStartOrRestart = new System.Windows.Forms.Button();
            this.textBoxRemaining = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartOrRestart
            // 
            this.buttonStartOrRestart.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartOrRestart.Location = new System.Drawing.Point(12, 25);
            this.buttonStartOrRestart.Name = "buttonStartOrRestart";
            this.buttonStartOrRestart.Size = new System.Drawing.Size(260, 23);
            this.buttonStartOrRestart.TabIndex = 0;
            this.buttonStartOrRestart.Text = "START OR RESTART VALIDATION";
            this.buttonStartOrRestart.UseVisualStyleBackColor = true;
            // 
            // textBoxRemaining
            // 
            this.textBoxRemaining.Location = new System.Drawing.Point(169, 58);
            this.textBoxRemaining.Name = "textBoxRemaining";
            this.textBoxRemaining.ReadOnly = true;
            this.textBoxRemaining.Size = new System.Drawing.Size(100, 20);
            this.textBoxRemaining.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Progress";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(169, 84);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRemaining);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStartOrRestart);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartOrRestart;
        private System.Windows.Forms.TextBox textBoxRemaining;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
    }
}

