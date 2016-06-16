using FlowDesign.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.DataAccess.Converter
{
    public interface IProjectConverter
    {
        string ConvertObject<T>(T objectData);
        T ConvertObjectBack<T>(string objectDataString);
        string[] SimpleConvertBackToString(string dataString);
    }
}
