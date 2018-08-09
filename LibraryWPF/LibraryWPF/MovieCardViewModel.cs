using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Controls;
using MvvmValidation;
using System.Windows.Media.Imaging;
using System.Windows;
using LibraryBDD;
using System.Collections.ObjectModel;

namespace LibraryWPF
{

    public class MovieCardViewModel : ViewModelBase
    {
        private DAOFacadeSingleton DAOF;

        private Movy _movie;
        private string _title;
        private string _genre;
        private string _summary;
        private ObservableCollection<Avi> _avisList = new ObservableCollection<Avi>();
        private string _note;
        private double _noteAdd;
        private string _commentAdd;
        private List<string> _errorList;

        public Movy Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                RaisePropertyChanged();
            }
        }
        public string Title
        {
            get { return _title; }
            set {
                _title = value;
                RaisePropertyChanged();
            }
        }
        public string Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                RaisePropertyChanged();
            }
        }
        public string Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
                RaisePropertyChanged();
            }
        }
        public string Note
        {
            get { return _note; }
            set
            {
                    _note = value;
                RaisePropertyChanged();
            }
        }
        public double NoteAdd
        {
            get { return _noteAdd; }
            set
            {
                _noteAdd = value;
                RaisePropertyChanged();
            }
        }
        public string CommentAdd
        {
            get { return _commentAdd; }
            set
            {
                _commentAdd = value;
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
        public ObservableCollection<Avi> AvisList
        {
            get { return _avisList; }
            set
            {
                _avisList = value;
                RaisePropertyChanged();
            }
        }

        /** *********** Constructor ******** **/
        public MovieCardViewModel()
        {
            DAOF = new DAOFacadeSingleton();
            AddComment = new RelayCommand(AddCommentExe, AddCommentCanExe);
            Validator = new ValidationHelper();
            Validator.AddRequiredRule(() => NoteAdd, "Note obligatoire");
            Validator.AddRequiredRule(() => CommentAdd, "Commentaire obligatoire");
        }

        /** *********** Methode Access ******** **/
        public RelayCommand AddComment { get; }
        protected ValidationHelper Validator { get; private set; }

        /** *********** Methode Add Comment ******** **/
        void AddCommentExe()
        {
            Validator.ValidateAll();
            var validationResult = Validator.GetResult();
            if (validationResult.IsValid)
            {
                /******************* Build Object for commit in Database *******************/
                Avi avis = new Avi();
                avis.Note = NoteAdd;
                avis.Commentaire = CommentAdd;

                Movy m = new Movy();
                m = DAOF.getMovie(ViewModelLocator.homeViewModel.SelectedMovie);

                avis.Movy = m;
                avis.Movies_Id = m.Id;

                User u = new User();
                u = DAOF.getUser(ViewModelLocator.mainViewModel.User);

                avis.User = u;
                avis.User_Id = u.Id;

                /*******************  Insert in Database *******************/
                DAOF.insertAvis(avis);

                /******************* Add Avis in front End *****************/
                AvisList.Add(avis);

                /******************* Remove attribute front End *****************/
                NoteAdd = 0;
                CommentAdd = "";
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

        bool AddCommentCanExe()
        {
            return true;
        }

        
    }
}
