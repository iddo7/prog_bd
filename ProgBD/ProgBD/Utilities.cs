﻿using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgBD
{
    internal static class Utilities
    {

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        public static int CurrentAge(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;

            // Check if the birthday has occurred this year
            if (birthday.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public static void SetVisibility(UIElement element, bool state)
        {
            if (state)
                element.Visibility = Visibility.Visible;
            else
                element.Visibility = Visibility.Collapsed;
        }

        public static bool ContainsNumbers(string input)
        {
            return Regex.IsMatch(input, @"\d");
        }

        public static bool ContainsSymbols(string input)
        {
            return Regex.IsMatch(input, @"[^\w\s]");
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Valid Phone Number : (555) 123-4567
            string pattern = @"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }

        public static string HashSHA256(string input)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder output = new StringBuilder();

            foreach (byte b in bytes)
            {
                output.Append(b.ToString("x2"));
            }
            return output.ToString();
        }

    }
}
