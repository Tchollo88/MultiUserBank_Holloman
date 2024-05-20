using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Holloman_Project
{
    public class Bank
    {
        #region **Instanst Data**

        private decimal _bankBalance = 10000m;
        private decimal _acBalance;
        private decimal _withdrawl;
        private decimal _deposit;

        #endregion

        #region **Constructor**
        public Bank(string Withdrawl, string Deposit)
        {
            decimal WD = decimal.Parse(Withdrawl);
            decimal DP = decimal.Parse(Deposit);
            _withdrawl = WD;
            _deposit = DP;
        }
        #endregion

        #region **Getter & Setter**
        //
        public string SetACBalance()
        {
            return _acBalance.ToString();
        }
        //
        public decimal SetBankBalance()
        {
            return _bankBalance;
        }

        #endregion

        #region **Operations**

        /*Quality of Life Functions*/

        //Converts strinbg value from array toi a decimal for mathing.
        public decimal convertBalance(string Balance)
        {
            decimal ConBal = decimal.Parse(Balance);
            _acBalance = ConBal;
            return ConBal;
        }

        //Converts negative amiount to a positive for message input.
        public string NegativeBalance(string Withdrawl)
        {
            decimal WD = decimal.Parse(Withdrawl);
            WD = WD * -1;
            return Withdrawl = WD.ToString();
        }

        /*Math Engines*/

        //Applies withdrawl math to the account, subtracting the wanded amount from the user's account total.
        public string withdrawlBalance(string Withdrawl, string Balance)
        {
            string Check = "WD";
            decimal WD = decimal.Parse(Withdrawl);
            decimal ConBal = convertBalance(Balance);
            decimal BankBal = _bankBalance;

            ConBal = BankCheck(BankBal, ConBal, Check);

            _acBalance = ConBal - WD;
            Balance = _acBalance.ToString();
            return Balance;
        }

        //Applies deposit math to the account, add desired amount to the user's account total.
        public string depositeBalance(string Deposite, string Balance)
        {
            string check = "DP";
            decimal DP = decimal.Parse(Deposite);
            decimal ConBal = convertBalance(Balance);
            decimal BankBal = _bankBalance;

            ConBal = BankCheck(BankBal, ConBal, check);
            
            _acBalance = ConBal + DP; ;
            Balance = _acBalance.ToString();
            return Balance;

        }

        //Checks to make sure there is money in the bank, and maths the appropriate amount to the Bank total.
        public decimal BankCheck(decimal BankBal, decimal ConBal, string Check)
        {
            if(BankBal >= ConBal && BankBal > 0 &&  Check == "WD")
            {
                BankBal = BankBal - ConBal;
                _bankBalance = BankBal;
                return ConBal;
            }
            else if (BankBal <= 0 && Check == "WD")
            {
                return 0;
            }
            else
            {
                BankBal = ConBal + BankBal;
                _bankBalance = BankBal;
                return ConBal;
            }
        }

        #endregion
    }
}
