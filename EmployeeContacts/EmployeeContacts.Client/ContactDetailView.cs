using EmployeeContacts.Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeContacts.Client
{
    public partial class frmContactDetailView : Form
    {
        public string contactId;
        public bool isUpdate;
        public bool isNew;

        public frmContactDetailView()
        {
            InitializeComponent();
        }

        private void frmContactDetailView_Load(object sender, EventArgs e)
        {
            if (!isNew)
            {
                GetContact();
                ToggleUIForUpdate();
            }
            else
            {
                ToggleUIForUpdate();
            }
        }


        private void ToggleUIForUpdate()
        {
            if (isUpdate || isNew)
            {
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtCompanyName.Enabled = true;
                txtMobileNumber.Enabled = true;
                txtEmailAddress.Enabled = true;
                btnUpdate.Visible = true;
            }
        }

        private async void GetContact()
        {
            string getContactPath = String.Format("{0}/{1}", "http://localhost:5000/api/contacts", contactId);
            Contact contact = new Contact();

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(getContactPath))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string contactResponseString = await response.Content.ReadAsStringAsync();

                        contact = JsonConvert.DeserializeObject<Contact>(contactResponseString);
                        PopulateView(contact);
                    }
                }
            }
        }

        private void PopulateView(Contact? contact)
        {
            if (contact != null)
            {
                txtContactID.Text = Convert.ToString(contact.ContactID);
                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;
                txtCompanyName.Text = contact.CompanyName;
                txtMobileNumber.Text = contact.MobileNumber;
                txtEmailAddress.Text = contact.EmailAddress;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var mainForm = (frmContact)this.Owner;
            mainForm.GetAllContacts();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isUpdate || isNew)
            {
                ContactRequest request = new ContactRequest()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    CompanyName = txtCompanyName.Text,
                    MobileNumber = txtMobileNumber.Text,
                    EmaillAddress = txtEmailAddress.Text
                };

                if(isUpdate) UpdateContact(request);
                if (isNew) AddContact(request);
            }
        }

        private async void UpdateContact(ContactRequest request)
        {
            string updateContactPath = String.Format("{0}/{1}", "http://localhost:5000/api/contacts", contactId);
            using (var client = new HttpClient())
            {
                var serializedRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
                var result = await client.PatchAsync(updateContactPath, content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Successfully updated Contact.");
                }
                else
                {
                    MessageBox.Show("UPDATE FAILED! There was an error updating the Contact.");
                }
            }
            var mainForm = (frmContact)this.Owner;
            mainForm.GetAllContacts();
            this.Close();
        }

        private async void AddContact(ContactRequest request)
        {
            string addContactPath = "http://localhost:5000/api/contacts";
            using (var client = new HttpClient())
            {
                var serializedRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(addContactPath, content);

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Successfully added Contact.");
                }
                else
                {
                    MessageBox.Show("CREATION FAILED! There was an error creating the Contact.");
                }
            }

            var mainForm = (frmContact)this.Owner;
            mainForm.GetAllContacts();
            this.Close();
        }
    }
}
