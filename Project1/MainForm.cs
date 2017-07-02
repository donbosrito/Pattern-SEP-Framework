using SEPFramework.Model;
using System;
using System.Windows.Forms;
using SEPFramework.MemberShip;
using SEPFramework.Service;

namespace SEPFramework
{
    public partial class MainForm<T> : Form where T : BaseModel, new()
    {
        private BaseModelList<T> data;
        private int current = -1;
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                var model = data.GetById(gridTable.SelectedRows[0].Index);
                if (DatabaseVariable.value.Delete<T>(model))
                {
                    MessageBox.Show("Successful!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridTable.DataSource = data.GetAll().Display();
                    return;
                }

                MessageBox.Show("Failed!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.current = -1;
            modelForm = new ModelForm<T>(this);
            modelForm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTable.SelectedRows != null)
            {
                this.current = this.gridTable.SelectedRows[0].Index;
                modelForm = new ModelForm<T>(this);
                this.modelForm.applyData(this.data.GetById(this.current));
                this.modelForm.ShowDialog();
            }
        }

        public void createModel(T model)
        {
            string message = "";

            if (this.current < 0)
            {
                data.Add(model);
                message = "Adding";
            }
            else
            {
                DatabaseVariable.value.Update<T>(this.data.GetById(current), model);
                gridTable.Update();
                message = "Updating";
            }
            MessageBox.Show("Successful!", message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.modelForm.Hide();
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
