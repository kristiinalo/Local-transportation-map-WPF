using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using static Local_transportation_map_WPF.Enums;

namespace Local_transportation_map_WPF
{

    public partial class MainWindow : Window
    {
        public List<ModelGPS> Models = new List<ModelGPS>();
        public string FilterValueLiin = "";
        public Transpordiliik transpordiliik = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Models = new Program().FillClass();

            DataGrid? grid = sender as DataGrid;
            grid.ItemsSource = Models;
        }
        private void FiltersChanged()
        {
            Models = new Program().FillClass();
            CollectionViewSource? _itemSourceList = new CollectionViewSource() { Source = Models };
            ICollectionView Itemlist = _itemSourceList.View;
            Predicate<object>? yourCostumFilter = new Predicate<object>(item => ((ModelGPS)item).LineNumber.Contains(FilterValueLiin) & ((ModelGPS)item).Liik.Equals(transpordiliik)   );
            Itemlist.Filter = yourCostumFilter;
            DataGrid? grid = GR;
            grid.ItemsSource = Itemlist.IsEmpty ? Models : Itemlist;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;            
            FilterValueLiin = tb.Text.ToUpper();

            FiltersChanged();
        }


        private void ComboLoaded(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            ComboBox cb = sender as ComboBox;
            cb.Items.Add("");
            foreach (var item in Enum.GetNames(typeof(Transpordiliik))) { 
                cb.Items.Add(item);
            }
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string tm = cb.SelectedItem.ToString();
            if (tm != "")
            {
                transpordiliik = (Transpordiliik)Enum.Parse(typeof(Transpordiliik), cb.SelectedItem.ToString());
            }
            else
            {
                transpordiliik = 0;
            }
            FiltersChanged();
        }
    }


}

