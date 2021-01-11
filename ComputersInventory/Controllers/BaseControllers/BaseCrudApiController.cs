using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersInventory.DAL.DomainModels;
using ComputersInventory.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputersInventory.Controllers.BaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCrudApiController<T> : ControllerBase where T : class
    {
        protected IBaseEntityCrudRepository<T> DataRepository;

        public BaseCrudApiController(IBaseEntityCrudRepository<T> dataRepository)

        {
            DataRepository = dataRepository;
        }

        [HttpGet]
        public virtual ActionResult<ResultSetDTO> Get(string orderBy = null, string orderDirection = null, int pageNumber = -1,
            int sizeOfPage = -1, string filterParams = null, string returnType = null)
        {
            ResultSetDTO dataSet;

            try
            {
                dataSet = DataRepository.Retrieve(orderBy, orderDirection, pageNumber, sizeOfPage, filterParams);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(dataSet);

        }

        [HttpDelete]
        public async Task<object> Delete([FromBody] T record)
        {
            int response;

            try
            {
                response = await DataRepository.Delete(record);
            }
            catch (Exception ex)
            {
                var exceptionMessage = "An Error has occured during the deletion of this record: " + ex.Message + " " +
                                       ex.InnerException;
                return BadRequest(exceptionMessage);
            }

            return response;
        }

        [HttpPut]

        public async Task<object> Put(T record)
        {
            int response;

            try
            {
                response = await DataRepository.Create(record);
            }
            catch (Exception ex)
            {
                var exceptionMessage = "An Error has occured during the insertion of this record: " + ex.Message + " " +
                                       ex.InnerException;
                return BadRequest(exceptionMessage);
            }

            return response;
        }

        [HttpPatch]
        public virtual async Task<object> Patch(T record)
        {
            T response;
            try
            {
                response = await DataRepository.Update(record);
            }
            catch (Exception ex)
            {
                var exceptionMessage = "An Error has occured during the updating of this record: " + ex.Message + " " +
                                       ex.InnerException;
                return BadRequest(exceptionMessage);
            }

            return response;
        }
    }
}
