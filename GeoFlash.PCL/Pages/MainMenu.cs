using GeoFlash.Library.Model;
using GeoFlash.Library.Pages;
using GeoFlash.PCL;
using GeoFlash.PCL.Localization;
using GeoFlash.PCL.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GeoFlash.Pages
{
    public class MainMenu : ContentPage
    {
        public void LoadToModalStack(ICloseablePage page)
        {
            if (this.Navigation.ModalStack.Count == 1)
            {
                page.RequestClose += (s, e) =>
                {
                    this.Navigation.PopModalAsync();
                };

                this.Navigation.PushModalAsync((ContentPage)page, true);
            }
        }
        public MainMenu(IFlashCardData flashCardData)
        {

            var selectPicker = new Picker()
            {
                BackgroundColor = Color.FromRgb(239, 146, 7),
            };
            foreach(string catagory in flashCardData.FlashCardCatagories)
            {
                selectPicker.Items.Add(AppResources.ResourceManager.GetString(catagory));
            }

            if(selectPicker.Items.Count==1)
            {
                selectPicker.IsVisible = false;
            }

            selectPicker.SelectedIndex = 0;

            var reviewButton = new Button(){ Text = AppResources._Review,
            BackgroundColor=Color.FromRgb(239,146,7)};

            reviewButton.Command = new Command((parameter) =>
            {
                flashCardData.CreateFlashCards(selectPicker.SelectedIndex);
                LoadToModalStack(new Review(flashCardData));
            });

            var easyButton = new Button()
            {
                Text = AppResources._Easy,
                BackgroundColor = Color.FromRgb(239, 146, 7)
            };
            easyButton.Command = new Command((parameter) =>
            {
                flashCardData.CreateFlashCards(selectPicker.SelectedIndex);
                LoadToModalStack(new MultipleChoiceState(flashCardData));
            });

            var stateButton = new Button()
            {
                Text = AppResources._MultiSelectCapitol,
                BackgroundColor = Color.FromRgb(239, 146, 7)
            };
            stateButton.Command = new Command((parameter) =>
            {
                flashCardData.CreateFlashCards(selectPicker.SelectedIndex);
                LoadToModalStack(new MultipleChoiceCapitol(flashCardData));
            });

            var hardButton = new Button()
            {
                Text = AppResources._Hard,
                BackgroundColor = Color.FromRgb(239, 146, 7)
            };
            hardButton.Command = new Command((parameter) =>
            {
                flashCardData.CreateFlashCards(selectPicker.SelectedIndex);
                LoadToModalStack(new SpellingTest(flashCardData));
            });

            var creditsButton = new Button()
            {
                Text = AppResources._Credits,
                BackgroundColor = Color.FromRgb(239, 146, 7)
            };
            creditsButton.Command = new Command((parameter) =>
            {
                flashCardData.CreateFlashCards(selectPicker.SelectedIndex);
                LoadToModalStack(new Credits(flashCardData));
            });
            Image tlImage = new Image() { Source = ImageSource.FromResource(ImageConstants.tl) };
            Image tImage = new Image() { Source =  ImageSource.FromResource(ImageConstants.t) };
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

            var contentGrid = new Grid()
            {
                RowDefinitions =
                    {
                        new RowDefinition{Height=new GridLength(1,GridUnitType.Auto)},
                        new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(4,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(4,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(4,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(4,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(4,GridUnitType.Star)},
                        new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                    }
            };

            contentGrid.Children.Add(selectPicker, 0, 0); 
            contentGrid.Children.Add(reviewButton, 0, 2);
            contentGrid.Children.Add(easyButton,0,4);
            contentGrid.Children.Add(stateButton,0,6);
            contentGrid.Children.Add(hardButton,0,8);
            contentGrid.Children.Add(creditsButton,0,10);

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

            borderLayoutGrid.Children.Add(contentGrid, 1, 1);

            Content = borderLayoutGrid;

        }
    }
}
