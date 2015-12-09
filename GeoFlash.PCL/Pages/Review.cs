using GeoFlash.Library.Model;
using GeoFlash.Library.Pages;
using GeoFlash.PCL.Localization;
using GeoFlash.PCL.Pages;
using GeoFlash.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using Xamarin.Forms;

namespace GeoFlash.Pages
{
    public class Review : ContentPage, ICloseablePage
    {
        public Review(IFlashCardData flashCardData)
        {
            this.BindingContext = new GeoFlashViewModel(true);

            var myContentGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions=LayoutOptions.FillAndExpand,
                RowSpacing = 0,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.FromRgb(147, 199, 221),
                ColumnDefinitions =
						{
                            new ColumnDefinition{Width=new GridLength(10,GridUnitType.Star)},
                            new ColumnDefinition{Width=new GridLength(80,GridUnitType.Star)},
                            new ColumnDefinition{Width=new GridLength(10,GridUnitType.Star)}
                        },
                RowDefinitions =
                        {
							new RowDefinition{Height=new GridLength(70,GridUnitType.Star)},
							new RowDefinition{Height=new GridLength(15,GridUnitType.Star)},
							new RowDefinition{Height=new GridLength(15,GridUnitType.Star)}
                        }
             };

            var imagePicture = new Image();

            Type boundType = this.BindingContext.GetType();
            Assembly flashCardAssembly = flashCardData.GetType().GetTypeInfo().Assembly;

            string imagePath = ((GeoFlashViewModel)this.BindingContext).ImagePath;

            ImageSource imageSource = ImageSource.FromResource(string.Format("{0}{1}", "GeoFlash.", ((GeoFlashViewModel)this.BindingContext).ImagePath), flashCardAssembly);
            imagePicture.Source = imageSource;




            var tgr = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };

            var pictureLabel = new Label();
            pictureLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            pictureLabel.IsVisible = false;
            pictureLabel.TextColor = Color.Black;

            var capitolLabel = new Label();
            capitolLabel.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            capitolLabel.IsVisible = false;
            capitolLabel.TextColor = Color.Black;


            var stackLayoutCounter = new StackLayout();
            stackLayoutCounter.Orientation=StackOrientation.Horizontal ;
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
            currentIndexLabel.SetBinding<GeoFlashViewModel>(Label.TextProperty, (vm) => vm.CurrentIndex, BindingMode.OneWay, new ZeroBasedToOneBased());
            currentIndexLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            currentIndexLabel.FontAttributes = FontAttributes.Bold;
            currentIndexLabel.TextColor = Color.Black;

            stackLayoutCounter.Children.Add(currentIndexLabel);
            stackLayoutCounter.Children.Add(slashLabel);
            stackLayoutCounter.Children.Add(totalLabel);

            tgr.Tapped += (s, e) =>
            {
                pictureLabel.IsVisible = true;
                capitolLabel.IsVisible = true;
            };
            imagePicture.GestureRecognizers.Add(tgr);

            pictureLabel.HorizontalOptions = LayoutOptions.StartAndExpand;

            pictureLabel.Text = ((GeoFlashViewModel)this.BindingContext).ImageTitle;

            capitolLabel.Text = string.Format("{0}:{1}",AppResources._Capitol, ((GeoFlashViewModel)this.BindingContext).ImageCapitol);

            ((INotifyPropertyChanged)this.BindingContext).PropertyChanged += (s, e) =>
            {
                switch(e.PropertyName)
                {
                    case "ImagePath":
                        string resourceName = string.Format("{0}{1}", "GeoFlash.", ((GeoFlashViewModel)this.BindingContext).ImagePath);
                        imagePicture.Source = ImageSource.FromResource(resourceName,flashCardAssembly);
                        break;
                    case "ImageTitle":
                        pictureLabel.Text = ((GeoFlashViewModel)this.BindingContext).ImageTitle;
                        break;
                    case "ImageCapitol":
                        capitolLabel.Text = string.Format("{0}:{1}", AppResources._Capitol, ((GeoFlashViewModel)this.BindingContext).ImageCapitol);
                        break;
                }
            };



            var prevButton = new Button(){Text="<"};
                prevButton.Clicked+=(s,e)=>{
                    pictureLabel.IsVisible = false;
                    capitolLabel.IsVisible = false;
                    ((GeoFlashViewModel)this.BindingContext).MovePrevious();
                };
                prevButton.SetBinding<GeoFlashViewModel>(Button.IsEnabledProperty, (vm)=>vm.StartOfList, BindingMode.OneWay, new BooleanInvertor());
            var nextButton = new Button(){Text=">"};
                nextButton.Clicked+=(s,e)=>{
                    pictureLabel.IsVisible = false;
                    capitolLabel.IsVisible = false;
                    ((GeoFlashViewModel)this.BindingContext).MoveNext();
                };
                nextButton.SetBinding<GeoFlashViewModel>(Button.IsEnabledProperty, (vm) => vm.EndOfList, BindingMode.OneWay, new BooleanInvertor());
 
            myContentGrid.Children.Add(imagePicture, 0, 0);
            myContentGrid.Children.Add(stackLayoutCounter,0,0);

            Grid.SetColumnSpan(imagePicture,3);
            Grid.SetColumnSpan(stackLayoutCounter, 3);

            myContentGrid.Children.Add(prevButton, 0, 1);
            Grid.SetRowSpan(prevButton, 2);


            BoxView boxView = new BoxView() { BackgroundColor = Color.White };
            boxView.HorizontalOptions = LayoutOptions.FillAndExpand;
            boxView.VerticalOptions = LayoutOptions.FillAndExpand;

            myContentGrid.Children.Add(boxView, 1, 1);
            Grid.SetRowSpan(boxView, 2);
            
            myContentGrid.Children.Add(pictureLabel, 1, 1);
            myContentGrid.Children.Add(capitolLabel, 1, 2);


            myContentGrid.Children.Add(nextButton, 2, 1);
            Grid.SetRowSpan(nextButton, 2);
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
