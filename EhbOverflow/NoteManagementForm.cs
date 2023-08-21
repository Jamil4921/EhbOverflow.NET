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
                // Display the selected note's details in textboxes
                Note selectedNote = currentUser.Notes[selectedIndex];
                txtTitle.Text = selectedNote.Title;
                txtContent.Text = selectedNote.Content;
                txtCreatedDate.Text = selectedNote.CreatedDate.ToString();
                lblFirstName.Text = selectedNote.FirstName;
                lblLastName.Text =  selectedNote.LastName;
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

                //EditNoteForm editNoteForm = new EditNoteForm(selectedNote);
                //editNoteForm.ShowDialog();

                // After the EditNoteForm is closed, update the note list
                UpdateNoteList();
            }
        }

        private void LoadUserNotesFromDatabase()
        {
            currentUser.Notes.Clear(); 

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Notes WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", currentUser.UserId);

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

                            currentUser.Notes.Add(note); 
                        }
                    }
                }
            }
        }


    }

}
