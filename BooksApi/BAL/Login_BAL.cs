using BooksApi.DAL;
using BooksApi.Model;

namespace BooksApi.BAL
{
    public class Login_BAL
    {
        Login_DAL login_DAL = new Login_DAL();
        public int login(string UserName,string Password)
        {
            try
            {
                return login_DAL.login(UserName, Password);

            }
            catch (Exception ex)
            {
                return -1;

            }
        }
    }
}
