namespace EmployeeContacts.Client
{
    partial class frmContact
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridContactsList = new System.Windows.Forms.DataGridView();
            this.btnViewContact = new System.Windows.Forms.Button();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.txtGetContact = new System.Windows.Forms.TextBox();
            this.btnGetContact = new System.Windows.Forms.Button();
            this.lblContactID = new System.Windows.Forms.Label();
            this.btnAdvanceSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridContactsList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridContactsList
            // 
            this.gridContactsList.AllowUserToAddRows = false;
            this.gridContactsList.AllowUserToDeleteRows = false;
            this.gridContactsList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridContactsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContactsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridContactsList.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridContactsList.Location = new System.Drawing.Point(11, 59);
            this.gridContactsList.MultiSelect = false;
            this.gridContactsList.Name = "gridContactsList";
            this.gridContactsList.ReadOnly = true;
            this.gridContactsList.RowTemplate.Height = 25;
            this.gridContactsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridContactsList.Size = new System.Drawing.Size(597, 301);
            this.gridContactsList.TabIndex = 0;
            this.gridContactsList.SelectionChanged += new System.EventHandler(this.gridContactsList_SelectionChanged);
            // 
            // btnViewContact
            // 
            this.btnViewContact.Location = new System.Drawing.Point(400, 366);
            this.btnViewContact.Name = "btnViewContact";
            this.btnViewContact.Size = new System.Drawing.Size(101, 23);
            this.btnViewContact.TabIndex = 1;
            this.btnViewContact.Text = "View Contact";
            this.btnViewContact.UseVisualStyleBackColor = true;
            this.btnViewContact.Click += new System.EventHandler(this.btnViewContact_Click);
            // 
            // btnEditContact
            // 
            this.btnEditContact.Location = new System.Drawing.Point(507, 366);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(101, 23);
            this.btnEditContact.TabIndex = 2;
            this.btnEditContact.Text = "Edit Contact";
            this.btnEditContact.UseVisualStyleBackColor = true;
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            // 
            // txtGetContact
            // 
            this.txtGetContact.Location = new System.Drawing.Point(72, 16);
            this.txtGetContact.Name = "txtGetContact";
            this.txtGetContact.Size = new System.Drawing.Size(260, 23);
            this.txtGetContact.TabIndex = 4;
            // 
            // btnGetContact
            // 
            this.btnGetContact.Location = new System.Drawing.Point(338, 16);
            this.btnGetContact.Name = "btnGetContact";
            this.btnGetContact.Size = new System.Drawing.Size(114, 23);
            this.btnGetContact.TabIndex = 5;
            this.btnGetContact.Text = "Search Contact";
            this.btnGetContact.UseVisualStyleBackColor = true;
            this.btnGetContact.Click += new System.EventHandler(this.btnGetContact_Click);
            // 
            // lblContactID
            // 
            this.lblContactID.AutoSize = true;
            this.lblContactID.Location = new System.Drawing.Point(5, 20);
            this.lblContactID.Name = "lblContactID";
            this.lblContactID.Size = new System.Drawing.Size(66, 15);
            this.lblContactID.TabIndex = 6;
            this.lblContactID.Text = "Contact ID:";
            // 
            // btnAdvanceSearch
            // 
            this.btnAdvanceSearch.Location = new System.Drawing.Point(458, 16);
            this.btnAdvanceSearch.Name = "btnAdvanceSearch";
            this.btnAdvanceSearch.Size = new System.Drawing.Size(139, 25);
            this.btnAdvanceSearch.TabIndex = 7;
            this.btnAdvanceSearch.Text = "Advance Search...";
            this.btnAdvanceSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGetContact);
            this.groupBox1.Controls.Add(this.btnAdvanceSearch);
            this.groupBox1.Controls.Add(this.lblContactID);
            this.groupBox1.Controls.Add(this.btnGetContact);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(12, 366);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(99, 23);
            this.btnAddContact.TabIndex = 9;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // frmContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(620, 397);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditContact);
            this.Controls.Add(this.btnViewContact);
            this.Controls.Add(this.gridContactsList);
            this.MaximizeBox = false;
            this.Name = "frmContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BMT CONTACTS";
            this.Load += new System.EventHandler(this.frmContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridContactsList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView gridContactsList;
        private Button btnViewContact;
        private Button btnEditContact;
        private TextBox txtGetContact;
        private Button btnGetContact;
        private Label lblContactID;
        private Button btnAdvanceSearch;
        private GroupBox groupBox1;
        private Button btnAddContact;
    }
}