using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.EmployeeManager.UI.WinForms.Utils
{
    public class clistitems
    {
        private string sText;
        private string iValue;

        public clistitems()
        {
            sText = string.Empty;
            iValue = "0";
        }

        public clistitems(string Name, string Id)
        {
            sText = Name;
            iValue = Id;
        }

        public string Name
        {
            get
            {
                return sText;
            }
            set
            {
                sText = value;
            }
        }

        public string Id
        {
            get
            {
                return iValue;
            }
            set
            {
                iValue = value;
            }
        }

        public override string ToString()
        {
            return sText;
        }
    }
}
