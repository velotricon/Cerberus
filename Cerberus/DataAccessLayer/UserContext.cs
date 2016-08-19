using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Cerberus.DataAccessLayer
{
    public class UserContext : IOwinContext
    {
        public IAuthenticationManager Authentication
        {
            get { throw new NotImplementedException(); }
        }

        public IDictionary<string, object> Environment
        {
            get { throw new NotImplementedException(); }
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public IOwinRequest Request
        {
            get { throw new NotImplementedException(); }
        }

        public IOwinResponse Response
        {
            get { throw new NotImplementedException(); }
        }

        public IOwinContext Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public TextWriter TraceOutput
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}