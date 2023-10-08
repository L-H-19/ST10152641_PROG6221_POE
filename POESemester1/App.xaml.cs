using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace POESemester1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //this is where you store recipes so can use it throughout application
        public ObservableCollection<recipeClass> recipes { get; set; } = new ObservableCollection<recipeClass>();
        //this overide will execute the start up of the application
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
