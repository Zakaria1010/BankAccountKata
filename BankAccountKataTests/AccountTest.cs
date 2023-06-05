using BankAccountKata;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountKataTests
{
    public class AccountTest
    {

        // print statement on console
        private Account account;
        public AccountTest() {
            account = new Account();
        }


        [Fact]
        public void Should_Print_Statement_Header()
        {
            // console shoule display
            var recorder = new ConsoleRecorder();

            using(recorder)
            {
                 account.PrintStatement();
            }
            
            recorder.Display.Trim('\r', '\n').Should().Be("DATE|AMOUNT|BALANCE");
        }

        [Fact]
        public void Should_Add_Deposit_Line_To_Statement()
        {
            account.Deposit(500, "01/04/2014");

            var recorder = new ConsoleRecorder();

            using (recorder)
            {
                account.PrintStatement();
            }

            recorder.Display.Trim('\r', '\n').Should().Be(
                "DATE|AMOUNT|BALANCE\r\n01/04/2014|500,00|500,00"
                );

        }

        [Fact]
        public void Should_Add_WithDraw_Line_To_Statement()
        {
            account.Deposit(500, "01/04/2014");
            account.Withdraw(100, "02/04/2014");
           
            var recorder = new ConsoleRecorder();

            using (recorder)
            {
                account.PrintStatement();
            }

            recorder.Display.Trim('\r', '\n').Should().Be(
                "DATE|AMOUNT|BALANCE\r\n" +
                "01/04/2014|500,00|500,00\r\n" +
                "02/04/2014|-100|400,00"
                );
        }
    }

    internal class ConsoleRecorder: IDisposable
    {
        private readonly TextWriter oldOutputStream;
        private readonly StringWriter recorder;
        public string Display => recorder.ToString();
        
        public ConsoleRecorder()
        {
            oldOutputStream = Console.Out;
            recorder = new StringWriter();
            Console.SetOut(recorder);
        }

        public void Dispose()
        {
            Console.SetOut(oldOutputStream);
        }
    }
}
