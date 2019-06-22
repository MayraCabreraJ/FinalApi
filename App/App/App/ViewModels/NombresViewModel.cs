using App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using App.ViewModels;


namespace App.ViewModels
{
    
    public class NombresViewModel : BaseViewModel
    {
        #region Services

        private ApiService apiService;
        #endregion


        #region Attributes

        private ObservableCollection<Nombres> nombre;
        private bool isRefreshing;
        #endregion


        #region Properties
        public ObservableCollection<Nombres> Names
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion



        #region Constructors

        public NombresViewModel()
        {
            this.apiService = new ApiService();
            this.LoadNames();
        }

        #endregion


        #region Methods
        private async void LoadNames()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                   "Error", connection.Message,
                   "Aceptar");
                return;
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            var response = await this.apiService.GetList<Nombres>(
                "http://webapifinal.azurewebsites.net",
                "/api",
                "/students");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", response.Message,
                    "Aceptar");
                return;
            }
            var list = (List<Nombres>)response.Result;
            this.Names = new ObservableCollection<Nombres>(list);
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadNames);

            }
        }
        #endregion
    }
}

