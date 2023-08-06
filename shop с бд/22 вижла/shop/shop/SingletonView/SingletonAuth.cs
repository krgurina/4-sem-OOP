using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.ViewModels;

namespace shop.SingletonView
{
    class SingletonAuth
    {
        private static SingletonAuth instance;
        public LoginViewModel StartViewModel { get; set; }
        private SingletonAuth(LoginViewModel authView)
        {
            StartViewModel = authView;
        }
        public static SingletonAuth getInstance(LoginViewModel startViewModel = null)
        {
            return instance ?? (instance = new SingletonAuth(startViewModel));
        }
    }
}
