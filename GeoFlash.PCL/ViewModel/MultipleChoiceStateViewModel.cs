using GeoFlash.PCL.DependencyServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoFlash.ViewModel
{
    class MultipleChoiceStateViewModel:GeoFlashViewModel,INotifyPropertyChanged 
    {
        public MultipleChoiceStateViewModel()
            : base(false)
        {}

        protected override void UpdateCard()
        {
            var rnd = new Random();

            SortedDictionary<int, string> answerList = new SortedDictionary<int, string>();
            answerList.Add(rnd.Next(), CardList[CurrentIndex].ImageName);
            while (answerList.Count < 4)
            {
                string nextPossibleName = CardList[rnd.Next(CardList.Count)].ImageName;
                if (!answerList.Values.Contains<string>(nextPossibleName))
                {
                    answerList.Add(rnd.Next(), nextPossibleName);
                }

            }
            IList<string> answers = answerList.Values.ToList<string>();
            FirstAnswer = answers[0];
            SecondAnswer = answers[1];
            ThirdAnswer = answers[2];
            ForthAnswer = answers[3];

            base.UpdateCard();
        }
        string firstAnswer;
        public string FirstAnswer
        {
            get { return firstAnswer; }
            set
            {
                firstAnswer = value;
                OnPropertyChanged("FirstAnswer");
               
            }
        }

        bool firstAnswerVisible = true;
        public bool FirstAnswerVisible
        {
            get
            {
                return firstAnswerVisible;
            }
            set
            {
                firstAnswerVisible = value;
                OnPropertyChanged("FirstAnswerVisible");

            }
        }

        string secondAnswer;
        public string SecondAnswer
        {
            get { return secondAnswer; }
            set
            {
                secondAnswer = value;
                OnPropertyChanged("SecondAnswer");
            }
        }

        bool secondAnswerVisible = true;
        public bool SecondAnswerVisible
        {
            get
            {
                return secondAnswerVisible;
            }
            set
            {
                secondAnswerVisible = value;
                OnPropertyChanged("SecondAnswerVisible");
            }
        }

        string thirdAnswer;
        public string ThirdAnswer
        {
            get { return thirdAnswer; }
            set
            {
                thirdAnswer = value;
                OnPropertyChanged("ThirdAnswer");
            }
        }

        bool thirdAnswerVisible = true;
        public bool ThirdAnswerVisible
        {
            get
            {
                return thirdAnswerVisible;
            }
            set
            {
                thirdAnswerVisible = value;
                OnPropertyChanged("ThirdAnswerVisible");
            }
        }

        string forthAnswer;
        public string ForthAnswer
        {
            get
            {
                return forthAnswer;
            }
            set
            {
                forthAnswer = value;
                OnPropertyChanged("ForthAnswer");
            }
        }

        bool forthAnswerVisible = true;
        public bool ForthAnswerVisible
        {
            get
            {
                return forthAnswerVisible;
            }
            set
            {
                forthAnswerVisible = value;
                OnPropertyChanged("ForthAnswerVisible");
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

        public bool ResetFormColor()
        {
            BackGroundColor = Color.FromRgb(147, 199, 221);
            return false;
        }

        internal void AnswerSelected(int selected)
        {
            Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () => ResetFormColor());
            string correctAnswer = CardList[CurrentIndex].ImageName;
            switch (selected)
            {
                case 1:
                    if (FirstAnswer == correctAnswer)
                    {
                        multiSelectCorrect();
                    }
                    else
                    {
                        IVibrator vibrator = DependencyService.Get<IVibrator>();
                        vibrator.Vibrate(100);
                        BackGroundColor = Color.Red;
                        FirstAnswerVisible = false;
                    }
                    break;
                case 2:
                    if (SecondAnswer == correctAnswer)
                    {
                        multiSelectCorrect();
                    }
                    else
                    {
                        IVibrator vibrator = DependencyService.Get<IVibrator>();
                        vibrator.Vibrate(100);
                        BackGroundColor = Color.Red;
                        SecondAnswerVisible = false;
                    }
                    break;
                case 3:
                    if (ThirdAnswer == correctAnswer)
                    {
                        multiSelectCorrect();
                    }
                    else
                    {
                        IVibrator vibrator = DependencyService.Get<IVibrator>();
                        vibrator.Vibrate(100);
                        BackGroundColor = Color.Red;
                        ThirdAnswerVisible = false;
                    }
                    break;
                case 4:
                    if (ForthAnswer == correctAnswer)
                    {
                        multiSelectCorrect();
                    }
                    else
                    {
                        IVibrator vibrator = DependencyService.Get<IVibrator>();
                        vibrator.Vibrate(100);
                        BackGroundColor = Color.Red;
                        ForthAnswerVisible = false;
                    }
                    break;
            }
        }

        private void multiSelectCorrect()
        {
            switch (Convert.ToInt32(FirstAnswerVisible)+Convert.ToInt32(SecondAnswerVisible)+Convert.ToInt32(ThirdAnswerVisible)+Convert.ToInt32(ForthAnswerVisible))
            {
                case 4:
                    Points = Points + 10;
                    break;
                case 3:
                    Points = Points + 5;
                    break;
                case 2:
                    Points = Points + 1;
                    break;
            }
            FirstAnswerVisible = true;
            SecondAnswerVisible = true;
            ThirdAnswerVisible = true;
            ForthAnswerVisible = true;
            if (!EndOfList)
            {
                MoveNext();
            }
            else
            {
                if(DisplayScore!=null)
                {
                    DisplayScore(this, Points);
                }
                OnRequestClose();
            }
        }

        public string NoneString { get { return "None"; } }
        public event EventHandler<int> DisplayScore;

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
