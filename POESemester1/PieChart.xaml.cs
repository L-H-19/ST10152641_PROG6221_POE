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
    /// Interaction logic for PieChart.xaml
    /// </summary>
    public partial class PieChart : Window
    {
        public PieChart()
        {
            InitializeComponent();
            ListRecipe.ItemsSource = ((App)Application.Current).recipes;

        }

        private void LoadMenuChartBtn_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected recipes from the ListView
            var selectedRecipes = ListRecipe.SelectedItems.Cast<recipeClass>();

            // Extract food group data from the selected recipes and create data for the pie chart
            List<FoodGroupData> foodGroupDataList = new List<FoodGroupData>();

            foreach (var recipe in selectedRecipes)
            {
                foreach (var ingredient in recipe.addIngredientClasses)
                {
                    string foodGroup = ingredient.foodGroup;

                    // Check if the food group already exists in the list
                    var existingFoodGroupData = foodGroupDataList.FirstOrDefault(data => data.FoodGroup == foodGroup);

                    if (existingFoodGroupData != null)
                    {
                        // Increment the count for the existing food group
                        existingFoodGroupData.Count++;
                    }
                    else
                    {
                        // Create a new entry for the food group
                        foodGroupDataList.Add(new FoodGroupData { FoodGroup = foodGroup, Count = 1 });
                    }
                }
            }

            // Bind the generated data to the PieSeries
            MenuChart.ItemsSource = foodGroupDataList;
        }
        public class FoodGroupData
        {
            public string FoodGroup { get; set; }
            public int Count { get; set; }
        }
    }
}
