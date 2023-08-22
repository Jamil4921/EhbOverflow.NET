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
        private ComboBox comboBoxCategories;

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
            this.txtAddTitle = new System.Windows.Forms.TextBox();
            this.txtAddContent = new System.Windows.Forms.TextBox();
            this.btnSaveAddNote = new System.Windows.Forms.Button();
            this.btnCancelAddNote = new System.Windows.Forms.Button();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.lblAddContent = new System.Windows.Forms.Label();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAddTitle
            // 
            this.txtAddTitle.Location = new System.Drawing.Point(13, 43);
            this.txtAddTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddTitle.Name = "txtAddTitle";
            this.txtAddTitle.Size = new System.Drawing.Size(399, 27);
            this.txtAddTitle.TabIndex = 3;
            // 
            // txtAddContent
            // 
            this.txtAddContent.Location = new System.Drawing.Point(13, 181);
            this.txtAddContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddContent.Multiline = true;
            this.txtAddContent.Name = "txtAddContent";
            this.txtAddContent.Size = new System.Drawing.Size(399, 306);
            this.txtAddContent.TabIndex = 2;
            // 
            // btnSaveAddNote
            // 
            this.btnSaveAddNote.Location = new System.Drawing.Point(13, 513);
            this.btnSaveAddNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveAddNote.Name = "btnSaveAddNote";
            this.btnSaveAddNote.Size = new System.Drawing.Size(133, 46);
            this.btnSaveAddNote.TabIndex = 1;
            this.btnSaveAddNote.Text = "Save";
            this.btnSaveAddNote.Click += new System.EventHandler(this.btnSaveAddNote_Click);
            // 
            // btnCancelAddNote
            // 
            this.btnCancelAddNote.Location = new System.Drawing.Point(154, 513);
            this.btnCancelAddNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelAddNote.Name = "btnCancelAddNote";
            this.btnCancelAddNote.Size = new System.Drawing.Size(133, 46);
            this.btnCancelAddNote.TabIndex = 0;
            this.btnCancelAddNote.Text = "Cancel";
            this.btnCancelAddNote.Click += new System.EventHandler(this.btnCancelAddNote_Click);
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Location = new System.Drawing.Point(16, 18);
            this.lblAddTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(41, 20);
            this.lblAddTitle.TabIndex = 4;
            this.lblAddTitle.Text = "Title:";
            // 
            // lblAddContent
            // 
            this.lblAddContent.AutoSize = true;
            this.lblAddContent.Location = new System.Drawing.Point(13, 156);
            this.lblAddContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddContent.Name = "lblAddContent";
            this.lblAddContent.Size = new System.Drawing.Size(64, 20);
            this.lblAddContent.TabIndex = 5;
            this.lblAddContent.Text = "Content:";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(121, 28);
            this.comboBoxCategories.TabIndex = 0;
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(12, 114);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(300, 28);
            this.cmbCategories.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Category :";
            // 
            // AddNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelAddNote);
            this.Controls.Add(this.btnSaveAddNote);
            this.Controls.Add(this.txtAddContent);
            this.Controls.Add(this.txtAddTitle);
            this.Controls.Add(this.lblAddTitle);
            this.Controls.Add(this.lblAddContent);
            this.Controls.Add(this.cmbCategories);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddNoteForm";
            this.Text = "Add Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Label label1;
        private ComboBox cmbCategories;
    }
}
