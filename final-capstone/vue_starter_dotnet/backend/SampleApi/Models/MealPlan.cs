using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class MealPlan
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public User User { get; set; }
        public int MealSlot { get; set; }
        public DateTime MealDate { get; set; }

        public MealPlan() { }
    }
}
