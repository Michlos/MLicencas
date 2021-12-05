using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure
{
    public class QueryString
    {
        private static string _queryApp = @"SERVER=.\SQLEXPRESS;DATABASE=MLicencasDB;INTEGRATED SECURITY=SSPI";
        private static string _queryRemoteLicence = @"SERVER=.\SQLEXPRESS;DATABASE=MLicencasClienteDB;INTEGRATED SEGURITY=SSPI";

        public string GetQueryApp()
        { 
            return _queryApp;
        }
        public string GetQueryRemoteLicence()
        {
            return _queryRemoteLicence;
        }

    }
}
