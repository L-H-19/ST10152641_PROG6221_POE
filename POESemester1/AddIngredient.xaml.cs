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
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        //count variable is initialized and set to zero to make sure that the amount of times the user entered in the recipe window
        //is repeated in this window and not more
        int Count = 0;
        //this is to repeat the process of carring the same index on through to the next window
        private recipeClass recipe;
        public AddIngredient(recipeClass recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            //this represents binding between user and userinterface
            DataContext = this.recipe;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //the following line of code just checks if theres nothing enrter or the wrong data type is entered an error will be entered
            double result;
            if (ingredientName.Text.Length < 1)
            {
                MessageBox.Show("Ingredient must be  inputted", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (unitOfMeasurement.Text.Length < 1)
            {
                MessageBox.Show("Unit of measurement must be  inputted", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (foodGroup.Text.Length < 1)
            {
                MessageBox.Show("Food group  must be  inputted", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!double.TryParse(calories.Text,out result)) 
            {
                MessageBox.Show("calories must be a double value", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!double.TryParse(quantity.Text, out result))
            {
                MessageBox.Show("quantities must be a double value", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //once the message box is finished display wrong input the user will be able entered 
            else if(double.TryParse(quantity.Text,out result) && (ingredientName.Text.Length >= 1) && (unitOfMeasurement.Text.Length >= 1)
                && (foodGroup.Text.Length >= 1) && (double.TryParse(calories.Text, out result))) 
            {
                //a loop structure when inputed in the wpf form data is reterieved to abw t be stored in observrible collection
                if (Count < recipe.numberOfIngredient)
                {

                    addIngreidientClass newIngredient = new addIngreidientClass
                    {
                        ingredientName = ingredientName.Text,
                        quantity = Convert.ToDouble(quantity.Text),
                        unitOfMesurement = unitOfMeasurement.Text,
                        calories = Convert.ToDouble(calories.Text),
                        foodGroup = foodGroup.Text,

                    };
                    recipe.addIngredientClasses.Add(newIngredient);
                    Count++;
                    MessageBox.Show(ingredientName.Text + "Ingredient added");
                    ingredientName.Clear();
                    quantity.Clear();
                    unitOfMeasurement.Clear();
                    calories.Clear();
                    foodGroup.Clear();


                }
                else
                {
                    MessageBox.Show("You have entered the max amount of ingredients continue to steps");
                }
            }

            
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            AddStep addStep = new AddStep(recipe);
            addStep.Show();
            this.Close();
        }
    }
}
