using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public bool isAdult()
        {
            var now = DateTime.Now;
            int age = now.Year - DateOfBirth.Year;
            
            if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day)) 
                age--;

            return age > 21;
        }

        public void SetupCredit(Client client)
        {
            HasCreditLimit = !client.isImportantClient();

            if (client.Type != "VeryImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    creditLimit *= (client.isImportantClient() ? 2 : 1);
                    CreditLimit = creditLimit;
                }
            }
        }
    }
}