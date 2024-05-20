using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Holloman_Project
{
    internal class Account
    {

        private decimal _bal1;
        private decimal _bal2;
        private decimal _bal3;
        private decimal _bal4;

        public Account()
        {

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
