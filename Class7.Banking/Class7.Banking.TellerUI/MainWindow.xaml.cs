using Class7.Banking.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Class7.Banking.TellerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<BankAccount> _accounts = new ObservableCollection<BankAccount>();


        public MainWindow()
        {
            InitializeComponent();

            this.AccountTypeCombo.ItemsSource = new List<string> { "Credit", "Current" };
            this.AccountTypeCombo.SelectedItem = "Current";

            this.AccountsList.ItemsSource = _accounts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedAccount = (string)AccountTypeCombo.SelectedItem;
            if (selectedAccount == "Current")
            {
                BankAccount acc = new CurrentBankAccount(this.CurrerncyTxt.Text);
                _accounts.Add(acc);
                //this.AccountsList.ItemsSource = _accounts;
            }

            else if (selectedAccount == "Credit")
            {
                BankAccount acc = new CreditBankAccount(this.CurrerncyTxt.Text, int.Parse(LimitTxt.Text));
                _accounts.Add(acc);
                //this.AccountsList.ItemsSource = _accounts;
            }
        }

        private void AccountTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isCredit = (string)AccountTypeCombo.SelectedItem == "Credit";
            this.LimitLabel.Visibility = isCredit ? Visibility.Visible : Visibility.Hidden;
            this.LimitTxt.Visibility = isCredit ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
