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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf"";Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Login successful!");

                        // Retrieve the user's information from the database here, e.g., using a SELECT query
                        User loggedInUser = RetrieveUserInformation(email);

                        // Close the current LoginForm
                        this.Hide();

                        // Show NoteManagementForm and pass the logged-in user object
                        NoteManagementForm noteManagementForm = new NoteManagementForm(loggedInUser);
                        noteManagementForm.ShowDialog();

                        // Close the application after NoteManagementForm is closed
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Incorrect email or password.");
                    }
                }
            }
        }

        private User RetrieveUserInformation(string email)
        {
            User user = null;

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\furqa\OneDrive - Erasmushogeschool Brussel\Documenten\EhbUsers.mdf"";Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                string selectQuery = "SELECT UserId, FirstName, LastName, Email FROM Users WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = (int)reader["UserId"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"]
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}
