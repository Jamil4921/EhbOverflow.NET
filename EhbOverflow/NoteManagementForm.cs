using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EhbOverflow
{
    public partial class NoteManagementForm : Form
    {
        private User currentUser;

        public NoteManagementForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserNotesFromDatabase();
            UpdateNoteList();
            
        }

        private void UpdateNoteList()
        {
            Console.WriteLine("Updating note list...");
            listBoxNotes.Items.Clear();

            foreach (Note note in currentUser.Notes)
            {
                listBoxNotes.Items.Add(note.Title);
            }

            listBoxNotes.Refresh();


        }

        private void listBoxNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxNotes.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < currentUser.Notes.Count)
            {
                Note selectedNote = currentUser.Notes[selectedIndex];
                txtTitle.Text = selectedNote.Title;
                txtContent.Text = selectedNote.Content;
                txtCreatedDate.Text = selectedNote.CreatedDate.ToString();
                lblFirstName.Text = selectedNote.FirstName;
                lblLastName.Text = selectedNote.LastName;

                // Enable the "Edit" button only if the selected note is associated with the current user
                btnEditNote.Enabled = selectedNote.User.UserId == currentUser.UserId;
            }
        }


        private void btnAddNote_Click(object sender, EventArgs e)
        {
            AddNoteForm addNoteForm = new AddNoteForm(currentUser);
            if (addNoteForm.ShowDialog() == DialogResult.OK)
            {
                UpdateNoteList();
            }
        }

        private void btnEditNote_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxNotes.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < currentUser.Notes.Count)
            {
                Note selectedNote = currentUser.Notes[selectedIndex];

                if (selectedNote.User.UserId == currentUser.UserId) // Check if the note belongs to the current user
                {
                    EditNoteForm editNoteForm = new EditNoteForm(selectedNote);
                    if (editNoteForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateNoteList();
                    }
                }
                else
                {
                    MessageBox.Show("You can only edit your own notes.");
                }
            }
        }


        private void LoadUserNotesFromDatabase()
        {
            currentUser.Notes.Clear();

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf"";Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Notes";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Note note = new Note
                            {
                                NoteId = (int)reader["NoteId"],
                                Title = (string)reader["Title"],
                                Content = (string)reader["Content"],
                                CreatedDate = (DateTime)reader["CreatedDate"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"]
                            };

                            int userId = (int)reader["UserId"];
                            // Retrieve the associated user information separately
                            User associatedUser = GetUserFromDatabase(userId);
                            note.User = associatedUser;

                            currentUser.Notes.Add(note);
                        }
                    }
                }
            }
        }


        private User GetUserFromDatabase(int userId)
        {
            User user = null;

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf"";Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Users WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = (int)reader["UserId"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                            };
                        }
                    }
                }
            }

            return user;
        }


    }

}
