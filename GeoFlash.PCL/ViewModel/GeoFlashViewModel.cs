using GeoFlash.Library.Model;
using GeoFlash.Library.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoFlash.ViewModel
{
    class GeoFlashViewModel:INotifyPropertyChanged
    {
        protected IList<FlashCardItem> CardList = null;
        public GeoFlashViewModel(bool hasOrderedList, bool capitolList = false)
        {
            SortedDictionary<object, FlashCardItem> sortedFlashCards = new SortedDictionary<object, FlashCardItem>();
            var randomizer = new Random();
            foreach (FlashCardItem item in FlashCardRepo.FlashCards)
            {
                if (hasOrderedList)
                {
                    sortedFlashCards.Add(item.ImageName, item);
                }
                else if (capitolList)
                {
                    if (item.ImageCapitol != "None" && item.ImageCapitol!="")
                    {
                        sortedFlashCards.Add(randomizer.Next(), item);
                    }
                }
                else
                {
                    sortedFlashCards.Add(randomizer.Next(), item);
                }
            }
            currentIndex = 0;
            CardList = new List<FlashCardItem>(sortedFlashCards.Values);
            TotalQuestionCount = CardList.Count;
            UpdateCard();
            startTime = DateTime.Now; 
        }

        private DateTime startTime;
        protected virtual void UpdateCard()
        {
            ImagePath = CardList[currentIndex].ImagePath;
            ImageTitle = CardList[currentIndex].ImageName;
            ImageCapitol = CardList[currentIndex].ImageCapitol;
        }

        private int currentIndex; 
        public int CurrentIndex 
        {
            get
            {
                return currentIndex;
            }
            set
            {
                currentIndex = value;
                OnPropertyChanged("CurrentIndex");
            }
        }

        private int totalQuestionCount;
        public int TotalQuestionCount
        {
            get
            {
                return totalQuestionCount;
            }
            set
            {
                totalQuestionCount = value;
                OnPropertyChanged("TotalQuestionCount");
            }
        }

        string imagePath;
        public string ImagePath 
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }            
        }

        string imageTitle;
        public string ImageTitle
        {
            get { return imageTitle; }
            set
            {
                imageTitle = value;
                OnPropertyChanged("ImageTitle");
            }
        }

        string imageCapitol;
        public string ImageCapitol
        {
            get { return imageCapitol; }
            set
            {
                imageCapitol = value;
                OnPropertyChanged("ImageCapitol");
            }
        }

        public bool EndOfList {
            get { return CurrentIndex >= CardList.Count - 1; } 
        }
        public bool StartOfList
        {
            get { return CurrentIndex == 0; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal bool MovePrevious()
        {
            if(currentIndex>0)
            {
                CurrentIndex--;
            }
            OnPropertyChanged("StartOfList");
            OnPropertyChanged("EndOfList");
            UpdateCard();
            return true;
        }

        internal bool MoveNext()
        {
            if (currentIndex < CardList.Count - 1)
            {
                CurrentIndex++;
            }

            OnPropertyChanged("StartOfList");
            OnPropertyChanged("EndOfList");

            UpdateCard();
            return true;
        }

        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            if(RequestClose!=null)
            {
                RequestClose(this,new EventArgs());
            }
        }
    }
}
