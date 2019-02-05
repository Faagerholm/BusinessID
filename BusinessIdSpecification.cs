using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Specifications
{

    //  <summary>
    //  Struct to be associated with y-tunnus.
    //  As of 2019 Y-tunnus should be of format ddddddd-d
    //  </summary>
    //  <param name="y_tunnus">
    public struct BusinessID
    {
        public string y_tunnus;
    }

    public class BusinessIdSpecification : ISpecification<BusinessID> {
        // Specifications for Y-tunnus
        private char Y_TUNNUS_SPLIT_CHAR = '-';
        private readonly int ID_LENGTH = 9;
        private readonly int SPLIT_CHAR_INDEX = ID_LENGTH - 2;
        private string pattern = @"^\d{" + ID_LENGTH-SPLIT_CHAR_INDEX + @"}"+ Y_TUNNUS_SPLIT_CHAR + @"\d{" + ((ID_LENGTH-SPLIT_CHAR_INDEX)+1) + @"}$";

        List<string> dissatisfactionList;

        // Constructor
        public BusinessIdSpecification(){
            dissatisfactionList = new List<string>();
        }

        public IEnumerable<string> ReasonsForDissatisfaction
        {
            get
            {
                if (dissatisfactionList != null)
                {
                    foreach (string reason in dissatisfactionList)
                    {
                        yield return reason;
                    }
                }
            }
        }
        
        //  <summary>
        //  Check if entity accepted by BusinessIDSpecification
        //
        //  </summary>
        public bool IsSatisfiedBy(BusinessID entity)
        {
            // Check if entity not defined.
            if (entity == null) return false;
            // If Y-tunnus is OK, continue.
            if (Regex.Match(entity.y_tunnus, pattern).Success) return true;
            dissatisfactionList = new List<string>();
            // Check length of Y-tunnus
            if(entity.y_tunnus.Length != ID_LENGTH) if(entity.y_tunnus.Length < ID_LENGTH? dissatisfactionList.Add("Y-tunnus is too short."): dissatisfactionList.Add("Y-tunnus is too long."));
            else{
                // Check if format is correct.
                if(!entity.y_tunnus[Y_TUNNUS_SPLIT_CHAR_INDEX] != Y_TUNNUS_SPLIT_CHAR) dissatisfactionList.Add("Y-tunnus format is wrong.");
                // if format is correct check for illegal characters, only accept numbers and designated split char. 
                else if(!Regex.Match(entity.y_tunnus, pattern).Success) dissatisfactionList.Add"Y-tunnus contains illegal characters.");
            }
            return false;
        }
    }
}
