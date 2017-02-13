using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS
{
    class ConstClass {
        //HERE COMES SQL CONNECTION SETTINGS
        public static string SqlCon = "user id=ACERE1\\1;" +
                                       "password=;server=(localdb)\\ProjectsV12;" +
                                       "Trusted_Connection=yes;" +
                                       "database=CIS; " +
                                       "connection timeout=5";
    }

    interface IManage
    {
        void UploadFromDB(int EntityID);
        void SaveToDB();
        int Suggest(Dictionary<string, object> Info);
        void Approve();
        void Decline();
    }

    interface IAuthenticate {
        bool Login(string Email, string Password);
//        void Logout(string Email);
        bool Register(string Name, string Email, string Password);
    }

    interface IFeedback
    {
        void Send();
    }
}
