namespace Employee_Hierarchy_Management_System
{
    internal class Program
    {
        class Employee
        {
            public int id;
            public string name;

            public Employee(int id, string name)
            {
                this.id = id;
                this.name = name;
            }

            public virtual void DisplayInfo()
            {
                Console.WriteLine($"ID: {id}, Name: {name}");
            }

            public virtual int CalculateBonus()
            {
                return 1000;

            }
        }

        class Manager : Employee
        {
            public int teamSize;

            public Manager(int id, string name, int teamSize) : base(id, name)
            {
                this.teamSize = teamSize;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine("[ Manager ] ");
                base.DisplayInfo();
                Console.WriteLine($"Team Size: {teamSize}");
            }

            public override int CalculateBonus()
            {
                return base.CalculateBonus() + (teamSize * 200);
            }

        }

        class Developer : Employee
        {
            public string programmingLanguage;
            public Developer(int id, string name, string programmingLanguage) : base(id, name)
            {
                this.programmingLanguage = programmingLanguage;
            }
            public override void DisplayInfo()
            {
                Console.WriteLine("[ Developer ] ");
                base.DisplayInfo();
                Console.WriteLine($"Programming Language: {programmingLanguage}");
            }

            public override int CalculateBonus()
            {
                if (programmingLanguage == "C#")
                {
                    return base.CalculateBonus() + 500;
                }

                else
                {
                    return base.CalculateBonus() + 300;
                }
            }

            static void Main(string[] args)
            {
                List<Employee> employees = new List<Employee>();
                Console.WriteLine("Enter the number of employees: ");

                int n = Convert.ToInt32(Console.ReadLine());
                int id = 101;

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter employee type (1 for Manager, 2 for Developer): ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    if (choice == 1)
                    {
                        Console.WriteLine("Enter Team Size: ");
                        int teamSize = Convert.ToInt32(Console.ReadLine());
                        employees.Add(new Manager(id, name, teamSize));
                        id++;
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Enter Programming Language: ");
                        string programmingLanguage = Console.ReadLine();
                        employees.Add(new Developer(id, name, programmingLanguage));
                        id++;
                    }
                }

                foreach (Employee emp in employees)
                {
                    emp.DisplayInfo();
                    Console.WriteLine($"Bonus: {emp.CalculateBonus()}");
                   // Console.WriteLine("-----------------------------");
                }


            }
        }
    }
}
