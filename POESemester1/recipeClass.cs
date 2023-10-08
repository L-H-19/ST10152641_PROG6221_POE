using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POESemester1
{
    public class recipeClass
    {
        public string recipeName { get; set; }
        public int numberOfIngredient { get; set; }
        public int numberOfSteps { get; set; }

        public ObservableCollection<stepClass> steps { get; set; } = new ObservableCollection<stepClass>();
        public ObservableCollection<addIngreidientClass> addIngredientClasses { get; set; } = new ObservableCollection<addIngreidientClass>();
    }
}
