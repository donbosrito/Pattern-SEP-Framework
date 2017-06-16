using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.Model;

namespace SEPFramework.InputMethods
{
    public class InputMethodFactory<T> where T : BaseModel
    {
        private static InputMethodFactory<T> _instance = null;
        public static InputMethodFactory<T> getInstance()
        {
            if (InputMethodFactory<T>._instance == null)
            {
                InputMethodFactory<T>._instance = new InputMethodFactory<T>();
            }

            return InputMethodFactory<T>._instance;
        }

        private LinkedList<InputMethod> _inputMethods = new LinkedList<InputMethod>();

        private InputMethodFactory()
        {
            this._inputMethods.AddFirst(new EnumRadioButtonSelector());
            this._inputMethods.AddFirst(new EnumComboBoxSelector());
            this._inputMethods.AddLast(new DateTimeSelector());
            this._inputMethods.AddLast(new TextInput());
            this._inputMethods.AddLast(new NumberInput());
        }

        public bool addInputMethod(InputMethod method)
        {
            foreach (var i in this._inputMethods)
            {
                if (i.GetType() == method.GetType()) return false;
            }

            this._inputMethods.AddFirst(method);
            return true;
        }

        public ListInputMethod create(T sample)
        {
            ListInputMethod list = new ListInputMethod();
            var infor = sample.GetProperties();

            foreach (var i in infor)
            {
                InputMethod temp = null;
                foreach (var m in this._inputMethods)
                {
                    temp = m.create(i.PropertyType);
                    if (temp != null) break;
                }

                if (temp != null)
                {
                    list.add(temp);
                }
            }

            return list;
        }
    }
}
