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
        private readonly char Y_TUNNUS_SPLIT_CHAR = '-';
        private readonly int ID_LENGTH = 9;
        private readonly int SPLIT_CHAR_INDEX = 7;
        private string pattern = @"^\d{7}-\d{1}$";

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
        //  Checks if entity accepted by BusinessIDSpecification
        //
        //  </summary>
        public bool IsSatisfiedBy(BusinessID entity)
        {
            // Check if entity not defined.
            if (entity.Equals(null)) return false;
            // If Y-tunnus is OK, continue.
            if (Regex.Match(entity.y_tunnus, pattern).Success) return true;
            dissatisfactionList = new List<string>();
            // Check length of Y-tunnus
            if(entity.y_tunnus.Length != ID_LENGTH) dissatisfactionList.Add(entity.y_tunnus.Length < ID_LENGTH? "Y-tunnus is too short.": "Y-tunnus is too long.");
            else{
                // Check if format is correct.
                if(!entity.y_tunnus[SPLIT_CHAR_INDEX].Equals(Y_TUNNUS_SPLIT_CHAR)) dissatisfactionList.Add("Y-tunnus format is wrong.");
                // if format is correct check for illegal characters, only accept numbers and designated split char. 
                else if(!Regex.Match(entity.y_tunnus, pattern).Success) dissatisfactionList.Add("Y-tunnus contains illegal characters.");
            }

            if (dissatisfactionList.Count == 0) dissatisfactionList.Add("Unimplemented error.");
            return false;
        }
    }
}
