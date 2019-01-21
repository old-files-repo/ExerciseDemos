using System;

namespace Delegate_Event
{
    internal class KeyEventArgs : EventArgs
    {
        public readonly char KeyChar;
        public KeyEventArgs(char keyChar)
        {
            KeyChar = keyChar;
        }
    }

    internal class KeyInputMonitor
    {
        // 创建一个委托，返回类型为void，两个参数
        public delegate void KeyDownEventHandler(object sender, KeyEventArgs e);

        // 将创建的委托和特定事件关联,在这里特定的事件为KeyDown
        public event KeyDownEventHandler KeyDown;

        public void Run()
        {
            var finished = false;
            do
            {
                Console.WriteLine("Input a char");
                string response = Console.ReadLine();

                char responseChar = (response == "") ? ' ' : char.ToUpper(response[0]);
                switch (responseChar)
                {
                    case 'X':
                        finished = true;
                        break;
                    default:
                        // 得到按键信息的参数
                        KeyEventArgs keyEventArgs = new KeyEventArgs(responseChar);
                        // 触发事件
                        KeyDown(this, keyEventArgs);
                        break;
                }
            } while (!finished);
        }
    }

    internal class EventReceiver
    {
        public EventReceiver(KeyInputMonitor monitor)
        {
            // 产生一个委托实例并添加到KeyInputMonitor产生的事件列表中
            monitor.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // 真正的事件处理函数,对应KeyInputMonitor的KeyDown方法
            Console.WriteLine("Capture key: {0}", e.KeyChar);
        }
    }

    public class MainEntryPoint
    {
        public static void Start()
        {
            // 实例化一个事件发送器
            KeyInputMonitor monitor = new KeyInputMonitor();
            // 实例化一个事件接收器
            EventReceiver eventReceiver = new EventReceiver(monitor);
            // 运行
            monitor.Run();
        }
    }
}
