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
            //else            
                //_dataAccessLayer.UpdateContacts

            return contacts;
            
        }

        public  List<Contacts> GetContacts()
        {
          return  _dataAccessLayer.GetContacts();
        }

    }
}
