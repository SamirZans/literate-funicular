using System;
using System.Text;

namespace PasswordGenerator
{
    // <summary>
    // A utility class that generates random passwords.
    // </summary>
    public class PasswordGenerator
    {
        // <summary>
        // Generates a random password with the specified length.
        //
        // Parameters:
        // - length: The length of the password to generate.
        //
        // Returns:
        // - A string representing the randomly generated password.
        //
        // Exceptions:
        // - Throws an ArgumentException if the specified length is less than or equal to zero.
        // </summary>
        public static string GeneratePassword(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Password length should be greater than zero.");
            }

            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(validChars.Length);
                password.Append(validChars[index]);
            }

            return password.ToString();
        }
    }
}

// Unit tests for PasswordGenerator

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PasswordGeneratorTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_GeneratePassword_InvalidLength()
    {
        var password = PasswordGenerator.GeneratePassword(0);
    }

    [TestMethod]
    public void Test_GeneratePassword_ValidLength()
    {
        var password = PasswordGenerator.GeneratePassword(8);
        Assert.AreEqual(8, password.Length);
    }

    [TestMethod]
    public void Test_GeneratePassword_ValidLength2()
    {
        var password = PasswordGenerator.GeneratePassword(12);
        Assert.AreEqual(12, password.Length);
    }

    [TestMethod]
    public void Test_GeneratePassword_ValidLength3()
    {
        var password = PasswordGenerator.GeneratePassword(16);
        Assert.AreEqual(16, password.Length);
    }
}

// Example program for PasswordGenerator class.

public class Program
{
    public static void Main()
    {
        // Example 1: Generate a password with length 8.
        var password1 = PasswordGenerator.GeneratePassword(8);
        Console.WriteLine($"Generated Password: {password1}");
        Console.WriteLine();  // Newline for separation.

        // Example 2: Generate a password with length 12.
        var password2 = PasswordGenerator.GeneratePassword(12);
        Console.WriteLine($"Generated Password: {password2}");
        Console.WriteLine();  // Newline for separation.

        // Example 3: Generate a password with length 16.
        var password3 = PasswordGenerator.GeneratePassword(16);
        Console.WriteLine($"Generated Password: {password3}");
    }
}
