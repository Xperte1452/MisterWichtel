using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AE.Net.Mail;
using Batman.Core.Communication.SMTP;
namespace TestWhatsappApi
{
    class Program
    {
        static void Main(string[] args)
        {
            getRandomNumbers(8);
            Batman.Core.Communication.SMTP.Emailer eMailer = new Emailer();
           
       
            
            Console.ReadKey();
        }

        private static List<int> getRandomNumbers(int lenght)
        {
            Random rnd = new Random();
            List<int> retVals = new List<int>();
            int randomNumber = 0;

            for (int i = 0; i < lenght; i++)
            {
                do
                {
                    randomNumber = rnd.Next(0, lenght);

                    if (!retVals.Contains(randomNumber))
                    {
                        retVals.Add(randomNumber);
                        break;
                    }
                } while (true);
            }

            foreach (int i in retVals)
            { Console.WriteLine("-> " + i); }

            return retVals;
        }


        static void getMessages(ImapClient ic)
        {
            List<MailMessage> m;
            m = ic.GetMessages(0, 1000, true, false) //speicher Mail liste von ungesehenen Mails
                                           .Where(m_ => !m_.Flags.HasFlag(Flags.Seen)
                                                  && !m_.Flags.HasFlag(Flags.Deleted)).ToList();

           foreach(MailMessage mm in m)
            {
                Console.WriteLine(mm.Subject);
            }

        }


    }
}
