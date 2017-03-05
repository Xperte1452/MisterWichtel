using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsWichtel
{
    public partial class WichtelForm : Form
    {
        /// <summary>
        /// Manager zum Versenden von Emails
        /// </summary>
        private MailManager mailManager;
        public WichtelForm()
        {
            InitializeComponent();
            mailManager = new MailManager("smtp.web.de", "misterwichtel@web.de", "",this);
        }

        /// <summary>
        /// Erzeugt Liste mit Zufallszahlen
        /// </summary>
        /// <param name="lenght"></param>
        /// <returns></returns>
        private List<int>getRandomNumbers(int lenght)
        {
            Random rnd = new Random();
            List<int> retVals = new List<int>();
            int randomNumber = 0;

            for(int i=0;i<lenght;i++)
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

            //foreach(int i in retVals)
            //{ Debug.Print("-> "+i); }

            return retVals;
        }

        /// <summary>
        /// Email hinzufügen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text)&&IsValidEmail(textBoxEmail.Text)==true)
            {
                listOfUsers.Items.Add(textBoxEmail.Text);
                lab_AnzTeilnehmer.Text = "Anzahl Teilnehmer: " + listOfUsers.Items.Count;
            }
            if(listOfUsers.Items.Count>0)
                listOfUsers.SetSelected(0, true);

            textBoxEmail.Clear();
            textBoxEmail.Focus();
        }
        /// <summary>
        /// Email entfernen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                listOfUsers.Items.Remove(listOfUsers.SelectedItem);
                lab_AnzTeilnehmer.Text = "Anzahl Teilnehmer: " + listOfUsers.Items.Count;
            
            if (listOfUsers.Items.Count > 0)
                listOfUsers.SetSelected(0, true);
        }
        /// <summary>
        /// Prüft ob Email dem Standardformat entspricht
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
              @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        /// <summary>
        /// Startet Emailversand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startWichteln_Click(object sender, EventArgs e)
        {
            if (listOfUsers.Items.Count>1)
            {
                List<int> randomIds = new List<int>();
                List<string> emails = new List<string>();
                randomIds = getRandomNumbers(listOfUsers.Items.Count);

                foreach (object item in listOfUsers.Items)
                {
                    emails.Add(item.ToString());
                }

                string tempListItem;
                //würfeln der Emailadressen
                for (int i = 0; i < emails.Count; i++)
                {
                    for (int j = 0; j < emails.Count; j++)
                    {
                        tempListItem = emails[i];
                        emails[i] = emails[randomIds[j]];
                        emails[randomIds[j]] = tempListItem;
                    }
                }

                //Emails versenden
                string message;
                for (int i = 0; i < emails.Count; i++)
                {

                    if (i < emails.Count-1)
                    {
                        message = "Hallo " + getNameFromEmail(emails[i]).ToLower() + ",\n\n" + "vielen Dank für die Teilname am Wichtelprogramm. Dein Wichtel Partner ist: " +
                                getNameFromEmail(emails[i + 1]) + "\n\n Liebe Grüße" + "\n MisterWichtel";
                        //Debug.Print(emails[i] + " beschenkt--> " + emails[i + 1]);
                        Task t = Task.Run(() =>
                        {
                          if( mailManager.SendEmail(emails[i], message, "Wichtellosung")==true)
                              labMailSend.Text = "Emails versendet: " + i+1;
                          else
                          {
                              MessageBox.Show("Eine Email konnte nicht verschickt werden");
                          }
                        });
                        t.Wait();
                        
                    }
                    else //Wenn die letzte Email erreicht wurde, schenkt der letzte an den Ersten
                    {
                        message = "Hallo " + getNameFromEmail(emails[i]).ToLower() + ",\n\n" + "vielen Dank für die Teilname am Wichtelprogramm. Dein Wichtel Partner ist: " +
                                getNameFromEmail(emails[0]) + "\n\n Liebe Grüße" + "\n MisterWichtel";
                        //Debug.Print(emails[i] + " beschenkt--> " + emails[0]);
                        Task t = Task.Run(() =>
                        {
                            if (mailManager.SendEmail(emails[i], message, "Wichtellosung") == true)
                                labMailSend.Text = "Emails versendet: " + i + 1;
                            else
                            {
                                MessageBox.Show("Eine Email konnte nicht verschickt werden");
                            }
                        });
                        t.Wait();
                  
                    }
                }

                Debug.Print("####");
            }
            else
            {
                MessageBox.Show("Sie können nicht mit sich selber wichteln!","Achtung",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

       }
        /// <summary>
        /// Sondiert den Namen aus Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private string getNameFromEmail(string email)
        {
            return email.Split('@')[0];
        }

        /// <summary>
        /// Setzt Anzahl der versendeten Mails
        /// </summary>
        /// <param name="count"></param>
        public void SetMailCounterSend(int count)
        {
            if (InvokeRequired)
                lab_AnzTeilnehmer.Invoke(
                    new Action(() => lab_AnzTeilnehmer.Text = "Emails versendet: " + count));

        }
    }
}
