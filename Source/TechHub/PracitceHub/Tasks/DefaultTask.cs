using PracitceHub.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracitceHub.Tasks
{
    public class DefaultTask : ITask
    {
        public void Execute()
        {
            Console.WriteLine("DefaultTask:  " + this.GetType());
        }
    }
}
