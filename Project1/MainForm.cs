﻿using SEPFramework.Model;
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
        BaseModelListImp<T> data;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(BaseModelListImp<T> data)
        {
            InitializeComponent();
            this.data = data;
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
