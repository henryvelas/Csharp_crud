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
