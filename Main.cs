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
            id.y_tunnus = "1245367-T";
            Console.WriteLine(BISmanager.IsSatisfiedBy(id) ? "Satisfied" : string.Join("\n",BISmanager.ReasonsForDissatisfaction));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
