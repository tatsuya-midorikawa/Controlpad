
namespace ControlPadSampleForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ContentArea = new System.Windows.Forms.TextBox();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ContentArea
            // 
            this.ContentArea.Location = new System.Drawing.Point(12, 12);
            this.ContentArea.Multiline = true;
            this.ContentArea.Name = "ContentArea";
            this.ContentArea.Size = new System.Drawing.Size(247, 437);
            this.ContentArea.TabIndex = 0;
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(265, 12);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(82, 23);
            this.UndoButton.TabIndex = 1;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(265, 41);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(82, 23);
            this.RedoButton.TabIndex = 2;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(265, 397);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(82, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(265, 426);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(82, 23);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 461);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.ContentArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ContentArea;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ClearButton;
    }
}

