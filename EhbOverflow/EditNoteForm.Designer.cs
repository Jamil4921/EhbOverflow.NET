namespace EhbOverflow
{
    partial class EditNoteForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtEditTitle;
        private TextBox txtEditContent;
        private Button btnSaveEditNote;
        private Button btnCancelEditNote;

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
            this.txtEditTitle = new System.Windows.Forms.TextBox();
            this.txtEditContent = new System.Windows.Forms.TextBox();
            this.btnSaveEditNote = new System.Windows.Forms.Button();
            this.btnCancelEditNote = new System.Windows.Forms.Button();

            // txtEditTitle
            this.txtEditTitle.Location = new System.Drawing.Point(12, 12);
            this.txtEditTitle.Name = "txtEditTitle";
            this.txtEditTitle.Size = new System.Drawing.Size(300, 20);

            // txtEditContent
            this.txtEditContent.Location = new System.Drawing.Point(12, 38);
            this.txtEditContent.Multiline = true;
            this.txtEditContent.Name = "txtEditContent";
            this.txtEditContent.Size = new System.Drawing.Size(300, 200);

            // btnSaveEditNote
            this.btnSaveEditNote.Location = new System.Drawing.Point(12, 244);
            this.btnSaveEditNote.Name = "btnSaveEditNote";
            this.btnSaveEditNote.Size = new System.Drawing.Size(100, 30);
            this.btnSaveEditNote.Text = "Save";
            this.btnSaveEditNote.Click += new System.EventHandler(this.btnSaveEditNote_Click);

            // btnCancelEditNote
            this.btnCancelEditNote.Location = new System.Drawing.Point(118, 244);
            this.btnCancelEditNote.Name = "btnCancelEditNote";
            this.btnCancelEditNote.Size = new System.Drawing.Size(100, 30);
            this.btnCancelEditNote.Text = "Cancel";
            this.btnCancelEditNote.Click += new System.EventHandler(this.btnCancelEditNote_Click);

            // EditNoteForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 286);
            this.Controls.Add(this.btnCancelEditNote);
            this.Controls.Add(this.btnSaveEditNote);
            this.Controls.Add(this.txtEditContent);
            this.Controls.Add(this.txtEditTitle);
            this.Name = "EditNoteForm";
            this.Text = "Edit Note";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
