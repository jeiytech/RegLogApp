using System;
using System.IO;
using RegLogApp.Tables;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLogApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {

                UserName = EntryUserName.Text,
                UserEmail = EntryUserEmail.Text,
                UserPhoneNumber = EntryUserPhoneNumber.Text,
                UserPassword = EntryUserPassword.Text
            };

            db.Insert(item);
            db.Close();

            if (item.UserName != null && item.UserEmail != null && item.UserPhoneNumber != null && item.UserPassword != null)
            {
                if (EntryUserPassword.Text == EntryConfirmUserPassword.Text)
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        var result = await this.DisplayAlert("Success!", "Registered Succesfully", "OK", "Login");

                        if (result)
                            await Shell.Current.GoToAsync(state: "//login");
                        else
                            await Shell.Current.GoToAsync(state: "//login");
                    });
                }
                else
                {
                    await this.DisplayAlert("ERROR!", "Passwords do not match", "OK");
                }
            }
            else
            {
                await this.DisplayAlert("ERROR!", "FORM CANNOT BE EMPTY", "OK");
            }
        }
    }
}