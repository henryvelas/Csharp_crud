using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsContactos
{
    public partial class Main : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        public Main()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }
        #region EVENTS
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenContactsDetails();
        }
        private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)gv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString() == "EDIT") 
            {
                ContactsDetails contactsDetails = new ContactsDetails();

                contactsDetails.LoadContact(new Contacts 
                {
                    Id =int.Parse((gv.Rows[e.RowIndex].Cells[0]).Value.ToString()),
                    Firstname  =(gv.Rows[e.RowIndex].Cells[1]).Value.ToString(),
                    Lastname  =(gv.Rows[e.RowIndex].Cells[2]).Value.ToString(),
                    Phone  =(gv.Rows[e.RowIndex].Cells[3]).Value.ToString(),
                    Address  =(gv.Rows[e.RowIndex].Cells[4]).Value.ToString(),
                });
                contactsDetails.ShowDialog(this);            }
        }

        #endregion 

        #region PRIVATE METHODS
        private void OpenContactsDetails()
        {
            ContactsDetails contactsDetails = new ContactsDetails();
            contactsDetails.Close();
            ContactsDetails contactsDetails2 = new ContactsDetails();
            contactsDetails2.ShowDialog (this);

            //contactsDetails.ShowDialog();
        }

        public void PopulateContacts()
        {
            List<Contacts> contacts = _businessLogicLayer.GetContacts();

            gv.DataSource = contacts;  
        }
        #endregion

    }
}
