using OAuth.Repository.Entities;
using OAuth.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console Started");
            
            IAccountRepository obj = new AccountRepository();

            IOrderRepository orderRepo = new OrderRepository();

            //obj.CreateUser(new User {  Id=1, Name="Mahesh Kumar Nayak", Secret="passpass", UserName="mahesh" });

            //obj.CreateClient(new Client { Id = "consoleApp", Name = "Console Application", Secret = "lCXDroz4HhR1EIx8qaz3C13z/quTXBkQ3Q5hj7Qx3aA=", 
            //ApplicationType=ApplicationTypes.JavaScript , Active=true, AllowedOrigin="*", RefreshTokenLifeTime=7200});

            //obj.CreateRefreshToken(new RefreshToken { Id = 1, Subject = "Mahesh Kumar Nayak", ClientId = "consoleApp", IssuedUtc = DateTime.Now, ExpiresUtc=DateTime.Now.AddDays(1), ProtectedTicket="dad" });

            //for (int i = 0; i < 50; i++)
            //{
            //    orderRepo.CreateOrder(new Order 
            //    { 
            //        CustomerName="Customer"+ i.ToString(),
            //        IsShipped= i%2==0?true:false,
            //        ShipperCity="Bangalore"
            //    });
            //}

            foreach (var ob in orderRepo.GetAllOrder().ToList())
            {
                Console.WriteLine(string.Format("OrderID: {0},CustomerName: {1},ShipperCity : {2},OrderDate: {3}", ob.OrderID, ob.CustomerName, ob.ShipperCity, ob.OrderDate));
            }

            Console.ReadLine();
        }


    }
}
