using PracitceHub.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracitceHub.Factory
{
    public class MyTaskFactory
    {
        public ITask getTask(TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.MultiThreading:
                    return new MultithreadingTask();
                default:
                    return new DefaultTask();
            }
        }
    }
}
