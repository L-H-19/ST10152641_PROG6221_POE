using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace POESemester1
{
    /// <summary>
    /// Interaction logic for RecipeDashboard.xaml
    /// </summary>
    public partial class RecipeDashboard : Window
    {
        public RecipeDashboard()
        {
            InitializeComponent();
            //seting the recipe list item source to the list of recipes
            ListRecipe.ItemsSource = ((App)Application.Current).recipes;
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe add = new AddRecipe();
            add.Show();
            this.Close();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            //Retrieve the selected recipe
            if (ListRecipe.SelectedItem is recipeClass selectedRecipe) 
            {
                ListIngredient.ItemsSource = selectedRecipe.addIngredientClasses; 
                ListStep.ItemsSource = (selectedRecipe.steps);
            }
        }

        private void pieChart_Click(object sender, RoutedEventArgs e)
        {
            PieChart p = new PieChart();
            p.Show();
            this.Close();
        }
    }
}
