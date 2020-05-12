using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class ModelBooks
    {
        private Int32 _BookID;
        public Int32 BookID { get { return _BookID; } set { _BookID = value; } }

        private String _Title;
        public String Title { get { return _Title; } set { _Title = value; } }
        private String _Author;
        public String Author { get { return _Author; } set { _Author = value; } }
        private String _ISBN;
        public String ISBN { get { return _ISBN; } set { _ISBN = value; } }
        private String _Publisher;
        public String Publisher { get { return _Publisher; } set { _Publisher = value; } }
        private String _BYear;
        public String BYear { get { return _BYear; } set { _BYear = value; } }

    }
}