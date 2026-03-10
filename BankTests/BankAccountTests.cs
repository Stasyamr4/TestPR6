using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr.Roman Abramovich", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 67.67;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningSumma = 21.22;
            double creditAmount = 10.00;
            double exception = 31.22;
            BankAccount account = new BankAccount("Ivanov Ivan", beginningSumma);

            account.Credit(creditAmount);

            double actual = account.Balance;
            Assert.AreEqual(exception, actual, 0.01);
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningSumma = 110.00;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Guyda Vlad", beginningSumma);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

        
    }
}
