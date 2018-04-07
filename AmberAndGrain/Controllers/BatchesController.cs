using AmberAndGrain.Models;
using AmberAndGrain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmberAndGrain.Controllers
{
    [RoutePrefix("api/batches")]
    public class BatchesController : ApiController
    {

        [Route, HttpPost]
        public HttpResponseMessage AddBatch(AddBatchDto addBatch)
        {
            var repository = new BatchRepository();
            var result = repository.Create(addBatch.RecipeId, addBatch.Cooker);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);

            };

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create batch");
        }

        [Route("{batchId}/mash"), HttpPatch]
        public HttpResponseMessage MashBatch(int batchId)
        {
            var batchMasher = new BatchMasher();
            var mashIt = batchMasher.MashBatch(batchId);

            switch (mashIt)
            {
                case UpdateStatusResults.NotFound:
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Batch not found");
                case UpdateStatusResults.Success:
                    return Request.CreateResponse(HttpStatusCode.OK);
                case UpdateStatusResults.Unsuccessful:
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "We suk");
                case UpdateStatusResults.ValidationFailure:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "U suk");
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Life suks");
            }
        }

    }
}
