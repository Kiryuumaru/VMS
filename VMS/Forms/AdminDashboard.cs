using VMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS.Forms
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            foreach (Destination destination in PartialDB.GetDestinations())
            {
                dataGridView.Rows.Add(destination.Name, destination.VisitCount.ToString());
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            new AdminAddDest().ShowDialog();
            dataGridView.Rows.Clear();
            foreach (Destination destination in PartialDB.GetDestinations())
            {
                dataGridView.Rows.Add(destination.Name, destination.VisitCount.ToString());
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
                string name = Convert.ToString(selectedRow.Cells[0].Value);
                if (MessageBox.Show("Are you sure to remove destination \"" + name + "\"?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    PartialDB.DeleteDestination(name);
                    dataGridView.Rows.Clear();
                    foreach (Destination destination in PartialDB.GetDestinations())
                    {
                        dataGridView.Rows.Add(destination.Name, destination.VisitCount.ToString());
                    }
                }
            }
        }

        private void ButtonClearData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to clear data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                PartialDB.ClearData();
                dataGridView.Rows.Clear();
                foreach (Destination destination in PartialDB.GetDestinations())
                {
                    dataGridView.Rows.Add(destination.Name, destination.VisitCount.ToString());
                }
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
