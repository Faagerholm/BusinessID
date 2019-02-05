using System;
using System.Collections.Generic;
using System.Text;

namespace Specifications
{
    class Program{
        static void Main()
        {
            BusinessIdSpecification BISmanager = new BusinessIdSpecification();
            BusinessID id;
            id.y_tunnus = "1S45367-5";
            Console.WriteLine(BISmanager.IsSatisfiedBy(id) ? "Satisfied" : string.Join("\n",BISmanager.ReasonsForDissatisfaction));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
