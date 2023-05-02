using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
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
        private Contacts _contacts;
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

            contacts.Id = _contacts != null ? _contacts.Id : 0;

            _businessLogicLayer.SaveContact(contacts);

        }

        public void LoadContact(Contacts contacts)
        {
            _contacts = contacts;
            if (contacts != null )
            {
                txtfirstname.Text = contacts.Firstname;
                txtlastname.Text = contacts.Lastname;
                txtphone.Text = contacts.Phone;
                txtaddress.Text = contacts.Address; 
            }

            //clearform(); 
        }

        private void clearform()
        {
            txtfirstname.Clear(); 
            txtlastname.Clear();
            txtphone.Clear();
            txtaddress.Clear();
        }
    }
}
