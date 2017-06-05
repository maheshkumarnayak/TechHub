using OAuth.Repository.Entities;
using OAuth.Repository.Repository;
using System;
using System.Collections;
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

            //test obj = new test();
            //counter(3);
            //Console.WriteLine(counter(3));

            //ExcelFormat obj = new ExcelFormat();
            //Console.WriteLine(obj.FindLocationInExcel(10, 35));
            sort(new int[] { 2, 3, 4, 1, 1, 5 });

            Console.WriteLine("Console Stopped");
            Console.ReadLine();
        }


        private static int counter(int i)
        {
            if (i > 0)
            {
                int j = 0;
                j = i--;
                Console.WriteLine(j + " asdf " + i);
                i = i + counter(i);
            }
            return i;
        }

        public void Test1()
        {
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

        }

        static void customSort(int[] arr)
        {
            Dictionary<int, int> objdict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int output;
                objdict.TryGetValue(arr[i], out output);
                if (output > 0)
                {
                    objdict[arr[i]] = output + 1;
                }
                else
                {
                    objdict.Add(arr[i], 1);
                }
            }

            var obj = from val in objdict
                      orderby val.Value, val.Key ascending
                      select val;

            foreach (var keyval in obj)
            {
                for (int j = 1; j <= keyval.Value; j++)
                {
                    Console.WriteLine(keyval.Key);
                }
            }
        }

        public static string[] braces(string[] values)
        {
            string[] returnstrarr = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                string str = values[i];
                bool isMatched = true;
                System.Collections.Stack obj = new System.Collections.Stack();
                char popChar;

                foreach (char c in str)
                {   //adjust sums
                    if (c == '{' || c == '[' || c == '(')
                    {
                        obj.Push(c);
                    }
                    if (obj.Count == 0)
                    {
                        isMatched = false;
                        continue;
                    }
                    if (c == '}')
                    {
                        popChar = Convert.ToChar(obj.Pop());
                        if (popChar == '{')
                        {
                            continue;
                        }
                        else
                        {
                            isMatched = false;
                            continue;
                        }
                    }
                    if (c == ']')
                    {
                        popChar = Convert.ToChar(obj.Pop());
                        if (popChar == '[')
                        {
                            continue;
                        }
                        else
                        {
                            isMatched = false;
                            continue;
                        }
                    }
                    if (c == ')')
                    {
                        popChar = Convert.ToChar(obj.Pop());
                        if (popChar == '(')
                        {
                            continue;
                        }
                        else
                        {
                            isMatched = false;
                            continue;
                        }
                    }

                }

                if (obj.Count > 0)
                {
                    isMatched = false;
                }

                returnstrarr[i] = string.Format("index {0} is balanced {1}", i, isMatched ? "YES" : "NO");

            }
            return returnstrarr;
        }

        static void sort(int[] arr)
        {
            bool flag = true;


            for (int i = 1; i < arr.Length && flag; i++)
            {
                flag = false;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = true;
                    }
                }
            }

            int[][] marr = new int[arr.Length][];
            int arrindex = 0;
            if (arr.Length > 0)
            {
                marr[arrindex] = new int[] { arr[0], 1 };
            }
            for (int x =0; x <arr.Length; x++)
            {
                if (arr[x] == arr[x + 1])
                {
                    marr[arrindex][1] = marr[arrindex][1] + 1;
                }
                else
                {
                    arrindex++;
                    marr[arrindex] = new int[] { arr[x], 1 };
                }
            }

            for (int m = 0; m < marr.Length; m++)
            {
                for (int j = 1; j <= marr[m][1]; j++)
                {
                    Console.WriteLine(marr[m][0]);
                }
            }
        }

    }

    public class test
    {
        internal int counter(int i)
        {
            if(i>0)
                i = i + counter(i - 1);
            return i;
        }
    }

    public class ExcelFormat
    {
        public string FindLocationInExcel (int NoOfColumn,int NumberToSearch)
        {
            int colnum = NumberToSearch % NoOfColumn;
            int ronum = NumberToSearch / NoOfColumn;

            return string.Format("Row Number is {1}, Column Number is {0}", colnum, ronum);
        }
    }

    
}
