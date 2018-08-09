using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LibraryBDD;
using MvvmValidation;

namespace LibraryWPF
{
    public class AccountCreatorViewModel : ViewModelBase
    {
        /******** Attriute of this ViewModel *********/
        private DAOFacadeSingleton DAOF;
        private string _login;
        private string _mdp;
        private string _msg;
        private List<string> _errorList;

        /******** Setter/Getter of this Attriutes *********/
        public string Login
        {
            get { return _login; }
            set
            {
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
        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                RaisePropertyChanged();
            }
        }
        public List<string> ErrorList
        {
            get { return _errorList; }
            set
            {
                _errorList = value;
                RaisePropertyChanged();
            }
        }

        /************* Constructor **********/
        public AccountCreatorViewModel()
        {
            DAOF = new DAOFacadeSingleton();

            AccountCreator = new RelayCommand(AccountCreatorExe, AccountCreatorCanExe);
            Validator = new ValidationHelper();
            Validator.AddRequiredRule(() => Login, "Login obligatoire");
            Validator.AddRequiredRule(() => Mdp, "Mot de passe obligatoire");
        }
        
        public RelayCommand AccountCreator { get; }
        protected ValidationHelper Validator { get; private set; }

        /************** Methodes **********/
        void AccountCreatorExe()
        {
            Validator.ValidateAll();
            var validationResult = Validator.GetResult();
            if (validationResult.IsValid)
            {
                /******************* Build Object for commit in Database *******************/
                User u = new User();
                u.Login = Login;
                u.Password = Mdp;

                /******************* Insert in Database *******************/
                DAOF.insertUser(u);

                /******************* Remove attribute front End ************/
                ViewModelLocator.mainViewModel.Login = Login;
                ViewModelLocator.mainViewModel.Mdp = Mdp;
                Login = "";
                Mdp = "";
                Msg = "User crée, retourné a la page de connection";
                ViewModelLocator.mainViewModel.Error = "User crée :)";
                ViewModelLocator.mainViewModel.AccountCreatorWin.Hide();
                ErrorList = new List<String>();
            }
            else
            {
                List<string> ErrorListLocal = new List<string>();
                foreach (MvvmValidation.ValidationError validationError in validationResult.ErrorList)
                {
                    ErrorListLocal.Add(validationError.ErrorText);
                }
                ErrorList = ErrorListLocal;
            }
           
        }

        bool AccountCreatorCanExe()
        {
            return true;
        }
    }
}
