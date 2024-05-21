using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Holloman_Project
{
    internal class Account
    {
        private string _un;
        private string _pass;
        private string _bal;

        private int _count = 0;

        private decimal _bal1 = 0;
        private decimal _bal2 = 0;
        private decimal _bal3 = 0;
        private decimal _bal4 = 0;

        public Account()
        {

        }

        public void setID(string User, string Pass, string Balance)
        {
            _un = User;
            _pass = Pass;
            _bal = Balance;

        }

        public void setCount(int Count)
        {
            _count = Count;
        }

        public string getName(string User)
        {
             return User = _un;
        }

        public string getPass(string Pass)
        {
            return Pass = _pass;
        }

        public string getBalance(string Balance)
        {
            return Balance = _bal;
        }

        public int getCount(int Count)
        {
            return Count = _count;
        }

        public void balanceAmount(string User, string Pass, string Balance)
        {
            if (User == "jlennon" && Pass == "johnny")
            {
                _bal1 = decimal.Parse(Balance);
            }
            else if (User == "pmccartney" && Pass == "pauly")
            {
                _bal2 = decimal.Parse(Balance);
            }
            else if (User == "gharrison" && Pass == "georgy")
            {
                _bal3 = decimal.Parse(Balance);
            }
            else if (User == "rstarr" && Pass == "ringoy")
            {
                _bal4 = decimal.Parse(Balance);
            }
        }







    }
}
