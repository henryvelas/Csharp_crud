using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsContactos
{
    public class BusinessLogicLayer
    {
        private DataAccessLayer _dataAccessLayer;
        
        public BusinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        public Contacts SaveContact(Contacts contacts)
        {
            if(contacts.Id  == 0)            
                _dataAccessLayer.InsertContacts(contacts);            
            else            
                _dataAccessLayer.UpdateContacts(contacts);

            return contacts;
            
        }

        public  List<Contacts> GetContacts(string searchtext=null)
        {
          return  _dataAccessLayer.GetContacts(searchtext);
        }

        public void deletecontacts(int Id)
        {
           _dataAccessLayer.deletecontacts(Id);
        }
    }
}
