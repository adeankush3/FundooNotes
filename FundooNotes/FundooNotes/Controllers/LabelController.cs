using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReposatoryLayer.DBContext;
using ReposatoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : ControllerBase
    {
        FundooContext fundooContext;
        ILabelBL labelBL;

        public LabelController(FundooContext fundooContext, ILabelBL labelBL)
        {
            this.fundooContext = fundooContext;
            this.labelBL = labelBL;
        }

        [HttpPost("AddLabel/{userId}/{noteId}/{labelName}")]
        public async Task<ActionResult> AddLabel(int userId, int noteId, string labelName)
        {
            try
            {
                await this.labelBL.AddLabel(userId, noteId, labelName);
                return this.Ok(new { success = true, message = "Label Added Successfully" });

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
       
        [Authorize]
        [HttpGet("GetLabelByuserId/{userId}")]
        public async Task<ActionResult> GetLabelByuserId()
        {
            try
            {
                List<Labels> res = new List<Labels>();
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                res = await this.labelBL.GetLabelByuserId(userId);
                if (res == null)
                {
                    return this.BadRequest(new { success = false, message = " Sorry!!! unable to get label" });
                }
                return this.Ok(new { success = true, message = $" get Label information successfully", data = res });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Authorize]
        [HttpGet("GetlabelByNoteId/{NoteId}")]
        public async Task<ActionResult> GetLabelByNoteId(int NoteId)
        {
            try
            {
                List<Labels> res = new List<Labels>();
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                res = await this.labelBL.GetLabelByNoteId(userId, NoteId);
                if (res == null)
                {
                    return this.BadRequest(new { success = true, message = " Sorry!!! Unable to get label" });
                }
                return this.Ok(new { success = true, message = $" get Label information successfully", data = res });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("UpdateLabel/{LabelId}/{LabelName}")]
        public async Task<ActionResult> UpdateLabel(string LabelName, int LabelId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);

                var result = await this.labelBL.UpdateLabel(userId, LabelId, LabelName);
                if (result == null)
                {
                    return this.BadRequest(new { success = true, message = "Updation of Label failed" });
                }
                return this.Ok(new { success = true, message = $"Label updated successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete("DeleteLabel/{labelId}")]
        public async Task<ActionResult> DeleteLabel(int labelId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.labelBL.DeleteLabel(labelId, userId);
                return this.Ok(new { success = true, message = $"Label Deleted successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}