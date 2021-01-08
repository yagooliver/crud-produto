namespace CrudBackend.Application.ViewModels
{
    public class LoginVM
    {
        public LoginVM()
        {
            
        }

        public LoginVM(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public string Login { get; set; }  
        public string Senha { get; set; }
    }
}