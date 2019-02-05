using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Specifications
{

    public struct BusinessID
    {
        public string y_tunnus;
    }

    public class BusinessIdSpecification : ISpecification<BusinessID> {
        private char Y_TUNNUS_SPLIT_CHAR = '-';
        private readonly int ID_LENGTH = 9;
        private string pattern = @"^\d{7}-\d{1}$";

        List<string> dissatisfactionList = new List<string>();

        // Constructor
        public BusinessIdSpecification()
        {
        }

        public IEnumerable<string> ReasonsForDissatisfaction
        {
            get
            {
                if (dissatisfactionList != null)
                {
                    foreach (String reason in dissatisfactionList)
                    {
                        yield return reason;
                    }
                }
            }
        }
        
        public bool IsSatisfiedBy(BusinessID entity)
        {
            if (Regex.Match(entity.y_tunnus, pattern).Success) return true;
            dissatisfactionList = new List<string>();
            // Check length of Y-tunnus
            if (entity.y_tunnus.Length < ID_LENGTH) dissatisfactionList.Add(entity.y_tunnus + " Y-tunnus is too short.");
            if (entity.y_tunnus.Length > ID_LENGTH) dissatisfactionList.Add(entity.y_tunnus + " Y-tunnus is too long.");
            // Check if Y-tunnus is of right format. As of 2019, the format is 1234567-8.
            if (entity.y_tunnus.Split(Y_TUNNUS_SPLIT_CHAR).Length != 2) dissatisfactionList.Add(entity.y_tunnus + " Y-tunnus format is wrong.");
            if (!Regex.Match(entity.y_tunnus, pattern).Success) dissatisfactionList.Add(entity.y_tunnus + " Y-tunnus contains illegal characters.");

            return false;
        }
    }
}
