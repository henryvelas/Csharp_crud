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
    public partial class ContactsDetails : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        public ContactsDetails()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SaveContacts();
            this.Close();
            ((Main)this.Owner).PopulateContacts();
        }

        private void SaveContacts()
        {
            Contacts contacts = new Contacts();
            contacts.Firstname = txtfirstname.Text;
            contacts.Lastname = txtlastname.Text;
            contacts.Phone = txtphone.Text;
            contacts.Address = txtaddress.Text;

            _businessLogicLayer.SaveContact(contacts);

        }
    }
}
