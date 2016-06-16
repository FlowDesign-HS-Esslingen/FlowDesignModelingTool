using FlowDesign.DataAccess.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.DataAccess
{
    public enum DataAccessType
    {
        Local,
    }

    public static class DataAccessProvider
    {
        public static IRepository GetRepository(DataAccessType dataAccessType)
        {
            if(dataAccessType == DataAccessType.Local)
            {
                return new LocalRepository(new XmlConverter());
            }

            return null;
        }
    }
}
