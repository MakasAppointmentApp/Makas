using MakasUI.Models.DtosForCustomer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.ViewModels
{
    public class SaloonListViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ObservableCollection<GetSaloonsByLocationDto> _ListedSaloon;
        public ObservableCollection<GetSaloonsByLocationDto> ListedSaloon
        { get
            { return _ListedSaloon; } 
            set {
                if (_ListedSaloon != value)
                {
                    _ListedSaloon = value;
                    OnPropertyChanged();
                }
            } }
        public SaloonListViewModel()
        {
            ListedSaloon = new ObservableCollection<GetSaloonsByLocationDto>();
        }
        public async Task getItems(SearchSaloonsDto _searched)
        {
            _ListedSaloon.Clear();
            var response = await App.customerManager.ListSaloonsByLocationAsync(_searched);
            foreach (var item in response)
            {
                if (!ListedSaloon.Contains(item))
                {
                    ListedSaloon.Add(item);
                }

            }
        }
    }
}
