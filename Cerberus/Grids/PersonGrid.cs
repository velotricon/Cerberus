using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cerberus.Containers;
using Cerberus.DataAccessLayer;

namespace Cerberus.Grids
{
    public class PersonGrid
    {
        public GridDescriptorContainer GetDescriptor()
        {
            GridDescriptorContainer descriptor = new GridDescriptorContainer();
            TranslationManager translation_manager = new TranslationManager();
            descriptor.GridName = "PERSON_GRID";

            throw new NotImplementedException();
        }
    }
}