using EmployeeContacts.Client.Model;
using EmployeeContacts.Client.Presenter;
using Newtonsoft.Json;

namespace EmployeeContacts.Client
{
    public partial class frmContact : Form
    {
        private string _selectedContactID = string.Empty;

        public frmContact()
        {
            InitializeComponent();
        }

        private void frmContact_Load(object sender, EventArgs e)
        {
            GetAllContacts();
        }

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

                        gridContactsList.DataSource = JsonConvert.DeserializeObject<List<Contact>>(contactResponseString);
                    }
                }
            }
        }

        private void btnViewContact_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_selectedContactID))
            {
                frmContactDetailView contactDetailView = new frmContactDetailView();
                contactDetailView.contactId = _selectedContactID;
                contactDetailView.isUpdate = false;
                contactDetailView.ShowDialog(this);
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmContactDetailView contactDetailView = new frmContactDetailView();
            contactDetailView.isNew = true;
            contactDetailView.ShowDialog(this);
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_selectedContactID))
            {
                frmContactDetailView contactDetailView = new frmContactDetailView();
                contactDetailView.contactId = _selectedContactID;
                contactDetailView.isUpdate = true;
                contactDetailView.ShowDialog(this);
            }
        }

        private void gridContactsList_SelectionChanged(object sender, EventArgs e)
        {
            if (gridContactsList.SelectedRows.Count > 0)
            {
                _selectedContactID = gridContactsList.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void btnGetContact_Click(object sender, EventArgs e)
        {
            SearchContact();
        }

        private async void SearchContact()
        {
            if (!string.IsNullOrWhiteSpace(txtGetContact.Text))
            {
                string getContactPath = String.Format("{0}/{1}", "http://localhost:5000/api/contacts", txtGetContact.Text);
                List<Contact> contact = new List<Contact>();
                
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(getContactPath))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string contactResponseString = await response.Content.ReadAsStringAsync();

                            //var searchResult = JsonConvert.DeserializeObject<Contact>(contactResponseString);
                            contact.Add(JsonConvert.DeserializeObject<Contact>(contactResponseString));

                            gridContactsList.DataSource = null;
                            gridContactsList.Rows.Clear();
                            gridContactsList.DataSource = contact;
                            gridContactsList.Refresh();
                        }
                    }
                }
            }
        }

    }
}