using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using Datalayer;

namespace ICT4EVENTS
{
    public class LoginAD
    {
        DatabaseConnection dbconn = new DatabaseConnection();

        public string getUserGroupDB(string username)
        {
            string result = dbconn.getUserGroup(username);
            return result;
        }
        public bool CreateUserAccount(string userName, string passWord)
        {
            string oGUID = "";
            string ldapPath = "DC=INFRA-S42, DC=local";
            try
            {
                string userPassword = passWord;
                oGUID = string.Empty;
                string connectionPrefix = "LDAP://" + "CN=Users," + ldapPath;
                DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix);
                DirectoryEntry newUser = dirEntry.Children.Add
                    ("CN=" + userName, "user");
                newUser.Properties["samAccountName"].Value = userName;
                newUser.CommitChanges();
                oGUID = newUser.Guid.ToString();

                newUser.Invoke("SetPassword", new object[] { userPassword });
                newUser.CommitChanges();
                dirEntry.Close();
                newUser.Close();

                string userDn = "CN=" + userName + ",CN=Users,DC=INFRA-S42,DC=local";
                string groupDN = "CN=Testgroep,CN=Users,DC=INFRA-S42,DC=local";
                AddToGroup(userDn, groupDN);

                //MessageBox.Show("Succes");
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //DoSomethingwith --> E.Message.ToString();
                //MessageBox.Show(E.ToString());
                return false;
            }
            return true;
           // return oGUID;
        }
        public void AddToGroup(string userDn, string groupDn)
        {
            try
            {
                DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + groupDn);
                dirEntry.Properties["member"].Add(userDn);
                dirEntry.CommitChanges();
                dirEntry.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //doSomething with E.Message.ToString();

            }
        }
        public void Create(string ouPath, string name)
        {
            if (!DirectoryEntry.Exists("LDAP://CN=" + name + "," + ouPath))
            {
                try
                {
                    DirectoryEntry entry = new DirectoryEntry("LDAP://" + ouPath);
                    DirectoryEntry group = entry.Children.Add("CN=" + name, "group");
                    group.Properties["sAmAccountName"].Value = name;
                    group.CommitChanges();
                    //MessageBox.Show("succes");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
            else { Console.WriteLine(ouPath + " already exists"); }
        }
        public void Enable(string userDn)
        {
            try
            {
                DirectoryEntry user = new DirectoryEntry(userDn);
                int val = (int)user.Properties["userAccountControl"].Value;
                user.Properties["userAccountControl"].Value = val & ~0x2;
                //ADS_UF_NORMAL_ACCOUNT;

                user.CommitChanges();
                user.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //DoSomethingWith --> E.Message.ToString();

            }
        }
        private bool Authenticate(string userName, string password, string domain)
        {
            bool authentic = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain,
                    userName, password);
                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException) { }
            return authentic;
        }
        public bool confirmPassword(string password, string confirmPassword)
        {
            if(password == confirmPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool accountReservationCheck(string firstname, string lastname)
        {
            return dbconn.checkForReservation(firstname, lastname);
        }
        public void addAccount(string email, string username, string password)
        {
            dbconn.addAccount(email, username, password);
        }
        public bool checkUsernameExist(string username)
        {
            return dbconn.usernameExistsCheck(username);
        }
    }
}