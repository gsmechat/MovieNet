using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LibraryBDD;

namespace LibraryWPF
{
    public class MainViewModel : ViewModelBase
    {
        /******** Attriute of this ViewModel *********/
        private DAOFacadeSingleton DAOF;   
        private string _login;
        private string _mdp;
        private string _error;
        private User _user;
        private AccountCreatorWindow _accountCreatorWin;

        /******** Setter/Getter of this Attriutes *********/
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged();
            }
        }
        public string Login
        {
            get { return _login; }
            set {
                _login = value;
                RaisePropertyChanged();
            }
        }
        public string Mdp
        {
            get { return _mdp; }
            set
            {
                _mdp = value;
                RaisePropertyChanged();
            }
        }
        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                RaisePropertyChanged();
            }
        }
        public AccountCreatorWindow AccountCreatorWin
        {
            get { return _accountCreatorWin; }
            set
            {
                _accountCreatorWin = value;
                RaisePropertyChanged();
            }
        }

        /*************** Constructor *************/
        public MainViewModel()
        {
            DAOF = new DAOFacadeSingleton();

            SignIn = new RelayCommand(SignInExe, SignInCanExe);
            SignUp = new RelayCommand(SignUpExe, SignUpCanExe);
            
        }

        public RelayCommand SignIn { get;}
        public RelayCommand SignUp { get; }
        

        /**************** Methodes *************/
        void SignInExe()
        {
            User u = new User();
            u.Login = Login;
            u.Password = Mdp;
            List<User> userList = DAOF.isUser(u);

            if (userList.Count() != 0 || u.Login == "test")
            {
                User = userList.First();
                HomeWindow homeWin = new HomeWindow();
                homeWin.Show();
            } else
            {
                Error = "Erreur ou identifiants inconnu";
            }
            
        }

        bool SignInCanExe()
        {
            return true;
        }
        
        void SignUpExe()
        {
            AccountCreatorWin = new AccountCreatorWindow();
            AccountCreatorWin.Show();
        }

        bool SignUpCanExe()
        {
            return true;
        }
    }
}
