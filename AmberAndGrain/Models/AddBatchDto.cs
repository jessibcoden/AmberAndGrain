using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Models
{
    public class AddBatchDto
    {
        public int RecipeId {get; set;}
        public string Cooker {get; set;}
        
    }

    //enum Status { Distil, Mash, Barrell, Taste, Bottle };

    //static void Main()
    //{
    //    int x = (int)Day.Sun;
    //    int y = (int)Day.Fri;
    //    Console.WriteLine("Sun = {0}", x);
    //    Console.WriteLine("Fri = {0}", y);
    //}
}