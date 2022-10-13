using EmployeeManagement.DataAccessLayer;

namespace EmployeeManagement.BusinessLogicLayer
{
    public static class CRUD
    {
        public static void Operation(int i)
        {
            switch (i)
            {
                case 1: 
                        Console.WriteLine("Enter Employee Name, Compentency, Salary, Department: ");
                    Employee employee = new Employee
                    {
                        Name = Console.ReadLine(),
                        compentency = Convert.ToInt32(Console.ReadLine()),
                        salary = Convert.ToInt32(Console.ReadLine()),
                        Department = Console.ReadLine()
                    };
                    int j = DataAccessLayer.EmployeeManagement.AddEmployee(employee);
                    Console.WriteLine($" {j} rows effected ");
                    break;

                    case 2: List<Employee> emp =DataAccessLayer.EmployeeManagement.GetAllEmployees();
                            foreach(Employee em in emp)
                    {
                        Console.WriteLine($"ID: {em.Id} Name: {em.Name} Compentency: {em.compentency} Salary: {em.salary} Department: {em.Department}");
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter Employee ID, Name, Compentency, Salary, Department: ");
                    Employee employee2 = new Employee();
                    employee2.Id = Convert.ToInt32(Console.ReadLine());
                    employee2.Name = Console.ReadLine();
                    employee2.compentency = Convert.ToInt32(Console.ReadLine());
                    employee2.salary = Convert.ToInt32(Console.ReadLine());
                    employee2.Department = Console.ReadLine();
                    bool b = DataAccessLayer.EmployeeManagement.UpdateEmployee(employee2);
                    if (b)
                        Console.WriteLine($"Operation Successful");
                    else
                        Console.WriteLine("Operation Failed");
                    break;

                case 4:
                    Console.WriteLine("Enter ID");
                    int a=Convert.ToInt32(Console.ReadLine());   
                    bool c=DataAccessLayer.EmployeeManagement.DeleteEmployee(a);
                    if (c)
                        Console.WriteLine($"Operation Successful");
                    else
                        Console.WriteLine("Operation Failed");
                    break;

                default:
                    Console.WriteLine("Wrong Choice");
                    break;

            }
        }
    }
}