using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EhbOverflow
{

    public partial class EditNoteForm : Form
    {
        private Note noteToUpdate;
        public EditNoteForm(Note note)
        {
            InitializeComponent();
            noteToUpdate = note;
            txtEditTitle.Text = noteToUpdate.Title;
            txtEditContent.Text = noteToUpdate.Content;
        }

        private void btnSaveEditNote_Click(object sender, EventArgs e)
        {
            // Update the note properties with edited values
            noteToUpdate.Title = txtEditTitle.Text.Trim();
            noteToUpdate.Content = txtEditContent.Text.Trim();

            UpdateNoteInDatabase(noteToUpdate);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelEditNote_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateNoteInDatabase(Note note)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf"";Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string updateQuery = "UPDATE Notes SET Title = @Title, Content = @Content WHERE NoteId = @NoteId";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Title", note.Title);
                    command.Parameters.AddWithValue("@Content", note.Content);
                    command.Parameters.AddWithValue("@NoteId", note.NoteId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
