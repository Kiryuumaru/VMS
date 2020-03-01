using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.Services;

namespace VMS.Forms
{
    public partial class AdminAddDest : Form
    {
        public AdminAddDest()
        {
            InitializeComponent();
            textboxName.Select();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxName.Text))
            {
                MessageBox.Show("Please input name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                List<Destination> destinations = new List<Destination>(PartialDB.GetDestinations());
                Destination oldDestination = destinations.FirstOrDefault(item => item.Name.Equals(textboxName.Text));
                if (oldDestination != null)
                {
                    MessageBox.Show("Destination name already added", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Destination destination = new Destination(textboxName.Text);
                    PartialDB.SetDestination(destination);
                    MessageBox.Show("Destination successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            textboxName.Select();
        }
    }
}
