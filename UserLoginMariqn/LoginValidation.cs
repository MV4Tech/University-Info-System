using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginMariqn
{
    
    public class LoginValidation
    {
        public static UserRoles currentUserRole { get; private set; }

        private string _username;
        private string _password;
        private string _errorLog;
        public delegate void ActionOnError(string errorMsg);
        ActionOnError error;


        public LoginValidation(string username, string password,ActionOnError error)
        {
            this._username = username;
            this._password = password;
            this.error = error;
        }


        

        public Boolean validateUserInput(ref User user)
        {
            user = UserData.isUserPassCorrect(_username, _password);

            if (user == null)
            {
                _errorLog = "Wrong username or password";
                currentUserRole = UserRoles.ANONYMOUS;
                error(_errorLog);
            }



            Boolean emptyUserName;
            emptyUserName = _username.Equals(String.Empty);
            if (emptyUserName)
            {
                _errorLog = "No username specified";
                currentUserRole = UserRoles.ANONYMOUS;
                error(_errorLog);
                return false;
            }

            Boolean emptyPass;
            emptyPass = _password.Equals(String.Empty);
            if(emptyPass)
            {
                _errorLog = "No password specified";
                currentUserRole = UserRoles.ANONYMOUS;
                error(_errorLog);
                return false;
            }

            if(_username.Length < 5 || _password.Length < 5)
            {
                _errorLog = "Password and Username must be at least 5 characters long";
                currentUserRole = UserRoles.ANONYMOUS;
                error(_errorLog);
                return false;
            }


          
            if(user != null)
            currentUserRole = user.role;
            //Logger.currActivities = 0;
            Logger.LogActivity(Activities.USER_LOGIN);
            //Logger.LogActivity("Successfull Login");

            //old
            //Logger.LogActivity();
            return true;
        }



    }
}
