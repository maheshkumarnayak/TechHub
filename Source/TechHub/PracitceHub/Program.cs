using PracitceHub.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracitceHub
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTaskFactory taskFactory = new MyTaskFactory();
            ITask task = taskFactory.getTask(TaskType.Class);
            task.Execute();
            Console.ReadLine();
        }
    }
}
