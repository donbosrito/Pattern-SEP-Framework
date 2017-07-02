using System;
using System.Collections.Generic;
using SEPFramework.Model;

namespace SEPFramework.InputMethods
{
    public class InputMethodFactory<T> where T : BaseModel
    {
        private static InputMethodFactory<T> _instance = null;
        public static InputMethodFactory<T> getInstance()
        {
            if (_instance == null)
            {
                _instance = new InputMethodFactory<T>();
            }

            return _instance;
        }

        private LinkedList<InputMethod> _inputMethods = new LinkedList<InputMethod>();

        private InputMethodFactory()
        {
            _inputMethods.AddLast(new DateTimeSelector());
            _inputMethods.AddLast(new TextInput());
            _inputMethods.AddLast(new NumberInput());
        }

        public bool addInputMethod(InputMethod method)
        {
            foreach (var i in _inputMethods)
            {
                if (i.GetType() == method.GetType()) return false;
            }

            _inputMethods.AddFirst(method);
            return true;
        }

        public ListInputMethod create(Type type)
        {
            ListInputMethod list = new ListInputMethod();
            var infor = type.GetProperties();

            foreach (var i in infor)
            {
                InputMethod temp = null;
                foreach (var m in _inputMethods)
                {
                    temp = m.create(i.PropertyType);
                    if (temp != null) break;
                }

                if (temp != null)
                {
                    var newInputMethod = (InputMethod)Activator.CreateInstance(temp.GetType());
                    newInputMethod.create(i.PropertyType);
                    list.add(newInputMethod);
                }
            }

            return list;
        }
    }
}
