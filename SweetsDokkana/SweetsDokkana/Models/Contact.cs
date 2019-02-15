using System;
using System.Collections.Generic;
using System.Text;

namespace SweetsDokkana.Models
{
    public class Contact
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _mail;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }



    }
}
