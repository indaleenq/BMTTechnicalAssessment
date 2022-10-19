using EmployeeContacts.Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeContacts.Client.Presenter
{
    public class ContactPresenter
    {
        public List<Contact> Contacts { get; set; }


        public async void GetAllContacts()
        {
            string getContactsPath = "http://localhost:5000/api/contacts";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(getContactsPath))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string contactResponseString = await response.Content.ReadAsStringAsync();

                        Contacts = JsonConvert.DeserializeObject<List<Contact>>(contactResponseString);
                    }
                }
            }
        }

    }
}
