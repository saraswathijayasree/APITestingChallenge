using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace APITestingChallenge.Helpers
{

    public static class DataHelper
    {
        /// <summary>
        /// Function to compare expected and result user data for a single user
        /// </summary>
        /// <param name="expectedUserData"></param>
        /// <param name="ResultUserData"></param>
        /// <returns></returns>
        public static bool CompareSingleUserData(User expectedUserData, User ResultUserData)
        {
            if ((expectedUserData.Id != ResultUserData.Id) ||
                (expectedUserData.Email != ResultUserData.Email) ||
                (expectedUserData.First_name != ResultUserData.First_name) ||
                (expectedUserData.Last_name != ResultUserData.Last_name) ||
                (expectedUserData.Avatar != ResultUserData.Avatar))

            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Function to compare expected and result user Ad data for a single user
        /// </summary>
        /// <param name="expectedAdData"></param>
        /// <param name="ResultAdData"></param>
        /// <returns></returns>
        public static bool CompareUserAdData(Ad expectedAdData, Ad ResultAdData)
        {
            if ((expectedAdData.Company != ResultAdData.Company) ||
                (expectedAdData.Url != ResultAdData.Url) ||
                (expectedAdData.Text != ResultAdData.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Function to compare expected and real user data for multiple Users
        /// </summary>
        /// <param name="expectedUserData"></param>
        /// <param name="ResultUserData"></param>
        /// <returns></returns>
        public static bool CompareMultipleUserData(List<User> expectedUserData, List<User> ResultUserData)
        {
            if (expectedUserData.Count != ResultUserData.Count)
            {
                return false;
            }
            foreach (var userData in expectedUserData)
            {
                var found = ResultUserData.Where(x => x.Id == userData.Id).First();
                if (found != null)
                {
                    if (!CompareSingleUserData(userData, found))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
