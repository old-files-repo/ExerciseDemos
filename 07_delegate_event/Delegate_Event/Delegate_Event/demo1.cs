using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Event
{
    public class Demo1
    {
        public void Run()
        {
            NumEvent even = new NumEvent(0);
            even.ChangeNum += EventAction.Action;

            even.SetValue(7);
            even.SetValue(11);

            System.Console.ReadKey();
        }
    }

    public class NumEvent
    {
        private int value;

        public delegate void NumManipulationHandler(NumEventArgs e);

        public event NumManipulationHandler ChangeNum;

        public virtual void OnChangeNum(NumEventArgs e)
        {
            ChangeNum?.Invoke(e);
        }

        public NumEvent(int n)
        {
            SetValue(n);
        }

        public void SetValue(int n)
        {
            if (value != n)
            {
                NumEventArgs e = new NumEventArgs(n);
                value = n;
                OnChangeNum(e);
            }
        }
    }

    public class EventAction
    {
        public static void Action(NumEventArgs e)
        {
            System.Console.WriteLine("value : " + e.value);
        }
    }

    public class NumEventArgs : EventArgs
    {
        public int value;
        public NumEventArgs(int _value)
        {
            this.value = _value;
        }
    }
}
