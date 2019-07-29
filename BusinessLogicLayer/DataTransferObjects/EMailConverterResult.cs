using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class EMailConverterResult
    {
        public EMailConverterResult(string err, int row, int column, string template, string email)
        {
            if (err == null)
            {
                ItHasError = false;
                FullErrorText = null;
            }
            else
            {
                ItHasError = true;
                FullErrorText = "Ошибка[" + row + "," + column + "]: " + err;
            }

            TemplateText = template;
            EMailText = email;
        }

        public bool ItHasError { get; }
        public string FullErrorText { get; }
        public string TemplateText { get; }
        public string EMailText { get; }
    }
}
