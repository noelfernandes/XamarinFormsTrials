using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Acr.UserDialogs;
using ListViewEventBubbles.Models;
using Xamarin.Forms;

namespace ListViewEventBubbles.ViewModels
{
    public class BanksViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Models.Bank> banks;
        public ObservableCollection<Models.Bank> Banks
        {
            get { return banks; }
            set
            {
                if (banks != value)
                {
                    banks = value;
                    OnPropertyChanged("Banks");
                }
            }
        }

        private Models.Bank selectedBank;
        public Models.Bank SelectedBank
        {
            get { return selectedBank; }
            set { selectedBank = value; }
        }


        public ICommand DetailsCommand { get; private set; }

        public BanksViewModel()
        {
            Banks = new ObservableCollection<Models.Bank>(Models.Bank.Dummy());
            DetailsCommand = new Command<Models.Transaction>(ShowDetails);
        }

        private void ShowDetails(Models.Transaction trx)
        {
            var tx = trx;
            UserDialogs.Instance.Alert($"Type: {trx.Title} | Amount: {trx.Value}", "Trx Data", "Ok");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
