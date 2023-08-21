namespace EhbOverflow
{
    partial class AddNoteForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtAddTitle;
        private TextBox txtAddContent;
        private Button btnSaveAddNote;
        private Button btnCancelAddNote;
        private Label lblAddTitle;
        private Label lblAddContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtAddTitle = new System.Windows.Forms.TextBox();
            this.txtAddContent = new System.Windows.Forms.TextBox();
            this.btnSaveAddNote = new System.Windows.Forms.Button();
            this.btnCancelAddNote = new System.Windows.Forms.Button();
            this.lblAddTitle = new System.Windows.Forms.Label(); // New label for title
            this.lblAddContent = new System.Windows.Forms.Label(); // New label for content

            // txtAddTitle
            this.txtAddTitle.Location = new System.Drawing.Point(12, 28); // Adjust Y coordinate
            this.txtAddTitle.Name = "txtAddTitle";
            this.txtAddTitle.Size = new System.Drawing.Size(300, 20);

            // lblAddTitle
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Location = new System.Drawing.Point(12, 12); // Adjust Y coordinate
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(30, 13);
            this.lblAddTitle.Text = "Title:";

            // txtAddContent
            this.txtAddContent.Location = new System.Drawing.Point(12, 78); // Adjust Y coordinate
            this.txtAddContent.Multiline = true;
            this.txtAddContent.Name = "txtAddContent";
            this.txtAddContent.Size = new System.Drawing.Size(300, 200);

            // lblAddContent
            this.lblAddContent.AutoSize = true;
            this.lblAddContent.Location = new System.Drawing.Point(12, 62); // Adjust Y coordinate
            this.lblAddContent.Name = "lblAddContent";
            this.lblAddContent.Size = new System.Drawing.Size(47, 13);
            this.lblAddContent.Text = "Content:";

            // btnSaveAddNote
            this.btnSaveAddNote.Location = new System.Drawing.Point(12, 294); // Adjust Y coordinate
            this.btnSaveAddNote.Name = "btnSaveAddNote";
            this.btnSaveAddNote.Size = new System.Drawing.Size(100, 30);
            this.btnSaveAddNote.Text = "Save";
            this.btnSaveAddNote.Click += new System.EventHandler(this.btnSaveAddNote_Click);

            // btnCancelAddNote
            this.btnCancelAddNote.Location = new System.Drawing.Point(118, 294); // Adjust Y coordinate
            this.btnCancelAddNote.Name = "btnCancelAddNote";
            this.btnCancelAddNote.Size = new System.Drawing.Size(100, 30);
            this.btnCancelAddNote.Text = "Cancel";
            this.btnCancelAddNote.Click += new System.EventHandler(this.btnCancelAddNote_Click);

            // AddNoteForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 336); // Adjust form size
            this.Controls.Add(this.btnCancelAddNote);
            this.Controls.Add(this.btnSaveAddNote);
            this.Controls.Add(this.txtAddContent);
            this.Controls.Add(this.txtAddTitle);
            this.Controls.Add(this.lblAddTitle); // Add the label for title
            this.Controls.Add(this.lblAddContent); // Add the label for content
            this.Name = "AddNoteForm";
            this.Text = "Add Note";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}
