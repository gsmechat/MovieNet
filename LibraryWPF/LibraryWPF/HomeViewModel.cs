using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LibraryBDD;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace LibraryWPF
{
    public class HomeViewModel :  ViewModelBase
    {
        /******** Attriute of this ViewModel *********/
        private DAOFacadeSingleton DAOF;
        private ObservableCollection<Movy> _movieList = new ObservableCollection<Movy>();
        private User _user;
        private Movy _selectedMovie;

        /******** Setter/Getter of this Attriutes *********/
        public ObservableCollection<Movy> MovieList
        {
            get { return _movieList; }
            set
            {
                _movieList = value;
                RaisePropertyChanged();
            }
        }
        public Movy SelectedMovie
        {
            get { return _selectedMovie;  }
            set
            {
                if (_selectedMovie != value)
                {
                    Set("SelectedMovie", ref _selectedMovie, value);
                    // It's for after first turn
                    if (ViewModelLocator.movieCardViewModel != null)
                    {
                        ViewModelLocator.movieCardViewModel.Movie = value;

                        // Remove all item on AvisList
                        ViewModelLocator.movieCardViewModel.AvisList.Clear();
                        List<Avi> als = new List<Avi>();
                        als = DAOF.getAllAvisforIdMovie(value);
                        foreach (Avi currentAvis in als)
                        {
                            ViewModelLocator.movieCardViewModel.AvisList.Add(currentAvis);
                        }
                    }

                    this.RaisePropertyChanged("SelectedMovie");
                    
                }
            }
        }
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged();
            }
        }
        
        /** *********** Constructor ******** **/
        public HomeViewModel()
        {
            DAOF = new DAOFacadeSingleton();
            List<Movy> mls = new List<Movy>();
            mls = DAOF.getAllMovys();
            if (mls.Count != 0)
                SelectedMovie = mls.First();


            foreach (Movy currentMovie in mls)
            {
                _movieList.Add(currentMovie);
            }
            
            DeleteMovie = new RelayCommand(DeleteMovieExe, DeleteMovieCanExe);
            AddMovie = new RelayCommand(AddMovieExe, AddMovieCanExe);
            ModificationMovie = new RelayCommand(ModificationMovieExe, ModificationMovieCanExe);
            ConsultationMovie = new RelayCommand(ConsultationMovieExe, ConsultationMovieCanExe);
        }

        /** *********** Methode Access ******** **/
        public RelayCommand DeleteMovie { get; }
        public RelayCommand AddMovie  { get; }
        public RelayCommand ModificationMovie { get; }
        public RelayCommand ConsultationMovie { get; }

        /** *********** Methode Delete Movie ******** **/
        void DeleteMovieExe()
        {
            if(SelectedMovie != null)
            {
                DAOF.deleteMovie(SelectedMovie);
                ViewModelLocator.homeViewModel.MovieList.Remove(SelectedMovie);
            }
        }

        bool DeleteMovieCanExe()
        {
            return true;
        }
        
        void AddMovieExe()
        {
            ViewModelLocator.createMovieViewModel.VisibilityAddBtn = "Visible";
            ViewModelLocator.createMovieViewModel.VisibilityUpdateBtn = "Hidden";
            ViewModelLocator.createMovieViewModel.Title = "";
            ViewModelLocator.createMovieViewModel.Genre = "";
            ViewModelLocator.createMovieViewModel.Summary = "";
            ViewModelLocator.createMovieViewModel.Msg = "";
            CreateMovieWindow CreateMovieWin = new CreateMovieWindow();
            CreateMovieWin.Show();
        }

        bool AddMovieCanExe()
        {
            return true;
        }

        void ModificationMovieExe()
        {
            ViewModelLocator.createMovieViewModel.VisibilityAddBtn = "Hidden";
            ViewModelLocator.createMovieViewModel.VisibilityUpdateBtn = "Visible";
            ViewModelLocator.createMovieViewModel.Title = SelectedMovie.Title;
            ViewModelLocator.createMovieViewModel.Genre = SelectedMovie.Genre;
            ViewModelLocator.createMovieViewModel.Summary = SelectedMovie.Summary;
            ViewModelLocator.createMovieViewModel.Msg = "";
            CreateMovieWindow CreateMovieWin = new CreateMovieWindow();
            CreateMovieWin.Show();
        }

        bool ModificationMovieCanExe()
        {
            return true;
        }

        void ConsultationMovieExe()
        {
            MovieCard MovieCardWin = new MovieCard();
            MovieCardWin.Show();
        }

        bool ConsultationMovieCanExe()
        {
            return true;
        }
    }
}
