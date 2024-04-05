﻿using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!IsValidEmail(email) || !IsValidFirstNameAndLastName(firstName, lastName))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (!user.isAdult())
            {
                return false;
            }
            
            user.SetupCredit(client);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsValidFirstNameAndLastName(string firstName, string lastName)
        {
            return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
        }
    }
}
