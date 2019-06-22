using System;
using System.Collections.Generic;
using System.Text;


namespace App.ViewModels
{
    using Models;
    public class MainViewModel
    {
        #region Properties
        public TokenResponse Token
        {
            get; set;
        }

        #endregion

        #region ViewModels
        public NombresViewModel Login
        {
            get; set;
        }
        public NombresViewModel Lands
        {
            get; set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new NombresViewModel();

        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();

            }
            return instance;
        }

        #endregion
    }
}
