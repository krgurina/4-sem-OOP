using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.ViewModels.Admin;
namespace shop.SingletonView
{
    class SingletonAdmin
    {
        private static SingletonAdmin instance;
        public AdminViewModel StartViewModel { get; set; }
        public object AdminViewModel { get; internal set; }

        private SingletonAdmin(AdminViewModel startView)
        {
            StartViewModel = startView;
        }
        public static SingletonAdmin getInstance(AdminViewModel startViewModel = null)
        {
            return instance ?? (instance = new SingletonAdmin(startViewModel));
        }
    }
}
