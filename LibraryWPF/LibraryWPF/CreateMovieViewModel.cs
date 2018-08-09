using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBDD;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmValidation;

namespace LibraryWPF
{
    public class CreateMovieViewModel : ViewModelBase
    {
        /******** Attriute of this ViewModel *********/
        private DAOFacadeSingleton DAOF;
        private String _genre;
        private String _title;
        private String _summary;
        private string _msg;
        private List<string> _errorList;
        private string _visibilityAddBtn = "Visible";
        private string _visibilityUpdateBtn = "Hidden";

        /******** Setter/Getter of this Attriutes *********/
        public String Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                RaisePropertyChanged();
            }
        }
        public String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
        public String Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
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
        public String VisibilityAddBtn
        {
            get { return _visibilityAddBtn; }
            set
            {
                _visibilityAddBtn = value;
                RaisePropertyChanged();
            }
        }
        public String VisibilityUpdateBtn
        {
            get { return _visibilityUpdateBtn; }
            set
            {
                _visibilityUpdateBtn = value;
                RaisePropertyChanged();
            }
        }

        /************************** Constructor ********************/
        public CreateMovieViewModel()
        {
            DAOF = new DAOFacadeSingleton();
            CreateMovie = new RelayCommand(CreateMovieExe, CreateMovieCanExe);
            UpdateMovie = new RelayCommand(UpdateMovieExe, UpdateMovieCanExe);
            Validator = new ValidationHelper();
            Validator.AddRequiredRule(() => Summary, "Sommaire obligatoire");
            Validator.AddRequiredRule(() => Genre, "Genre obligatoire");
            Validator.AddRequiredRule(() => Title, "Titre obligatoire");
        }

        public RelayCommand CreateMovie { get; }
        public RelayCommand UpdateMovie { get; }
        protected ValidationHelper Validator { get; private set; }

        /************************** Methodes ********************/
        void CreateMovieExe()
        {
            Validator.ValidateAll();
            var validationResult = Validator.GetResult();
            if (validationResult.IsValid)
            {
                // Build movy Object
                Movy m = new Movy();
                m.Summary = Summary;
                m.Title = Title;
                m.Genre = Genre;
                m.Avis = new List<Avi>();

                // Insert object in Database
                DAOF.insertMovie(m);

                // Refresh front office
                ViewModelLocator.homeViewModel.MovieList.Add(m);
                Summary = "";
                Title = "";
                Genre = "";
                Msg = "Votre film est créé";

                // Remove all erreur of ErrorList
                ErrorList = new List<string>();

            }
            else
            {
                List<string> ErrorListLocal = new List<string>();
                foreach (MvvmValidation.ValidationError validationError in validationResult.ErrorList)
                {
                    ErrorListLocal.Add(validationError.ErrorText);
                }
                ErrorList = ErrorListLocal;
                Msg = "Erreur dans votre saisi";
                
            }
        }

        bool CreateMovieCanExe()
        {
            return true;
        }

        void UpdateMovieExe()
        {
            Validator.ValidateAll();
            var validationResult = Validator.GetResult();
            if (validationResult.IsValid)
            {
                // Build movy Object
                Movy tmp = ViewModelLocator.homeViewModel.SelectedMovie;
                Movy m = ViewModelLocator.homeViewModel.SelectedMovie;
                m.Summary = Summary;
                m.Title = Title;
                m.Genre = Genre;

                // Insert object in Database
                DAOF.updateMovie(m);

                // Refresh front office
                ViewModelLocator.homeViewModel.MovieList.Remove(tmp);
                ViewModelLocator.homeViewModel.MovieList.Add(m);

                Summary = "";
                Title = "";
                Genre = "";
                Msg = "Votre film est modifié";

                // Remove all erreur of ErrorList
                ErrorList = new List<string>();

            }
            else
            {
                List<string> ErrorListLocal = new List<string>();
                foreach (MvvmValidation.ValidationError validationError in validationResult.ErrorList)
                {
                    ErrorListLocal.Add(validationError.ErrorText);
                }
                ErrorList = ErrorListLocal;
                Msg = "Erreur dans votre saisi";

            }
        }

        bool UpdateMovieCanExe()
        {
            return true;
        }

    }
}
