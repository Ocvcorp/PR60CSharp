using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    struct ConveyerControl
    {
        public enum action
        {
            start=39,
            stop=37,
            forward=38,
            back=40
        };
        public void conveyer(action ac)
        {
            switch (ac)
            {
                case action.start:
                    Console.WriteLine("Starting");
                    break;
                case action.stop:
                    Console.WriteLine("System stopped");
                    break;
                case action.forward:
                    Console.WriteLine("Moving forward");
                    break;
                case action.back:
                    Console.WriteLine("Moving back");
                    break;
            }
        }
    }

}





















