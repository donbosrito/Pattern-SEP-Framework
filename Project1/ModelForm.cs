using SEPFramework.Model;
using SEPFramework.InputMethods;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEPFramework
{
    public partial class ModelForm<T> : Form where T : BaseModel, new()
    {
        private MainForm<T> _mainForm = null;
        private T model;

        //Add Form
        public ModelForm()
        {
            InitializeComponent();
            model = new T();
            generate();
            setPosition();
        }

        //Edit Form
        public ModelForm(int ID)
        {
            InitializeComponent();
            generate();
            setPosition();
        }

        public ModelForm(MainForm<T> main_form)
        {
            InitializeComponent();
            generate();
            setPosition();
            _mainForm = main_form;
        }

        public void setMainForm(MainForm<T> main_form)
        {
            _mainForm = main_form;
        }

        private void generate()
        {
            controls = InputMethodFactory<T>.getInstance().create(model.GetType());
            var c = panel_Main.Controls;
            var names = model.GetDisplayInfo();
            controls.setLabelName(names);
            controls.attachToForm(ref c);
            controls.setWidth(panel_Main.Width - 30);
        }

        private void setPosition()
        {
            Point p = panel_Main.Location;
            controls.setPosition(p);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void applyData(T data)
        {
            controls.applyData(data.GetPropertiesValues());
        }

        public T getData()
        {
            var data = new T();
            data.ApplyPropeties(controls.getData());
            return data;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mainForm == null) return;

            _mainForm.createModel(getData());
        }
    }
}
