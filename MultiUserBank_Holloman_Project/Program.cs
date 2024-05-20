using System.Security.Cryptography.X509Certificates;

namespace MultiUserBank_Holloman_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string User = "";
            string Pass = "";
            string ID = "";
            string Withdrawl = "0";
            string Deposit = "0";
            string Balance = "0";

            Bank MUBank = new Bank(Withdrawl, Deposit);
            Account Person = new Account();

            LoginMenu(User, Pass, Balance, Person);

            AccountMenu(User, Pass, Person, MUBank, Withdrawl, Deposit, Balance);
        }


        #region **Menus**

        public static void LoginMenu(string User, string Pass, string Balance, Account Person)
        {
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
            u1[3] = "1250";
            //Array 2 Data
            u2 = new string[4];
            u2[0] = "02";
            u2[1] = "pmccartney";
            u2[2] = "pauly";
            u2[3] = "2500";
            //Array 3 Data
            u3 = new string[4];
            u3[0] = "03";
            u3[1] = "gharrison";
            u3[2] = "georgy";
            u3[3] = "3000";
            //Array 4 Data
            u4 = new string[4];
            u4[0] = "04";
            u4[1] = "rstarr";
            u4[2] = "ringoy";
            u4[3] = "1001";
            #endregion

            LogMenuIntro();
            ConsoleKeyInfo key;
            key = Console.ReadKey();

            if(key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Unfortunately you did not eneter the correct option! \nPlease hit enter and try again....");
                Console.ReadLine();
                Console.Clear();
                LoginMenu(User, Pass, Balance, Person);
            }
            else if(key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("Please enter your username: ");
                User = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Welcome " + User + "\nPlease enter your password: ");
                Pass = Console.ReadLine();

                if (User == u1[1] && Pass == u1[2])
                {
                    User = u1[1];
                    Balance = u1[3];
                    Person.balanceAmount(User, Pass, Balance);

                }
                else if (User == u2[1] && Pass == u1[2])
                {
                    User = u2[1];
                    Balance = u2[3];
                    Person.balanceAmount(User, Pass, Balance);

                }
                else if (User == u3[1] && Pass == u1[2])
                {
                    User = u3[1];
                    Balance = u3[3];
                    Person.balanceAmount(User, Pass, Balance);

                }
                else if (User == u4[1] && Pass == u1[2])
                {
                    User = u4[1];
                    Balance = u4[3];
                    Person.balanceAmount(User, Pass, Balance);

                }
                else
                {
                    Console.WriteLine
                        ("I am sorry, there is something wrong with the inputted data, please make sure that data is correct and try again.");
                    LoginMenu(User, Pass, Balance, Person);
                }
            }
            else if (key.Key == ConsoleKey.D2) 
            {
                return;
            }
            



        }

        /*Main account menu*/ //-- (1)Withdrawl    (2)Deposit    (3)Balance   (4)Log-out
        public static void AccountMenu
            (string User, string Pass, Account Person, Bank Alpha, string Withdrawal, string Deposit, string Balance)
        {
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
                MakeWithdrawal(User, Pass, Person, Alpha, Key, Withdrawal, Withdrawal, Balance);
            }

            // Checks if the (2) key is pressed -- runs MakeDeposite().
            if (Key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                MakeDeposit(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
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
                }

                //Checks for a negative balance.
                if (Bal > 0)
                {
                    Console.WriteLine("Your current balance is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("$" + Balance);
                    Console.ResetColor();
                }
            }

            // Checks if the (4) key is pressed -- Logs out of account.
            if (Key.Key == ConsoleKey.D4)
            {
                LoginMenu(User, Pass, Balance, Person);
            }
        }

        /*SubMenu*/ //-- (1)Continue    (2)Return.
        public static void SubMenu(string User, string Pass, Account Person, Bank Alpha, ConsoleKeyInfo Key, string Withdrawal, string Deposit, string Balance)
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
                    SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
                }

                //Checks for the press of key (1) -- Loops back to MakeWithdrawal().
                if (subkey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    MakeWithdrawal(User, Pass, Person, Alpha, Key, Withdrawal, Withdrawal, Balance);
                }

                //Checks the press of key (2) -- Loops back to AccountMenu().
                if (subkey.Key == ConsoleKey.D2)
                {
                    AccountMenu( User, Pass, Person, Alpha, Withdrawal, Deposit, Balance);
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
                    SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
                }

                //Checks for the press of key (1) -- Loops back to MakeDeposit().
                if (subkey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    MakeDeposit(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
                }

                //Checks the press of key (2) -- Loops back to AccountMenu().
                if (subkey.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    AccountMenu(User, Pass, Person, Alpha, Withdrawal, Deposit, Balance);
                }
            }
        }
        #endregion

        #region **Messages**

        //Builds message for the LoginMenu().
        public static void LogMenuIntro()
        {
            Console.WriteLine("Welcome to the MUBank, please select (1) Login or (2) Quit: ");
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
        public static void MakeWithdrawal(string User, string Pass, Account Person, Bank Alpha, ConsoleKeyInfo Key, string Withdrawal, string Deposit, string Balance)
        {
            decimal Bal = 0;
            Console.WriteLine("Please enter the amount you would like to withdraw: ");
            Withdrawal = Console.ReadLine();
            Balance = Alpha.SetACBalance();

            Balance = CalculateWithdrawal(Alpha, Withdrawal, Balance);
            Bal = decimal.Parse(Balance);

            //Checks for negatice balance.
            if (Bal < 0)
            {
                Balance = Alpha.NegativeBalance(Balance);
                Console.WriteLine("Your money has been withdrawn, \nYour new account balance is:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-$" + Balance);
                Console.ResetColor();

                //Checks if value is greater than 1000, if so gives the pass thresh hold message.
                if (Bal > 1000)
                {
                    Console.WriteLine
                        ("Your account has been overdrawn passed the allowable amount, \nplease report to the nearest teller and balance your account!");
                    FinishLog();
                    Console.Clear();
                    AccountMenu(User, Pass, Person, Alpha, Withdrawal, Deposit, Balance);
                }

                SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
            }

            //Checks to see if balance is positive.
            else if (Bal >= 0)
            {
                Console.WriteLine("Your money has been withdrawn, \nYour new account balance is:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + Balance);
                Console.ResetColor();
                SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
            }

        }

        public static void MakeDeposit(string User, string Pass,Account Person, Bank Alpha, ConsoleKeyInfo Key, string Withdrawal, string Deposit, string Balance)
        {
            decimal Bal = 0;
            Console.WriteLine("Please enter the amount you would like to deposite: ");
            Deposit = Console.ReadLine();
            Bal = decimal.Parse(Deposit);

            //Checks to see if Deposit is more than 500.
            if (Bal > 500)
            {
                Console.Clear();

                Deposit = "500";
                Balance = CalculateDeposit(Alpha, Deposit, Balance);

                Console.WriteLine("We are only able to deposite up to $500 max in a single deposite. \n $500 has been added to your acount.");

                Console.WriteLine("Your new balance is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + Balance);
                Console.ResetColor();
                SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
            }
            // Allows a Deposit.
            else
            {
                Balance = CalculateDeposit(Alpha, Deposit, Balance);
                Console.WriteLine("Your new balance is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + Balance);
                Console.ResetColor();
                SubMenu(User, Pass, Person, Alpha, Key, Withdrawal, Deposit, Balance);
            }
        }
        #endregion

        #region **Math Engine**

        //Calculates math for withdrawing from the account.
        public static string CalculateWithdrawal(Bank alpha, string WD, string Bal)
        {
            Bal = alpha.withdrawlBalance(WD, Bal);

            return Bal;
        }

        //Calaculates math for depositing to the account.
        public static string CalculateDeposit(Bank alpha, string DP, string Bal)
        {
            Bal = alpha.depositeBalance(DP, Bal);

            return Bal;
        }
        #endregion

    }
}
