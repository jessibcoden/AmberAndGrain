using AmberAndGrain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AmberAndGrain.Services
{
    public class BatchMasher
    {
        public UpdateStatusResults MashBatch(int batchId)
        {
            var respository = new BatchRepository();
            Batch batch;

            try
            {
                batch = respository.Get(batchId);
            }
            catch (SqlException)
            {
                return UpdateStatusResults.Unsuccessful;
            }
            catch (Exception ex)
            {
                return UpdateStatusResults.NotFound;
            }

            if (batch.Status != BatchStatus.Created)
            {
                return UpdateStatusResults.ValidationFailure;
            }

            batch.Status = BatchStatus.Mashed;
            var result = respository.Update(batch);
            return result
                ? UpdateStatusResults.Success
                : UpdateStatusResults.Unsuccessful;
        }
    }
}