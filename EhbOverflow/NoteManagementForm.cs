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


                btnEditNote.Enabled = selectedNote.User.UserId == currentUser.UserId;
                btnDeleteNote.Enabled = selectedNote.User.UserId == currentUser.UserId;

                using (var context = new AppDbContext())
                {
                    var category = context.Categories.FirstOrDefault(c => c.CategoryId == selectedNote.CategoryId);
                    if (category != null)
                    {
                        lblCategory.Text = "Category: " + category.SubjectName;
                    }
                    else
                    {
                        lblCategory.Text = "Category: N/A";
                    }
                }
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

                if (selectedNote.User.UserId == currentUser.UserId) 
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

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxNotes.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < currentUser.Notes.Count)
            {
                Note selectedNote = currentUser.Notes[selectedIndex];

                if (selectedNote.User.UserId == currentUser.UserId) 
                {
                    if (MessageBox.Show("Are you sure you want to delete this note?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteNoteFromDatabase(selectedNote);
                        currentUser.Notes.Remove(selectedNote);
                        UpdateNoteList();
                    }
                }
                else
                {
                    MessageBox.Show("You can only delete your own notes.");
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
                                LastName = (string)reader["LastName"],
                                //CategoryName = (string)reader["Category"],
                                
                            };

                            int userId = (int)reader["UserId"];
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

        private void DeleteNoteFromDatabase(Note note)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Notes WHERE NoteId = @NoteId";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@NoteId", note.NoteId);
                    command.ExecuteNonQuery();
                }
            }
        }


    }

}
