using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SEPFramework.Service;
using SEPFramework.Model;

namespace SEPFramework.MemberShip
{
    public class AccountManager
    {
        private static AccountManager _instance = null;
        public static DBAdapter DBConnector { get; set; }

        private AccountManager()
        {
            BaseModelList<Account> Accounts = new BaseModelList<Account>();
        }

        private void InitList(ref BaseModelList<Account> Accounts)
        {
            Accounts = new BaseModelList<Account>();
            Accounts.DBConnector = AccountManager.DBConnector;
            Accounts.Initilization();
            Accounts.GetAll();
        }

        public Account IsExist(Account acc)
        {
            BaseModelList<Account> Accounts = null;
            this.InitList(ref Accounts);
            int index = Accounts.Find(acc);

            if (index < 0) return null;

            return Accounts.GetById(index); 
        }

        public bool IsEmpty()
        {
            BaseModelList<Account> Accounts = null;
            this.InitList(ref Accounts);
            return Accounts.IsEmpty();
        }

        public void Add(Account acc)
        {
            BaseModelList<Account> Accounts = null;
            this.InitList(ref Accounts);
            Accounts.Add(acc);
        }

        public static AccountManager getInstance()
        {
            if (AccountManager._instance == null)
            {
                AccountManager._instance = new AccountManager();
            }
            return AccountManager._instance;
        }
    }
}
