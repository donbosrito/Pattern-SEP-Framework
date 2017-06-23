using SEPFramework.Model;
using System;
using System.Windows.Forms;

namespace SEPFramework
{
    public partial class MainForm<T> : Form where T : BaseModel, new()
    {
        BaseModelListImp<T> data;
        public MainForm()
        {
            InitializeComponent();
            DatabaseVariable.value.CreateTableIfNotExists(typeof(T));
            data = DatabaseVariable.value.FetchAllData<T>();
            gridTable.DataSource = data.Display();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                data.Delete(gridTable.SelectedRows[0].Index);
                gridTable.DataSource = data.Display();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelForm<T> modelForm = new ModelForm<T>();
            modelForm.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                ModelForm<T> modelForm = new ModelForm<T>(gridTable.SelectedRows[0].Index);
                modelForm.Show();
            }
        }
    }
}
