using SEPFramework.Model;
using SEPFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.SEPControl
{
    public class MainFromOnly<T> : IControl<T> where T : BaseModel, new()
    {
        private MainForm<T> _mainForm = null;

        public MainFromOnly(DBAdapter connector)
        {
            connector.Connect();
            this._mainForm = new MainForm<T>(connector);
        }

        void IControl<T>.start()
        {
            Application.Run(this._mainForm);
        }
    }
}
