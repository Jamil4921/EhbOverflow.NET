namespace EhbOverflow
{
    partial class NoteManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBoxNotes;
        private TextBox txtTitle;
        private TextBox txtContent;

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
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.btnEditNote = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.ItemHeight = 20;
            this.listBoxNotes.Location = new System.Drawing.Point(16, 18);
            this.listBoxNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(265, 644);
            this.listBoxNotes.TabIndex = 5;
            this.listBoxNotes.SelectedIndexChanged += new System.EventHandler(this.listBoxNotes_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(368, 20);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(532, 27);
            this.txtTitle.TabIndex = 4;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(308, 86);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(592, 178);
            this.txtContent.TabIndex = 3;
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(308, 545);
            this.btnAddNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(133, 46);
            this.btnAddNote.TabIndex = 0;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // btnEditNote
            // 
            this.btnEditNote.Location = new System.Drawing.Point(452, 545);
            this.btnEditNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditNote.Name = "btnEditNote";
            this.btnEditNote.Size = new System.Drawing.Size(133, 46);
            this.btnEditNote.TabIndex = 1;
            this.btnEditNote.Text = "Edit Note";
            this.btnEditNote.Click += new System.EventHandler(this.btnEditNote_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(308, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // lblContent
            // 
            this.lblContent.Location = new System.Drawing.Point(308, 60);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(94, 21);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "Content:";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.Location = new System.Drawing.Point(309, 279);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(100, 20);
            this.lblCreatedDate.TabIndex = 0;
            this.lblCreatedDate.Text = "Created Date:";
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.Location = new System.Drawing.Point(415, 276);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.ReadOnly = true;
            this.txtCreatedDate.Size = new System.Drawing.Size(200, 27);
            this.txtCreatedDate.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(309, 312);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(100, 20);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(309, 345);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(100, 20);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name:";
            // 
            // NoteManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 752);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.txtCreatedDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.btnEditNote);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.listBoxNotes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NoteManagementForm";
            this.Text = "Note Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.Button btnEditNote;
        #endregion

        private Label lblTitle;
        private Label lblContent;
        private Label lblCreatedDate;
        private TextBox txtCreatedDate;
        private Label lblFirstName;
        private Label lblLastName;
    }

}
