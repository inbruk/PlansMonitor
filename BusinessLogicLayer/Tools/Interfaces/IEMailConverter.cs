using System;
using System.Collections.Generic;
using System.Text;

using BusinessLogicLayer.DataTransferObjects;

namespace BusinessLogicLayer.Tools.Interfaces
{
    public interface IEMailConverter
    {
        EMailConverterResult ConvertTemplate2Mail(string template);
    }
}
