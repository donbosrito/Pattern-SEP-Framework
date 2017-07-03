using SEPFramework.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using SEPFramework.MemberShip;
using SEPFramework.Service;

namespace SEPFramework
{
    public partial class MainForm<T> : Form where T : BaseModel, new()
    {
        private BaseModelList<T> data;
        private LoginForm<T> _loginForm = null;

        public MainForm(DBAdapter adapter)
        {
            InitializeComponent();
            data = new BaseModelList<T>();
            data.DBConnector = adapter;
            data.Initilization();
            gridTable.DataSource = data.GetAll().Display();
            this.logOutToolStripMenuItem.Enabled = false;
        }

        public void setLoginForm(ref LoginForm<T> loginForm)
        {
            this._loginForm = loginForm;
            if (this._loginForm != null)
            {
                this.logOutToolStripMenuItem.Enabled = true;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modelForm = new ModelForm<T>(this);
            modelForm.ShowDialog();
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
            message = "Deleting";

            MessageBox.Show("Successful!", message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridTable.DataSource = data.GetAll().Display();
            gridTable.Update();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this._loginForm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._loginForm != null)
            {
                this._loginForm.Close();
            }
        }

        public void CanEdit()
        {
            this.deleteToolStripMenuItem.Enabled = true;
            this.addToolStripMenuItem.Enabled = true;
            this.editToolStripMenuItem.Enabled = true;
        }

        public void CanView()
        {
            this.deleteToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Enabled = false;
        }
    }
}
