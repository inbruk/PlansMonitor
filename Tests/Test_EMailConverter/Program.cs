using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using BusinessLogicLayer;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Tools;
using BusinessLogicLayer.Tools.Interfaces;
using BusinessLogicLayer.Tools.Holders;

namespace Test_EMailConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create main objects with content and converter  ------------------------------------------------------");
            MainObjectsHolder.UpdateAuditById(1);
            MainObjectsHolder.UpdateRemarkById(1);
            MainObjectsHolder.UpdateCorrectiveActionById(1);

            IEMailConverter emailConverter = new EMailConverterTool();
                       
            Console.WriteLine("Try to convert valid template to e-mail --------------------------------------------------------------");
            string template1 =
                " <B>Здравствуйте, Некто</B> \n" +
                "                         \n" +
                " Буря мглою {Аудит.Основание}небо кроет,  \n" +
                " Вихри{ЗамечаниеВнуП.Описание} снежные крутя;    \n" +
                " То, как зверь, {ЗамечаниеВнеП.РазделПрил} она завоет, \n" +
                " То заплачет, как дитя, \n" +
                " <span style=/'color:red/'>То по кровле {МероприятиеВнуП.КоррМер} обветшалой </span> \n" +
                " Вдруг соломой зашумит,     \n" +
                " То, как <I>путник {МероприятиеВнуП.ОтвИспФИО}</I> запоздалый, \n" +
                " К нам в окошко застучит {МероприятиеВнуП.ФактСрокИсп}.   \n" +
                "                         \n" +
                " <span style=/'color:kblue/'>С уважением, \n" +
                " Никто Н.Н.</span>                        \n";
            EMailConverterResult result1 = emailConverter.ConvertTemplate2Mail(template1);


            Console.WriteLine("Try to convert template with interrupted tag with space ----------------------------------------------");
            string template2 =
                " <B>Здравствуйте, Некто</B> \n" +
                "                         \n" +
                " Буря мглою {Аудит.Основание}небо кроет,  \n" +
                " Вихри{ЗамечаниеВнуП.Описание} снежные крутя;    \n" +
                " То, как зверь, {Замечание ВнеП.РазделПрил} она завоет, \n" +
                " То заплачет, как дитя, \n" +
                " <span style=/'color:red/'>То по кровле {Меропр иятиеВнуП.КоррМер} обветшалой </span> \n" +
                " Вдруг соломой зашумит,     \n" +
                " То, как <I>путник {МероприятиеВнуП.Отв</I>ИспФИО} запоздалый, \n" +
                " К нам в окошко застучит {МероприятиеВнуП.ФактСрокИсп}.   \n" +
                "                         \n" +
                " <span style=/'color:kblue/'>С уважением, \n" +
                " Никто Н.Н.</span>                           \n";
            EMailConverterResult result2 = emailConverter.ConvertTemplate2Mail(template2);


            Console.WriteLine("Try to convert template with interrupted tag with eol ----------------------------------------------");
            string template3 =
                " <B>Здравствуйте, Некто</B> \n" +
                "                         \n" +
                " Буря мглою {Аудит.Осно\n"+ 
                                       "вание}небо кроет,  \n" +
                " Вихри{ЗамечаниеВнуП.Описание} снежные крутя;    \n" +
                " То, как зверь, {ЗамечаниеВнеП.РазделПрил} она завоет, \n" +
                " То заплачет, как дитя, \n" +
                " <span style=/'color:red/'>То по кровле {МероприятиеВнуП.КоррМер} обветшалой </span> \n" +
                " Вдруг соломой зашумит,     \n" +
                " То, как <I>путник {Меро\n" + 
                                       "приятиеВнуП.Отв</I>ИспФИО} запоздалый, \n" +
                " К нам в окошко застучит {МероприятиеВнуП.ФактСрокИсп}.   \n" +
                "                         \n" +
                " <span style=/'color:kblue/'>С уважением, \n" +
                " Никто Н.Н.</span>                        \n";
            EMailConverterResult result3 = emailConverter.ConvertTemplate2Mail(template3);


            Console.WriteLine("Try to convert template with interrupted tag with eof ----------------------------------------------");
            string template4 =
                " <B>Здравствуйте, Некто</B> \n" +
                "                         \n" +
                " Буря мглою {Аудит.Основание}небо кроет,  \n" +
                " Вихри{ЗамечаниеВнуП.Описание} снежные крутя;    \n" +
                " То, как зверь, {ЗамечаниеВнеП.Раздел\n";
            EMailConverterResult result4 = emailConverter.ConvertTemplate2Mail(template4);

            Console.WriteLine("Try to convert template with { { or {{ ------------------------------------------");
            string template5 =
                " <B>Здравствуйте, Некто</B> \n" +
                "                         \n" +
                " Буря мглою {Аудит.Основание}небо кроет,  \n" +
                " Вихри{ЗамечаниеВнуП.Описание} снежные крутя;    \n" +
                " То, как зверь, {{ЗамечаниеВнеП.РазделПрил} она завоет, \n" +
                " То заплачет, как дитя, \n" +
                " <span style=/'color:red/'>То по кровле {МероприятиеВнуП.КоррМер} обветшалой </span> \n" +
                " Вдруг соломой зашумит,     \n" +
                " То, как <I>путник {{МероприятиеВнуП.Отв</I>ИспФИО} запоздалый, \n" +
                " К нам в окошко застучит {МероприятиеВнуП.ФактСрокИсп}.   \n" +
                "                         \n" +
                " <span style=/'color:kblue/'>С уважением, \n" +
                " Никто Н.Н.</span>                        \n";
            EMailConverterResult result5 = emailConverter.ConvertTemplate2Mail(template5);

            Console.WriteLine("Try to convert template with {} } or } ------------------------------------------");
            string template6 =
                " <B>Здравствуйте, Некто</B> \n" +
                "                         \n" +
                " Буря мглою {Аудит.Основание}небо кроет,  \n" +
                " Вихри{ЗамечаниеВнуП.Описание} снежные крутя;    \n" +
                " То, как зверь, {ЗамечаниеВнеП.РазделПрил}} она завоет, \n" +
                " То заплачет, как дитя, \n" +
                " <span style=/'color:red/'>То по кровле {МероприятиеВнуП.КоррМер} обветшалой }</span> \n" +
                " Вдруг соломой зашумит,     \n" +
                " То, как <I>путник {МероприятиеВнуП.Отв</I>ИспФИО} запоздалый, \n" +
                " К нам в окошко застучит {МероприятиеВнуП.ФактСрокИсп}.   \n" +
                "                         \n" +
                " <span style=/'color:kblue/'>С уважением, \n" +
                " Никто Н.Н.</span>                        \n";
            EMailConverterResult result6 = emailConverter.ConvertTemplate2Mail(template6);
        }
    }
}
