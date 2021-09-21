using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactDetails.StaticStuff;
using ContactDetails.BL;
using ContactDetails.BL.Interfaces;
using ContactDetails.Models;

namespace ContactDetails.Controllers
{
    [Route("api/[controller]")]
    public class ContactDetailsController : ControllerBase
    {
        private readonly ITblContactDetailsBL _iTblContactDetailsBL;
        public ContactDetailsController(ITblContactDetailsBL iTblContactDetailsBL)
        {
            _iTblContactDetailsBL = iTblContactDetailsBL;
        }

        [Route("GetAllContactDetails")]
        [HttpGet]
        public List<TblContactDetailsTO> GetAllContactDetails()
        {
            List<TblContactDetailsTO> tblContactDetailsTOList = _iTblContactDetailsBL.SelectTblContactDetailsList();
            return tblContactDetailsTOList;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [Route("PostSaveContactDetailsTO")]
        [HttpPost]
        public ResultMessage PostSaveContactDetailsTO([FromBody] TblContactDetailsTO data)
        {
            ResultMessage resMsg = new ResultMessage();
            try
            {
                resMsg = _iTblContactDetailsBL.InsertTblContactDetails(data);
                return resMsg;
            }
            catch (Exception ex)
            {
                resMsg.DefaultExceptionBehaviour(ex, "PostSaveCRMEvent");
                return resMsg;
            }
        }

        [Route("PostUpdateContactDetailsTO")]
        [HttpPost]
        public ResultMessage PostUpdateContactDetailsTO([FromBody] TblContactDetailsTO data)
        {
            ResultMessage resMsg = new ResultMessage();
            try
            {
                resMsg = _iTblContactDetailsBL.UpdateTblContactDetails(data);
                return resMsg;
            }
            catch (Exception ex)
            {
                resMsg.DefaultExceptionBehaviour(ex, "PostSaveCRMEvent");
                return resMsg;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [Route("PutUpdateContactDetailsTO")]
        [HttpPut]
        public ResultMessage PutUpdateContactDetailsTO([FromBody] TblContactDetailsTO data)
        {
            ResultMessage resMsg = new ResultMessage();
            try
            {
                resMsg = _iTblContactDetailsBL.UpdateTblContactDetails(data);
                return resMsg;
            }
            catch (Exception ex)
            {
                resMsg.DefaultExceptionBehaviour(ex, "PostSaveCRMEvent");
                return resMsg;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}