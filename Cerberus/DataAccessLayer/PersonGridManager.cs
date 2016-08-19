using Cerberus.AbstractClasses;
using Cerberus.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.DataAccessLayer
{
    public class PersonGridManager : AbstractManager
    {
        public GridResultContainer GetGrid(GridRequestContainer GridRequest)
        {
            GridResultContainer result = new GridResultContainer();
            
            return result;
        }

        public PersonGridManager(MainContext Context) : base(Context) { }
    }
}