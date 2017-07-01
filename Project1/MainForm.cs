using SEPFramework.Model;
using System;
using System.Windows.Forms;

namespace SEPFramework
{
    public partial class MainForm<T> : Form where T : BaseModel, new()
    {
        private BaseModelList<T> data;

        public MainForm()
        {
            InitializeComponent();
            data = new BaseModelList<T>();
            gridTable.DataSource = data.GetAll().Display();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                //data.Delete(gridTable.SelectedRows[0].Index);
                MessageBox.Show("Successful!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridTable.DataSource = data.GetAll().Display();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modelForm = new ModelForm<T>(this);
            modelForm.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                //this.current = this.gridTable.SelectedRows[0].Index;
                //this.modelForm.applyData(this.data.GetModel(this.current));
                //this.modelForm.ShowDialog();
            }
        }

        public void createModel(T model)
        {
            string message = "";
            data.Add(model);
            message = "Adding";

            MessageBox.Show("Successful!", message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridTable.DataSource = data.GetAll().Display();
            gridTable.Update();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
