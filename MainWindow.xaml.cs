﻿using LabSheet1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labsheet1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Band> allBands = new List<Band>();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //populate combo box

            string[] genres = { "All", "Rock", "Pop", "Indie" };
            cbxGenre.ItemsSource = genres;


            RockBand b1 = new RockBand() { BandName = "The Foo Fighters", YearFormed = 1994, Members = "Dave Grohl, Nate Mendel, Pat Smear, Taylor Hawkins, Chris Shifflett, Rami Jafee" };
            RockBand b2 = new RockBand() { BandName = "The Rolling Stones", YearFormed = 1962, Members = "Mick Jagger, Ian Stewart, Dick Taylor, Bill Wyman, Mick Taylor" };

            PopBand b3 = new PopBand() { BandName = "The Beatles", YearFormed = 1960, Members = "John Lennon, Paul McCartney, George Harrison, Ringo Starr" };
            PopBand b4 = new PopBand() { BandName = "Green Day", YearFormed = 1986, Members = "Billie Joe Armstrong, Mike Dirnt, Tre Cool" };

            IndieBand b5 = new IndieBand() { BandName = "Arctic Monkeys", YearFormed = 2002, Members = "Alex Turner, Matt Heldens, Jamie Cook, Nick O'Malley" };
            IndieBand b6 = new IndieBand() { BandName = "The Strokes", YearFormed = 1998, Members = "Julian Casablancas, Nick Valensi, Albert Hammond Jr, Nikolai Fraiture, Fabrizio Moretti" };

            //Create Albums
            Random rand = new Random();
            
            //Foo Fighters
            Album a1 = new Album("Greatest Hits", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            Album a2 = new Album("One by One", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            
            //Rolling Stones
            Album a3 = new Album("Beggars Banquet", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            Album a4 = new Album("Blue & Lonesome", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            
            //The Beatles
            Album a5 = new Album("Let it Be", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            Album a6 = new Album("Sgt. Pepper's Lonely Heart Club Band", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            
            //Green Day
            Album a7 = new Album("Dookie", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            Album a8 = new Album("American Idiot", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            
            //Arctic Monkeys
            Album a9 = new Album("Whatever People Say I am, That's what I'm not", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            Album a10 = new Album("Favourite Worst Nightmare", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            
            //The Strokes
            Album a11 = new Album("Room on Fire", rand.Next(1960, 2020), rand.Next(1000000, 10000000));
            Album a12 = new Album("The Modern Age", rand.Next(1960, 2020), rand.Next(1000000, 10000000));

            //Add Albums

            b1.AlbumList.Add(a1);
            b1.AlbumList.Add(a2);

            b2.AlbumList.Add(a3);
            b2.AlbumList.Add(a4);

            b3.AlbumList.Add(a5);
            b3.AlbumList.Add(a6);

            b4.AlbumList.Add(a7);
            b4.AlbumList.Add(a8);

            b5.AlbumList.Add(a9);
            b5.AlbumList.Add(a10);

            b6.AlbumList.Add(a11);
            b6.AlbumList.Add(a12);


            //Add to collection
            allBands.Add(b1);
            allBands.Add(b2);
            allBands.Add(b3);
            allBands.Add(b4);
            allBands.Add(b5);
            allBands.Add(b6);

            //sort bands
            allBands.Sort();

            lbxBands.ItemsSource = allBands;
        }

        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selectedBand = lbxBands.SelectedItem as Band;

            if (selectedBand != null )
            {
                lbxAlbums.ItemsSource = selectedBand.AlbumList;

                tblkBandInfo.Text = string.Format($"Formed in{selectedBand.YearFormed}" +
                    $"\nMembers: {selectedBand.Members}");
            }
        }

        private void cbxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGenre = cbxGenre.SelectedItem as string;

            List<Band> filteredList = new List<Band>();

            switch(selectedGenre)
            {
                case "All":
                    lbxBands.ItemsSource = allBands;
                    break;

                case "Rock":

                    foreach (Band band in allBands)
                    {
                        if (band is RockBand)
                            filteredList.Add(band);
                    }
                    lbxBands.ItemsSource = filteredList;
                    break;
                case "Pop":

                    foreach (Band band in allBands)
                    {
                        if (band is PopBand)
                            filteredList.Add(band);
                    }
                    lbxBands.ItemsSource = filteredList;
                    break;

                case "Indie":

                    foreach (Band band in allBands)
                    {
                        if (band is IndieBand)
                            filteredList.Add(band);
                    }
                    lbxBands.ItemsSource = filteredList;
                    break;


            }
        }
    }
}
