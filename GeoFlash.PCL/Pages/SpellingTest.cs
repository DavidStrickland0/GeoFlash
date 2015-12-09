using GeoFlash.Library.Model;
using GeoFlash.Library.Pages;
using GeoFlash.PCL.DependencyServices;
using GeoFlash.PCL.Localization;
using GeoFlash.PCL.Pages;
using GeoFlash.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace GeoFlash.Pages
{
    public class SpellingTest : ContentPage, ICloseablePage
    {
        IVibrator vibrator;

        public SpellingTest(IFlashCardData flashCardData)
        {
            this.BindingContext = new SpellCheckViewModel(false);

            vibrator = DependencyService.Get<IVibrator>();

            var myContentGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowSpacing = 0,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.FromRgb(147, 199, 221),
                ColumnDefinitions =
						{
                           
                            new ColumnDefinition{Width=new GridLength(10,GridUnitType.Star)}
                        },
                RowDefinitions =
                        {
							new RowDefinition{Height=new GridLength(70,GridUnitType.Star)},
							new RowDefinition{Height=new GridLength(10,GridUnitType.Star)},
							new RowDefinition{Height=new GridLength(10,GridUnitType.Star)},
							new RowDefinition{Height=new GridLength(10,GridUnitType.Star)}
                        }
            };
            myContentGrid.SetBinding<MultipleChoiceStateViewModel>(Grid.BackgroundColorProperty, (vm) => vm.BackGroundColor);

            var instructionLabel = new Label() { Text = "Type the state's name exactly as it was presented in the review:" };
            instructionLabel.TextColor = Color.Black;

            Assembly flashCardAssembly = flashCardData.GetType().GetTypeInfo().Assembly;
            var imagePicture = new Image();
            ImageSource imageSource = ImageSource.FromResource(string.Format("{0}{1}", "GeoFlash.", ((SpellCheckViewModel)this.BindingContext).ImagePath), flashCardAssembly);
            imagePicture.Source = imageSource;

            ((INotifyPropertyChanged)this.BindingContext).PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "ImagePath")
                {
                    string resourceName = string.Format("{0}{1}", "GeoFlash.", ((SpellCheckViewModel)this.BindingContext).ImagePath);
                    imagePicture.Source = ImageSource.FromResource(resourceName, flashCardAssembly);
                }
            };

            var stackLayoutCounter = new StackLayout();
            stackLayoutCounter.Orientation = StackOrientation.Horizontal;
            stackLayoutCounter.HorizontalOptions = LayoutOptions.EndAndExpand;

            var totalLabel = new Label();
            totalLabel.SetBinding<GeoFlashViewModel>(Label.TextProperty, (vm) => vm.TotalQuestionCount);
            totalLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            totalLabel.FontAttributes = FontAttributes.Bold;
            totalLabel.TextColor = Color.Black;
            
            var slashLabel = new Label() { Text = "/" };
            slashLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            slashLabel.FontAttributes = FontAttributes.Bold;
            slashLabel.TextColor = Color.Black;

            var currentIndexLabel = new Label();
            currentIndexLabel.SetBinding<SpellCheckViewModel>(Label.TextProperty, (vm) => vm.CurrentIndex, BindingMode.OneWay, new ZeroBasedToOneBased());
            currentIndexLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            currentIndexLabel.FontAttributes = FontAttributes.Bold;
            currentIndexLabel.TextColor = Color.Black;

            stackLayoutCounter.Children.Add(currentIndexLabel);
            stackLayoutCounter.Children.Add(slashLabel);
            stackLayoutCounter.Children.Add(totalLabel);


            var entryBox = new Entry();
            entryBox.SetBinding<SpellCheckViewModel>(Entry.PlaceholderProperty, (vm) => vm.HintText);

            var checkButton = new Button();
            checkButton.Text = "Submit";
            checkButton.Clicked += (s, e) =>
                {
                    SpellCheckViewModel vm = ((SpellCheckViewModel)this.BindingContext);
                    vm.CheckSpelling(entryBox.Text);
                    entryBox.Text = null;
                };

            var pointsStackLayout = new StackLayout();
            pointsStackLayout.Orientation = StackOrientation.Horizontal;
            var pointsLabel = new Label { Text = AppResources._Points };
            pointsLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            pointsLabel.FontAttributes = FontAttributes.Bold;
            pointsLabel.TextColor = Color.Black;

            var pointsDisplayValue = new Label();
            pointsDisplayValue.SetBinding<SpellCheckViewModel>(Label.TextProperty, (vm) => vm.Points, BindingMode.OneWay, new ToStringConvertor());
            pointsDisplayValue.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            pointsDisplayValue.FontAttributes = FontAttributes.Bold;
            pointsDisplayValue.TextColor = Color.Black;

            pointsStackLayout.Children.Add(pointsLabel);
            pointsStackLayout.Children.Add(pointsDisplayValue);
            
            
            myContentGrid.Children.Add(imagePicture, 0, 0);
            myContentGrid.Children.Add(pointsStackLayout, 0, 0);
            myContentGrid.Children.Add(stackLayoutCounter, 0, 0);
            myContentGrid.Children.Add(instructionLabel, 0, 1);
            myContentGrid.Children.Add(entryBox, 0, 2);
            myContentGrid.Children.Add(checkButton, 0, 3);
            var contentStackLayout = new StackLayout
            {
                Children = 
                {
					myContentGrid
				}
            };

            Image tlImage = new Image() { Source = ImageSource.FromResource(ImageConstants.tl) };
            Image tImage = new Image() { Source = ImageSource.FromResource(ImageConstants.t) };
            Image trImage = new Image() { Source = ImageSource.FromResource(ImageConstants.tr) };
            Image lImage = new Image() { Source = ImageSource.FromResource(ImageConstants.l) };
            Image rImage = new Image() { Source = ImageSource.FromResource(ImageConstants.r) };
            Image blImage = new Image() { Source = ImageSource.FromResource(ImageConstants.bl) };
            Image bImage = new Image() { Source = ImageSource.FromResource(ImageConstants.b) };
            Image brImage = new Image() { Source = ImageSource.FromResource(ImageConstants.br) };

            Grid borderLayoutGrid = new Grid()
            {
                BackgroundColor = Color.FromRgb(147, 199, 221),
                ColumnDefinitions = 
                {
                    new ColumnDefinition{Width=new GridLength(10,GridUnitType.Absolute)},
                    new ColumnDefinition{Width=new GridLength(100,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(10,GridUnitType.Absolute)}
                },
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(10,GridUnitType.Absolute)},
                    new RowDefinition{Height=new GridLength(100,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(10,GridUnitType.Absolute)}
                }
            };

            tImage.HorizontalOptions = LayoutOptions.FillAndExpand;
            tImage.Aspect = Aspect.Fill;

            bImage.HorizontalOptions = LayoutOptions.FillAndExpand;
            bImage.Aspect = Aspect.Fill;

            lImage.HorizontalOptions = LayoutOptions.FillAndExpand;
            lImage.Aspect = Aspect.Fill;

            rImage.HorizontalOptions = LayoutOptions.FillAndExpand;
            rImage.Aspect = Aspect.Fill;


            borderLayoutGrid.Children.Add(tlImage, 0, 0);
            borderLayoutGrid.Children.Add(tImage, 1, 0);
            borderLayoutGrid.Children.Add(trImage, 2, 0);
            borderLayoutGrid.Children.Add(lImage, 0, 1);
            borderLayoutGrid.Children.Add(rImage, 2, 1);
            borderLayoutGrid.Children.Add(blImage, 0, 2);
            borderLayoutGrid.Children.Add(bImage, 1, 2);
            borderLayoutGrid.Children.Add(brImage, 2, 2);

            borderLayoutGrid.RowSpacing = 0;
            borderLayoutGrid.ColumnSpacing = 0;

            borderLayoutGrid.Children.Add(contentStackLayout, 1, 1);

            Content = borderLayoutGrid;


            ((SpellCheckViewModel)this.BindingContext).RequestClose += (s, e) => { OnRequestClose(); };
            ((SpellCheckViewModel)this.BindingContext).DisplayScore += (s, e) => { DisplayAlert(AppResources._Complete, e.ToString(), AppResources._Ok); };
        }
        protected override bool OnBackButtonPressed()
        {
            if (!((SpellCheckViewModel)this.BindingContext).EndOfList && ((SpellCheckViewModel)this.BindingContext).Points > 0)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    string confirm = AppResources._Confirm;
                    string closeQuiz = AppResources._CloseQuiz;
                    string yesOption = AppResources._Yes;
                    string noOption = AppResources._No;


                    var result = await this.DisplayAlert(confirm, closeQuiz, yesOption, noOption);
                    if (result)
                    {
                        this.OnRequestClose();
                    }
                });
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            if (RequestClose != null)
            {
                RequestClose(this, new EventArgs());
            }
        }
    }
}
