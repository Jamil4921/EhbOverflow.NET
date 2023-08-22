using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EhbOverflow
{
    public partial class AddNoteForm : Form
    {
        private User currentUser;
        private Note newNote;
        private OpenFileDialog openFileDialog1;
        private string imagePath = "";

        public AddNoteForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            newNote = new Note();

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;

            using (var context = new AppDbContext())
            {
                var categories = context.Categories.ToList();
                cmbCategories.DataSource = categories;
                cmbCategories.DisplayMember = "SubjectName";
                cmbCategories.ValueMember = "CategoryId";
            }
        }


        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;


            }
        }





        private void btnSaveAddNote_Click(object sender, EventArgs e)
        {
            string title = txtAddTitle.Text.Trim();
            string content = txtAddContent.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Please enter both a title and content for the note.");
                return;
            }

            if (cmbCategories.SelectedItem is Categories selectedCategory)
            {
                Note newNote = new Note
                {
                    Title = title,
                    Content = content,
                    CreatedDate = DateTime.Now,
                    User = currentUser,
                    UserId = currentUser.UserId,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    CategoryId = selectedCategory.CategoryId,
                    ImagePath = imagePath
                };


                InsertNoteIntoDatabase(newNote);

                currentUser.Notes.Add(newNote);

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }




        private void btnCancelAddNote_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void InsertNoteIntoDatabase(Note note)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf;Integrated Security=True;Connect Timeout=30"))
        {
        connection.Open();

        string insertQuery = "INSERT INTO Notes (Title, Content, CreatedDate, UserId, FirstName, LastName, CategoryId, ImagePath) " +
                             "VALUES (@Title, @Content, @CreatedDate, @UserId, @FirstName, @LastName, @CategoryId, @ImagePath)";
        using (SqlCommand command = new SqlCommand(insertQuery, connection))
        {
            command.Parameters.AddWithValue("@Title", note.Title);
            command.Parameters.AddWithValue("@Content", note.Content);
            command.Parameters.AddWithValue("@CreatedDate", note.CreatedDate);
            command.Parameters.AddWithValue("@UserId", note.User.UserId);
            command.Parameters.AddWithValue("@FirstName", note.User.FirstName);
            command.Parameters.AddWithValue("@LastName", note.User.LastName);
            command.Parameters.AddWithValue("@CategoryId", note.CategoryId);
            command.Parameters.AddWithValue("@ImagePath", note.ImagePath); 

            command.ExecuteNonQuery();
        }
    }
}




    }
}
