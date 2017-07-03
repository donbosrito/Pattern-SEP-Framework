using SEPFramework.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modelForm = new ModelForm<T>(this);
            modelForm.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                T model = new T();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    Console.WriteLine(gridTable.SelectedRows[0].Cells[prop.Name].Value);
                    prop.SetValue(model, Convert.ChangeType(gridTable.SelectedRows[0].Cells[prop.Name].Value, prop.PropertyType));
                }
                modelForm = new ModelForm<T>(this, model);
                modelForm.Show();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                T model = new T();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    prop.SetValue(model, Convert.ChangeType(gridTable.SelectedRows[0].Cells[prop.Name].Value, prop.PropertyType));
                }
                deleteModel(model);
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

        public void updateModel(T oldModel, T newModel)
        {
            string message = "";
            data.Update(oldModel, newModel);
            message = "Updating";

            MessageBox.Show("Successful!", message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridTable.DataSource = data.GetAll().Display();
            gridTable.Update();
        }

        public void deleteModel(T model)
        {
            string message = "";
            data.Delete(model);
            message = "Updating";

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
