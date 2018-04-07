using AmberAndGrain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

//Repositories are a collection of methods that "do" things with the data, abstraction around your code and the source of data  **look up repository pattern and singleton pattern**

namespace AmberAndGrain.Services
{
    public class BatchRepository
    {
        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString);
        }

        public bool Create(int recipeId, string cooker)
        {
            using (var db = GetDb())
            {
                db.Open();

                var batchesCreated = db.Execute(@"INSERT INTO Batches (RecipeId, Cooker)
                                                 VALUES (@recipeId, @cooker)", new {recipeId, cooker});
                //new {recipeId, cooker} is an Annonomous Type - the order matters, should be in order that is passed into function

                return batchesCreated == 1;
            }
        }

        public Batch Get(int batchId)
        {
            using (var db = GetDb())
            {
                db.Open();
                var getSingleBatch = db.QueryFirst<Batch>(@"SELECT * FROM Batches WHERE Id = @batchId", new {
                    batchId});

                return getSingleBatch;
            }
        }

        public bool Update(Batch batch)
        {
            using (var db = GetDb())
            {
                db.Open();
                var result = db.Execute(@"UPDATE [dbo].[Batches]
                                           SET [DateBarrelled] = @DateBarrelled
                                              ,[NumberOfBarrels] = @NumberOfBarrels
                                              ,[DateBottled] = @DateBottled
                                              ,[NumberOfBottles] = @NumberOfBottles
                                              ,[Cooker] = @Cooker
                                              ,[PricePerBottle] = @PricePerBottle
                                              ,[NumberOfBottlesLeft] = @NumberOfBottlesLeft
                                              ,[Status] = @Status
                                         WHERE id = @id", batch);

                return result == 1;
            }
        }
 
    }
}