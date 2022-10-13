using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.BusinessLogicLayer;

namespace EmployeeManagement.presentationLayer
{
  public  class EMS
    {
        public static void Main(String [] args)
        {
            do
            {
            Console.WriteLine("Enter 1: To Add Employee");
            Console.WriteLine("Enter 2: To View Employees");
            Console.WriteLine("Enter 3: To Update employees");
            Console.WriteLine("Enter 4: To Delete Employee");
            
                int k = Convert.ToInt32(Console.ReadLine());
                CRUD.Operation(k);
                Console.WriteLine("Press Y to Continue");
            }
            while (Console.ReadLine()=="Y");

        }
    }
}
