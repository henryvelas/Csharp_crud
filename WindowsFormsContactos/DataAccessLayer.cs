using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsContactos
{
    public class DataAccessLayer
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Contacts;Data Source=DESKTOP-0VKUPNK\\SQLEXPRESS");

        public void InsertContacts(Contacts contacts)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO Contacts_ (Firstname, Lastname, Phone, Address) VALUES (@Fistname, @Lastname,@Phone, @Address)";

                SqlParameter Firstname = new SqlParameter("@Fistname", contacts .Firstname );
                SqlParameter Lastname = new SqlParameter("@Lastname", contacts .Lastname);
                SqlParameter Phone = new SqlParameter("@Phone", contacts .Phone);
                SqlParameter Address = new SqlParameter("@Address", contacts .Address);

                SqlCommand command =new SqlCommand (query,conn);
                command .Parameters .Add (Firstname); 
                command .Parameters .Add (Lastname);
                command .Parameters .Add (Phone);
                command .Parameters .Add (Address);

                command .ExecuteNonQuery();

                MessageBox.Show("agregado con exito");

                

            }
            catch (Exception)
            {
                throw;
            }
            finally
            { 
                conn.Close(); 
            }

        }

        public void UpdateContacts(Contacts contacts) 
        {
            try
            {
                conn.Open();
                string query = "UPDATE Contacts_ SET  Firstname=@Fistname , Lastname = @Lastname, Phone = @Phone, Address= @Address WHERE Id= @Id";

                SqlParameter Id = new SqlParameter("@Id", contacts.Id);
                SqlParameter Firstname = new SqlParameter("@Fistname", contacts.Firstname);
                SqlParameter Lastname = new SqlParameter("@Lastname", contacts.Lastname);
                SqlParameter Phone = new SqlParameter("@Phone", contacts.Phone);
                SqlParameter Address = new SqlParameter("@Address", contacts.Address);

                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.Add(Id);
                command.Parameters.Add(Firstname);
                command.Parameters.Add(Lastname);
                command.Parameters.Add(Phone);
                command.Parameters.Add(Address);

                command.ExecuteNonQuery();

                MessageBox.Show("Modificado con exito");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public List<Contacts > GetContacts() 
        {
            List<Contacts> contacts = new List<Contacts>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Contacts_";

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader  reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new Contacts { 
                        Id = int .Parse(reader["Id"].ToString()),
                        Firstname  = reader["Firstname"].ToString(),
                        Lastname  = reader["Lastname"].ToString(),
                        Phone  = reader["Phone"].ToString(),
                        Address   = reader["Address"].ToString()
                    });

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return contacts;
        }

    }
}
