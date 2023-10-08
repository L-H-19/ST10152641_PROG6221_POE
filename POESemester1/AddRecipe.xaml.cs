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
using System.Windows.Shapes;

namespace POESemester1
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        //this stores the collection recipes in the app class , this is just instatianting again
        public ObservableCollection<recipeClass> recipes = new ObservableCollection<recipeClass>();
        public AddRecipe()
        {
            InitializeComponent();
            //this function is used to specify that this recipe implemented in this class
            this.recipes = recipes;
            
        }

        
        

        private void continueToIngredientsBTn_Click(object sender, RoutedEventArgs e)
        {
            
                recipeClass newRecipe = new recipeClass
                {
                    //takes inputs from xaml manipulation
                    recipeName = recipeName.Text,
                    numberOfIngredient = Convert.ToInt32(noIngredients.Text),
                    numberOfSteps = Convert.ToInt32(noSteps.Text)
                };
                ((App)Application.Current).recipes.Add(newRecipe);

            //a new object addIngredient is created so it can be used to 'show addingredint page once clicked on the button
            //new redipe is passesd as a paramenter through so that the application knows that we still working with the same redipe
            //thats being stored in the observable collection
                AddIngredient ob = new AddIngredient(newRecipe);
                ob.Show();
                this.Close();
            }
        
    }
}
