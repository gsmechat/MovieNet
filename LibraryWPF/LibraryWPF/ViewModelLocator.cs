using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF
{
    public class ViewModelLocator
    {
        public static MainViewModel mainViewModel { get; } = new MainViewModel();
        public static HomeViewModel homeViewModel { get; } = new HomeViewModel();
        public static MovieCardViewModel movieCardViewModel { get; } = new MovieCardViewModel();
        public static AccountCreatorViewModel accountCreatorViewModel { get; } = new AccountCreatorViewModel();
        public static CreateMovieViewModel createMovieViewModel { get; } = new CreateMovieViewModel();
    }
}
