using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace CIS
{
    class MainVisualizer
    {
        ObservableCollection<Concert> upcomingConcerts;
        ObservableCollection<Band> bands;
        ObservableCollection<Concert> concerts;

        public ObservableCollection<Concert> UpcomingConcerts
        {
            get
            {
                return upcomingConcerts;
            }
            set
            {
                upcomingConcerts = value;
            }
        }

        public ObservableCollection<Band> Bands
        {
            get
            {
                return bands;
            }
            set
            {
                bands = value;
            }
        }

        public ObservableCollection<Concert> Concerts
        {
            get
            {
                return concerts;
            }
            set
            {
                concerts = value;
            }
        }

        public MainVisualizer()
        {
            bands = new ObservableCollection<Band>();
            concerts = new ObservableCollection<Concert>();
            upcomingConcerts = new ObservableCollection<Concert>();
        }
    }

    class GenresVisualizer
    {
        ObservableCollection<Genre> notSelectedGenres;
        ObservableCollection<Genre> selectedGenres;

        public ObservableCollection<Genre> NotSelectedGenres
        {
            get
            {
                return notSelectedGenres;
            }
            set
            {
                notSelectedGenres = value;
            }
        }

        public ObservableCollection<Genre> SelectedGenres
        {
            get
            {
                return selectedGenres;
            }
            set
            {
                selectedGenres = value;
            }
        }

        public GenresVisualizer()
        {
            selectedGenres = new ObservableCollection<Genre>();
            notSelectedGenres = new ObservableCollection<Genre>();
        }
    }

    class BandsVisualizer
    {
        ObservableCollection<Band> notSelectedBands;
        ObservableCollection<Band> selectedBands;

        public ObservableCollection<Band> NotSelectedBands
        {
            get
            {
                return notSelectedBands;
            }
            set
            {
                notSelectedBands = value;
            }
        }

        public ObservableCollection<Band> SelectedBands
        {
            get
            {
                return selectedBands;
            }
            set
            {
                selectedBands = value;
            }
        }

        public BandsVisualizer()
        {
            selectedBands = new ObservableCollection<Band>();
            notSelectedBands = new ObservableCollection<Band>();
        }
    }

    class PlacesVisualizer
    {
        ObservableCollection<Place> places;

        public ObservableCollection<Place> Places
        {
            get
            {
                return places;
            }
            set
            {
                places = value;
            }
        }

        public PlacesVisualizer()
        {
            places = new ObservableCollection<Place>();
        }
    }

    class SuggestedVisualizer
    {
        ObservableCollection<Entity> news;

        public ObservableCollection<Entity> News 
        {
            get
            {
                return news;
            }
            set
            {
                news = value;
            }
        }

        public SuggestedVisualizer()
        {
            news = new ObservableCollection<Entity>();
        }
    }

    class FeedbackVisualizer
    {
        ObservableCollection<BandFeedback> bandFeedbackList;
        ObservableCollection<PlaceFeedback> placeFeedbackList;
        ObservableCollection<ConcertFeedback> concertFeedbackList;

        public ObservableCollection<BandFeedback> BandFeedbackList
        {
            get
            {
                return bandFeedbackList;
            }
            set
            {
                bandFeedbackList = value;
            }
        }

        public ObservableCollection<PlaceFeedback> PlaceFeedbackList
        {
            get
            {
                return placeFeedbackList;
            }
            set
            {
                placeFeedbackList = value;
            }
        }

        public ObservableCollection<ConcertFeedback> ConcertFeedbackList
        {
            get
            {
                return concertFeedbackList;
            }
            set
            {
                concertFeedbackList = value;
            }
        }

        public FeedbackVisualizer()
        {
            bandFeedbackList = new ObservableCollection<BandFeedback>();
            placeFeedbackList = new ObservableCollection<PlaceFeedback>();
            concertFeedbackList = new ObservableCollection<ConcertFeedback>();
        }
    }
}
