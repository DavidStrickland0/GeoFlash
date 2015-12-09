using GeoFlash.PCL.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoFlash.ViewModel
{
    class SpellCheckViewModel:GeoFlashViewModel
    {

        public SpellCheckViewModel(bool hasOrderedList)
            : base(hasOrderedList)
        {

        }

        public int NumberOfTries { get; set; }

        public string hintText;
        public string HintText 
        { 
            get{return hintText;}
            set { 
                hintText = value;
                OnPropertyChanged("HintText");
            } 
        }

        public Color backGroundColor;
        public Color BackGroundColor
        {
            get { return backGroundColor; }
            set
            {
                backGroundColor = value;
                OnPropertyChanged("BackGroundColor");
            }
        }

        internal void CheckSpelling(string stringToCheck)
        {
            HintText = "";
            if (string.Compare(stringToCheck, base.ImageTitle,StringComparison.CurrentCultureIgnoreCase)==0||NumberOfTries>2)
            {
                switch (NumberOfTries)
                {
                    case 0:
                        Points = Points + 10;
                        break;
                    case 1:
                        Points = Points + 3;
                        break;
                    case 2:
                        Points = Points + 1;
                        break;
                }
                if (!EndOfList)
                {
                    NumberOfTries = 0;
                    MoveNext();
                }
                else
                {
                    if (DisplayScore != null)
                    {
                        DisplayScore(this, Points);
                    }
                    OnRequestClose();
                }
            }
            else
            {

                Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () => ResetFormColor());
                BackGroundColor = Color.Red;

                NumberOfTries++;

                IVibrator vibrator = DependencyService.Get<IVibrator>();
                vibrator.Vibrate(100);

                SetHintText();

            }
        }

        public bool ResetFormColor()
        {
            BackGroundColor = Color.FromRgb(147, 199, 221);
            return false;
        }

        public event EventHandler<int> DisplayScore;
        private void SetHintText()
        {
            char previousChar = ' ';
            StringBuilder builder = new StringBuilder();
            foreach(char c in base.ImageTitle)
            {
                if (NumberOfTries == 1)
                {
                    if (c != ' ')
                    {
                        builder.Append('_');
                    }
                    else
                    {
                        builder.Append(' ');
                    }
                }
                if (NumberOfTries == 2)
                {
                    if (previousChar==' ')
                    {
                        builder.Append(c);
                    }
                    else if (c != ' ')
                    {
                        builder.Append('_');
                    }
                    else
                    {
                        builder.Append(' ');
                    }
                    previousChar=c;
                }
                if (NumberOfTries == 3)
                {
                    builder.Append(c);
                }
            }
            HintText = builder.ToString();
        }

        int points;
        public int Points
        {
            get { return points; }
            set
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }
    }
}
