using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ProductServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost servicehost = new ServiceHost(typeof(ProductService.Service.ProductInfo)))
            {
                servicehost.Open();
                Console.WriteLine("Host Started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
