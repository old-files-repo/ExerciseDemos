using System;

namespace Delegate_Event
{
    public class Demo2
    {
        public void Run()
        {
            NumEvent2Send even = new NumEvent2Send(0);//发送器
            even.ChangeNum += EventAction2.Action;

            even.SetValue(7);
            even.SetValue(11);

            System.Console.ReadKey();
        }
    }

    public class NumEvent2Send
    {
        private int value;

        public delegate void NumManipulationHandler(NumEventArgs2 e);

        public event NumManipulationHandler ChangeNum;

        public virtual void OnChangeNum(NumEventArgs2 e)
        {
            ChangeNum?.Invoke(e);
        }

        public NumEvent2Send(int n)
        {
            SetValue(n);
        }

        public void SetValue(int n)
        {
            if (value != n)
            {
                NumEventArgs2 e = new NumEventArgs2(n);
                value = n;
                OnChangeNum(e);
            }
        }
    }

    public class EventAction2
    {
        public static void Action(NumEventArgs2 e)
        {
            System.Console.WriteLine("value : " + e.value);
        }
    }

    public class NumEventArgs2 : EventArgs
    {
        public int value;
        public NumEventArgs2(int _value)
        {
            this.value = _value;
        }
    }
}
