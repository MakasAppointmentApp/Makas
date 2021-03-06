using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MakasUI.ViewModels
{
    public class SaloonSearchViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<City> CitiesList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ObservableCollection<City> _myCity;
        public ObservableCollection<City> MyCity
        {
            get { return _myCity; }
            set
            {
                if (_myCity != value)
                {
                    _myCity = value;
                    OnPropertyChanged();
                }
            }
        }
        public SaloonSearchViewModel()
        {
            CitiesList = GetCities();
            MyCity = new ObservableCollection<City>();
        }
        public ObservableCollection<City> GetCities()
        {
            var cities = new ObservableCollection<City>()
            {
                new City(){Key =  1, Value= "Eskişehir"},
                new City(){Key =  2, Value= "Ankara"},
                new City(){Key =  3, Value= "İstanbul"},
                new City(){Key =  4, Value= "İzmir"},
                new City(){Key =  5, Value= "Bursa"},
                new City(){Key =  6, Value= "Antalya"},
            };

            return cities;
        }


        private City _selectedCity { get; set; }
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {

                _selectedCity = value;
                if (_selectedCity.Value.Equals("Eskişehir"))
                {
                    MyCity = new ObservableCollection<City>()
                        {
                            new City() { Key = 1, Value = "Tepebaşı" },
                            new City() { Key = 2, Value = "Odunpazarı" }
                        };
                }
                if (_selectedCity.Value.Equals("Ankara"))
                {
                    MyCity = new ObservableCollection<City>()
                        {
                            new City() { Key = 1, Value = "Kızılay" },
                            new City() { Key = 2, Value = "Etimesgut" }
                        };
                }
                if (_selectedCity.Value.Equals("İstanbul"))
                {
                    MyCity = new ObservableCollection<City>()
                        {
                            new City() { Key = 1, Value = "Kadıköy" },
                            new City() { Key = 2, Value = "Beşiktaş" }
                        };
                }
                if (_selectedCity.Value.Equals("İzmir"))
                {
                    MyCity = new ObservableCollection<City>()
                        {
                            new City() { Key = 1, Value = "Bornova" },
                            new City() { Key = 2, Value = "Karşıyaka" }
                        };
                }
                if (_selectedCity.Value.Equals("Bursa"))
                {
                    MyCity = new ObservableCollection<City>()
                        {
                            new City() { Key = 1, Value = "Nilüfer" },
                            new City() { Key = 2, Value = "Mustafakemalpaşa" }
                        };
                }
                if (_selectedCity.Value.Equals("Antalya"))
                {
                    MyCity = new ObservableCollection<City>()
                        {
                            new City() { Key = 1, Value = "Kaş" },
                            new City() { Key = 2, Value = "Alanya" }
                        };
                }

            }
        }

    }
    public class City
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}

