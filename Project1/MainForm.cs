using SEPFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework
{
    public partial class MainForm<T> : Form where T : BaseModel, new()
    {
        private BaseModelListImp<T> data;
        private int current;
        public MainForm()
        {
            InitializeComponent();
            this.modelForm = new ModelForm<T>(this);
            current = -1;
        }

        public MainForm(BaseModelListImp<T> data)
        {
            InitializeComponent();
            this.modelForm = new ModelForm<T>(this);
            current = -1;
            this.data = data;
            gridTable.DataSource = data.Display();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                data.Delete(gridTable.SelectedRows[0].Index);
                MessageBox.Show("Successful!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridTable.DataSource = data.Display();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.current = -1;
            this.modelForm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                this.current = this.gridTable.SelectedRows[0].Index;
                this.modelForm.applyData(this.data.GetModel(this.current));
                this.modelForm.ShowDialog();
            }
        }

        public void save(T data)
        {
            string message = "";
            if (this.current < 0)
            {
                this.data.Add(data);
                message = "Adding";
            }
            else
            {
                this.data.Udpate(this.current, data);
                message = "Editting";
            }

            MessageBox.Show("Successful!", message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridTable.DataSource = this.data.Display();
            gridTable.Update();
        }
    }
}
