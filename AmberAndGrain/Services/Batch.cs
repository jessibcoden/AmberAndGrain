using AmberAndGrain.Models;
using System;

namespace AmberAndGrain.Services
{
    // **look up the difference between reference type and value type**
    //can make value types nullable you have to turn them into reference types
    //adding ? to the type makes it nullable - this is called "Boxing": wrapping up a value type into a reference type
    public class Batch
    {
        public int Id {get; set;}
        public int RecipeId {get; set;}
        public DateTime DateCreated {get; set;}
        public DateTime? DateBarrelled {get; set;}
        public int? NumberOfBarrels {get; set;}
        public DateTime? DateBottled {get; set;}
        public int? NumberOfBottles {get; set;}
        public string Cooker {get; set;}
        public double? PricePerBottle {get; set;}
        public BatchStatus Status {get; set;}
        public int? NumberOfBottlesLeft {get; set;}
    }
}