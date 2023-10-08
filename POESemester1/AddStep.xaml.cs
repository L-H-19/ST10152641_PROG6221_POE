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
    /// Interaction logic for AddStep.xaml
    /// </summary>
    public partial class AddStep : Window
    {
        int Count = 1;
        private recipeClass recipe;
        public AddStep(recipeClass recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            stepNumber.Content = "Step number: "+Count.ToString();
        }

        private void captureStepButton_Click(object sender, RoutedEventArgs e)
        {
            double result;
            //the following line of code just checks if theres nothing enrter or the wrong data type is entered an error will be entered
            if (description.Text.Length <1)
            {
                MessageBox.Show("discription must be  inputted", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Count <= recipe.numberOfSteps) 
            {
                stepClass newStep = new stepClass
                {
                    stepNumber = Count,
                    description = description.Text
                };
                recipe.steps.Add(newStep);
                MessageBox.Show("Step "+Count+"Description added");
                description.Clear();
                stepNumber.Content = "Step number: " + Count.ToString();
            }
            else 
            {
                MessageBox.Show("You have entered the max amount of steps continue to step dashboard ");
            }
        }

        private void dashboardButton_Click(object sender, RoutedEventArgs e)
        {

            RecipeDashboard dashboard = new RecipeDashboard();
            dashboard.Show();
            this.Close();
        }

        private void addRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe();
            addRecipe.Show();
            this.Close();
        }
    }
}
