using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceLayer.CommonServices;

namespace InfraStructure
{
    public class QueryString : IQueryStringRepository
    {
        private static string _queryApp = @"SERVER=.\SQLEXPRESS;DATABASE=MLicencasDB;INTEGRATED SECURITY=SSPI";
        private static string _queryRemoteLicence = @"SERVER=.\SQLEXPRESS;DATABASE=MLicencasClienteDB;INTEGRATED SEGURITY=SSPI";
        

        public string GetRemoteLicence()
        {
            return _queryRemoteLicence;
        }

        public string GetQueryApp()
        { 
            return _queryApp;
        }

        //public string GetQuery()
        //{
        //    return _queryApp;
        //}
    }
}
