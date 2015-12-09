using GeoFlash.Library.Model;
using GeoFlash.Library.Pages;
using GeoFlash.PCL.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace GeoFlash.Pages
{
    public class Credits : ContentPage, ICloseablePage
    {


        public Credits(IFlashCardData flashCardData)
        {
            var LabelStyle = new Style(typeof(Label))
            {
                Setters = 
                    {
                        new Setter{Property=Label.TextColorProperty , Value=Color.Black }
                    }
            };
            ScrollView scrollView = new ScrollView()
            {
                Content = new StackLayout
                {

                    Children = {
					    new Label { 
                            Text = "GeoFlash-World",
                            Style= LabelStyle},
					    new Label { Text = "Developer: David Strickland", 
                            Style= LabelStyle},
					    new Label { Text = "Images: Own work - Created with Google GeoMap",
						    Style= LabelStyle},
						new Label { Text = "www.Indiponics.com",
							Style= LabelStyle}
						
//					    new Label { Text = "Images: CC-by-sa PlaneMad/Wikimedia- Own work",
//                            Style= LabelStyle},
//                        new Label { Text = "International Borders: University of Texas map library - India Political map 2001",
//                            Style= LabelStyle},
//                        new Label { Text = "Disputed Borders: University of Texas map library - China-India Borders - Eastern Sector 1988 & Western Sector 1988 - Kashmir Region 2004 - Kashmir Maps.",
//                            Style= LabelStyle},
//                        new Label { Text = "State and District boundaries: Census of India - 2001 Census State Maps - Survey of India Maps.",
//                            Style= LabelStyle},
//                        new Label { Text = "Other sources: US Army Map Service, Survey of India Map Explorer, Columbia University",
//                            Style= LabelStyle},
//                        new Label { Text = "Map specific sources: .. Licensed under CC BY-SA 3.0 via Commons",
//                            Style= LabelStyle}
                    }
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

            borderLayoutGrid.Children.Add(scrollView, 1, 1);

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
