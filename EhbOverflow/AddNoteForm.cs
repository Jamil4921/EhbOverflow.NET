using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AddNoteForm : Form
    {
        private User currentUser;
        public AddNoteForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnSaveAddNote_Click(object sender, EventArgs e)
        {
            string title = txtAddTitle.Text.Trim(); // Remove leading and trailing spaces
            string content = txtAddContent.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Please enter both a title and content for the note.");
                return; // Don't proceed if validation fails
            }

            // Perform validation if needed

            // Create a new Note object with the entered title and content
            Note newNote = new Note
            {
                Title = title,
                Content = content,
                CreatedDate = DateTime.Now,
                User = currentUser,
                UserId = currentUser.UserId,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName


            };

            InsertNoteIntoDatabase(newNote);

            // Add the new note to the user's collection
            currentUser.Notes.Add(newNote);

            // Indicate that the operation was successful
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelAddNote_Click(object sender, EventArgs e)
        {
            // Close the AddNoteForm without making any changes
            this.Close();
        }

        private void InsertNoteIntoDatabase(Note note)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf"";Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Notes (Title, Content, CreatedDate, UserId, FirstName, LastName) VALUES (@Title, @Content, @CreatedDate, @UserId, @FirstName, @LastName)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Title", note.Title);
                    command.Parameters.AddWithValue("@Content", note.Content);
                    command.Parameters.AddWithValue("@CreatedDate", note.CreatedDate);
                    command.Parameters.AddWithValue("@UserId", note.User.UserId);
                    command.Parameters.AddWithValue("@FirstName", note.User.FirstName);
                    command.Parameters.AddWithValue("@LastName", note.User.LastName);

                    command.ExecuteNonQuery();
                }
            }
        }



    }
}
