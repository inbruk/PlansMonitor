using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using BusinessLogicLayer.Tools.Interfaces;
using BusinessLogicLayer.Tools.Holders;

namespace Test_EmailTool
{
    class Program
    {
        // Внимание !!! Для тестирования под аккаунтом gmail нужно отключить двойную аутентификацию и разрешить доступ "ненадежных приложений" !!!
        // В appsettings.json должны быть заданны верные параметры smtp сервера и аккаунта на нем
        // У пользователя с Id = 1 должен быть адекватный e-mail на который придет 2-е письмо
        // Также полсе 3-х отсылок гугль все складывает в спам, не отсылая. Будте осторожны.

        static void Main(string[] args)
        {
            Console.WriteLine("Try to send a mail. Check app config -------------------------------------------------------------------------");
            var emailTool = EmailToolHolder.Get();

                                    //  V  тут ваше мыло на которое прийдет 1 письмо
            emailTool.SendFromDefault("...", "test 22 send from default to custom email", "Если вам не удается войти в свой клиент электронной почты, вы можете видеть такие ошибки");
            emailTool.SendFromDefaultToUser( 1, "test 33 send from default to user", "Воспользуйтесь паролем приложения. Если вы используете двухэтапную аутентификацию, введите пароль приложения.");
        }
    }
}
