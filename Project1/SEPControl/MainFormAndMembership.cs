using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.Model;
using SEPFramework.MemberShip;
using System.Windows.Forms;
using SEPFramework.Service;

namespace SEPFramework.SEPControl
{
    public class MainFormAndMembership<T> : IControl<T> where T : BaseModel, new()
    {
        private LoginForm<T> _loginForm = null;
        private MainForm<T> _mainForm = null;

        public MainFormAndMembership(DBAdapter mainFormConnector, DBAdapter membershipConnector)
        {
            AccountManager.DBConnector = membershipConnector;
            this._loginForm = new LoginForm<T>();
            this._mainForm = new MainForm<T>(mainFormConnector);
            this._mainForm.setLoginForm(ref this._loginForm);
            this._loginForm.setMainForm(ref this._mainForm);
        }

        void IControl<T>.start()
        {
            Application.Run(this._loginForm);
        }
    }
}
