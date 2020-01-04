using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model
{
    public class AllProduct
    {
        public List<Category> categories { get; set; }
        public List<Food> sides { get; set; }
        public List<Food> suggets
        {
            set
            {
                suggets = value;
            }
            get
            {
                List<Food> foods = new List<Food>();
                foreach (Category c in categories)
                {
                    foreach (Food f in c.foods)
                    {
                        if (f.is_suggest == 1)
                        {
                            foods.Add(f);
                        }
                    }
                }

                return foods;
            }
        }


        public AllProduct()
        {
            categories = new List<Category>();
            sides = new List<Food>();
        }
    }
}
