using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace MultiUserBank_Holloman_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            string User = "";
            string Pass = "";

            int count = 0;
           
            string Withdrawl = "0";
            string Deposit = "0";
            string Balance = "0";

            Bank MUBank = new Bank(Withdrawl, Deposit);
            Account Person = new Account();

            LoginMenu(User, Pass, Balance, MUBank, Person, count);

            AccountMenu(User, Pass, Person, MUBank, Withdrawl, Deposit, Balance, count);
        }


        #region **Menus**

        public static void LoginMenu(string User, string Pass, string Balance, Bank Alpha, Account Person, int Count)
        {
            Count = Person.getCount(Count);
            Count++;
            Person.setCount(Count);

            #region **Data**
            /*Arrays*/
            string[] u1;
            string[] u2;
            string[] u3;
            string[] u4;

            //Array 1 Data
            u1 = new string[4];
            u1[0] = "01";
            u1[1] = "jlennon";
            u1[2] = "johnny";

            //Array 2 Data
            u2 = new string[4];
            u2[0] = "02";
            u2[1] = "pmccartney";
            u2[2] = "pauly";

            //Array 3 Data
            u3 = new string[4];
            u3[0] = "03";
            u3[1] = "gharrison";
            u3[2] = "georgy";

            //Array 4 Data
            u4 = new string[4];
            u4[0] = "04";
            u4[1] = "rstarr";
            u4[2] = "ringoy";

            if (Count <= 1)
            {
                u1[3] = "1250";
                u2[3] = "2500";
                u3[3] = "3000";
                u4[3] = "1001";
            }
            else
            {
                u1[3] = Person.getBalance(Balance);
                u2[3] = Person.getBalance(Balance);
                u3[3] = Person.getBalance(Balance);
                u4[3] = Person.getBalance(Balance);
            }

            #endregion

            LogMenuIntro(Alpha);
            ConsoleKeyInfo key;
            key = Console.ReadKey();

            if(key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Unfortunately you did not eneter the correct option! \nPlease hit enter and try again....");
                Console.ReadLine();
                Console.Clear();
                LoginMenu(User, Pass, Balance, Alpha, Person, Count);
            }
            else if(key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("Please enter your username: ");
                User = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Welcome " + User + "\nPlease enter your password: ");
                Pass = Console.ReadLine();
                Console.Clear();

                if (User == u1[1] && Pass == u1[2])
                {
                    User = u1[1];
                    Balance = u1[3];
                    Person.balanceAmount(User, Pass, Balance);
                    Person.setID(User, Pass, Balance);
                    Alpha.acBalSet(Balance);

                }
                else if (User == u2[1] && Pass == u2[2])
                {
                    User = u2[1];
                    Balance = u2[3];
                    Person.balanceAmount(User, Pass, Balance);
                    Person.setID(User, Pass, Balance);
                    Alpha.acBalSet(Balance);

                }
                else if (User == u3[1] && Pass == u3[2])
                {
                    User = u3[1];
                    Balance = u3[3];
                    Person.balanceAmount(User, Pass, Balance);
                    Person.setID(User, Pass, Balance);
                    Alpha.acBalSet(Balance);

                }
                else if (User == u4[1] && Pass == u4[2])
                {
                    User = u4[1];
                    Balance = u4[3];
                    Person.balanceAmount(User, Pass, Balance);
                    Person.setID(User, Pass, Balance);
                    Alpha.acBalSet(Balance);

                }
                else
                {
                    Console.WriteLine
                        ("I am sorry, there is something wrong with the inputted data, please make sure that data is correct and try again.");
                    LoginMenu(User, Pass, Balance, Alpha, Person, Count);
                }
            }
            else if (key.Key == ConsoleKey.D2) 
            {
                return;
            }
            



        }

        /*Main account menu*/ //-- (1)Withdrawl    (2)Deposit    (3)Balance   (4)Log-out
        public static void AccountMenu
            (string User, string Pass, Account Person, Bank Alpha, string Withdrawal, string Deposit, string Balance, int Count)
        {
            User = Person.getName(User);
            Pass = Person.getPass(Pass);
            Balance = Person.getBalance(Balance);
            decimal Bal = decimal.Parse(Balance);
            MenuIntro(User);
            ConsoleKeyInfo Key = Console.ReadKey();

            // Checks to see if the approriate key is not pressed.
            if (Key.Key != ConsoleKey.D1 && Key.Key != ConsoleKey.D2 && Key.Key != ConsoleKey.D3 && Key.Key != ConsoleKey.D4)
            {
                Console.Clear();
                Console.WriteLine("Sorry, but you need to enter, either (1), (2), (3) or (4) to continue...");
                Console.WriteLine("Please hit enter and try again. Thank you!");
                Console.Clear();
                MenuIntro(User);
            }

            // Checks if the (1) key is pressed -- runs MakeWithdrawal().
            if (Key.Key == ConsoleKey.D1)
            {
                
                Console.Clear();
                MakeWithdrawal(User, Pass, Person, Alpha, Key, Withdrawal, Withdrawal, Balance, Count);
            }

            // Checks if the (2) key is pressed -- runs MakeDeposite().
            if (Key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                MakeDeposit(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
            }

            // Checks if the (3) key is pressed -- expresses balance. 
            if (Key.Key == ConsoleKey.D3)
            {
                Console.Clear();

                // Checks for a positive balance.
                if (Bal < 0)
                {
                    Console.WriteLine("Your current balance is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-$" + Balance);
                    Console.ResetColor();
                    Console.WriteLine("Please hit enter to continue....");
                    Console.ReadLine();
                    Console.Clear();
                    AccountMenu(User, Pass, Person, Alpha, Withdrawal, Deposit, Balance, Count);
                }

                //Checks for a negative balance.
                if (Bal > 0)
                {
                    Console.WriteLine("Your current balance is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("$" + Balance);
                    Console.ResetColor();
                    Console.WriteLine("Please hit enter to continue....");
                    Console.ReadLine();
                    Console.Clear();
                    AccountMenu(User, Pass, Person, Alpha, Withdrawal, Deposit, Balance, Count);
                }
            }

            // Checks if the (4) key is pressed -- Logs out of account.
            if (Key.Key == ConsoleKey.D4)
            {
                Console.Clear();
                LoginMenu(User, Pass, Balance, Alpha, Person, Count);
            }
        }

        /*SubMenu*/ //-- (1)Continue    (2)Return.
        public static void SubMenu
            (string User, string Pass, Account Person, Bank Alpha, ConsoleKeyInfo Key, string Withdrawal, string Deposit, string Balance, int Count)
        {
            //Clarifies that Withdrawal is selected.
            if (Key.Key == ConsoleKey.D1)
            {
                SubMenuIntro();
                ConsoleKeyInfo subkey = Console.ReadKey();

                //Checks that none of the appropriate keys have been pressed.
                if (subkey.Key != ConsoleKey.D1 && subkey.Key != ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, but you need to enter, either (1) or (2) to continue...");
                    Console.WriteLine("Please hit enter and try again. Thank you!");
                    Console.Clear();
                    Console.ReadLine();
                    SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
                }

                //Checks for the press of key (1) -- Loops back to MakeWithdrawal().
                if (subkey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    MakeWithdrawal(User, Pass, Person, Alpha, Key, Withdrawal, Withdrawal, Balance, Count);
                }

                //Checks the press of key (2) -- Loops back to AccountMenu().
                if (subkey.Key == ConsoleKey.D2)
                {
                    AccountMenu( User, Pass, Person, Alpha, Withdrawal, Deposit, Balance, Count);
                }
            }

            //Clarifies that Deposit is selected.
            if (Key.Key == ConsoleKey.D2)
            {
                SubMenuIntro();
                ConsoleKeyInfo subkey = Console.ReadKey();

                //Checks that none of the appropriate keys have been pressed.
                if (subkey.Key != ConsoleKey.D1 && subkey.Key != ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, but you need to enter, either (1) or (2) to continue...");
                    Console.WriteLine("Please hit enter and try again. Thank you!");
                    Console.ReadLine();
                    Console.Clear();
                    SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
                }

                //Checks for the press of key (1) -- Loops back to MakeDeposit().
                if (subkey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    MakeDeposit(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
                }

                //Checks the press of key (2) -- Loops back to AccountMenu().
                if (subkey.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    AccountMenu(User, Pass, Person, Alpha, Withdrawal, Deposit, Balance, Count);
                }
            }
        }
        #endregion

        #region **Messages**

        //Builds message for the LoginMenu().
        public static void LogMenuIntro(Bank Alpha)
        {

            Console.WriteLine("Welcome to the MUBank, our bank currently holds: ");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$" + Alpha.ShowBankBalance);
            Console.ResetColor();
            
            Console.WriteLine("\n\nplease select (1) Login or (2) Quit: ");
        }

        //Builds message for the AccountMenu().
        public static void MenuIntro(string User)
        {
            Console.WriteLine
              ("Welcome " + User + ", please enter one of the following options: \n (1) Withdrawl, (2) Depsoit, (3) Balance, or (4) Logout");
        }

        //Builds meassage for SubMenu().
        public static void SubMenuIntro()
        {
            Console.WriteLine("What would you like to do next? \n (1) Continue or (2) Return");
        }

        //Builds message for leaving program.
        public static void FinishLog()
        {
            Console.WriteLine("Thank you for using MUBank today, please come again!");
            Console.WriteLine("Please hit enter to go back to the main menu....");
            Console.ReadLine();
        }

        #endregion

        #region **Account Engine**

        //Builds Withdrawl function and feeds info for variables needed for the Account.
        public static void MakeWithdrawal(string User, string Pass, Account Person, Bank Alpha, ConsoleKeyInfo Key, string Withdrawal, string Deposit, string Balance, int Count)
        {
            decimal Bal = 0;
            decimal WD = 0;

            Console.WriteLine("Please enter the amount you would like to withdraw: ");
            Withdrawal = Console.ReadLine();
            WD = decimal.Parse(Withdrawal);
            Balance = Alpha.SetACBalance();

            Balance = CalculateWithdrawal(Alpha, Withdrawal, Balance);
            Bal = decimal.Parse(Balance);

            //Checks for negatice balance.
            if (Bal < 0)
            {
                Console.WriteLine("I am sorry, your account is currently lacking the funds that you requested. Please see a teller and enter some more money!");
                Console.WriteLine("Your account now is at:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("$0");
                Console.ResetColor();

                FinishLog();
                Console.Clear();
                AccountMenu(User, Pass, Person, Alpha, Withdrawal, Deposit, Balance, Count);
            }

            //Checks to see if the withdrawl will exceed the balance, if so empties the account and informs the user.
            else if (Bal < WD && Bal > 0)
            {
                Console.WriteLine("Unfortunately, you are currently lacking the funs you requested. \nYour acoount has been emptied, please go to the nearest teller and deposit some more.");
                Console.WriteLine("Your account currently sits with : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("$" + 0);
                Console.ResetColor();
                Console.WriteLine("Please hit enter to continue...");
                Console.ReadLine();
                Console.Clear();

                SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
            }

            //Checks to see if balance is positive.
            else if (Bal >= 0)
            {
                //Checks to insure that no more that 500 is withdrawn at a time.
                if (WD > 500)
                {
                    Console.Clear();

                    Withdrawal = "500";
                    Balance = CalculateWithdrawal(Alpha, Withdrawal, Balance);
                    Person.balanceAmount(User, Pass, Balance);
                    Alpha.acBalSet(Balance);

                    Console.WriteLine("We are only able to withdraw up to $500 max in a single withdrawl. \n $500 has been removed from your acount.");

                    Console.WriteLine("Your new balance is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("$" + Balance);
                    Console.ResetColor();
                    SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
                }
                else
                {
                    Balance = CalculateWithdrawal(Alpha, Deposit, Balance);
                    Person.balanceAmount(User, Pass, Balance);
                    Alpha.acBalSet(Balance);
                    Console.WriteLine("Your money has been withdrawn, \nYour new account balance is:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("$" + Balance);
                    Console.ResetColor();
                    SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
                } 
            }

        }

        public static void MakeDeposit(string User, string Pass,Account Person, Bank Alpha, ConsoleKeyInfo Key, string Withdrawal, string Deposit, string Balance, int Count)
        {
            Balance = Person.getBalance(Balance);
            Console.WriteLine("Please enter the amount you would like to deposite: ");
            Deposit = Console.ReadLine();

            if (Deposit.Contains("-"))
            {
                Console.WriteLine("We can not proccess you desired request. Please make sure the amount that you wish to deposit is a positive amount and try again. \n Please hit enter to continue...");
                Console.ReadLine();
                MakeDeposit(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
            }
            // Allows a Deposit.
            else
            {
                Balance = CalculateDeposit(Alpha, Deposit, Balance);
                Person.balanceAmount(User, Pass, Balance);
                Alpha.acBalSet(Balance);
                Console.WriteLine("Your new balance is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + Balance);
                Console.ResetColor();
                SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance, Count);
            }
        }
        #endregion

        #region **Math Engine**

        //Calculates math for withdrawing from the account.
        public static string CalculateWithdrawal(Bank alpha, string WD, string Bal)
        {
            Bal = alpha.withdrawlBalance(WD);

            return Bal;
        }

        //Calaculates math for depositing to the account.
        public static string CalculateDeposit(Bank alpha, string DP, string Bal)
        {
            Bal = alpha.depositeBalance(DP);

            return Bal;
        }
        #endregion

    }
}
