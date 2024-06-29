using GraduationProject.DTO.DTOForWorkspace;
using GraduationProject.DTO.DTOPlayStation;
using GraduationProject.DTO.DTOReview;
using GraduationProject.DTO.SuperMarket;
using GraduationProject.Models;
using GraduationProject.Services.PlayStationServices;
using GraduationProject.Services.SuperMarketServices;
using GraduationProject.Services.WorkSpaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperMarketController : ControllerBase
    {
        private readonly ISuperMarketServices superMarketServices;
        private readonly UserManager<User> usermanger;
        public SuperMarketController(ISuperMarketServices _superMarketServices, UserManager<User> usermanger)
        {
            superMarketServices = _superMarketServices;
            this.usermanger = usermanger;
        }
        //Create,,delete,,update ....................................................................................
         [HttpPost("CreateSupermarket")]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateSupermarket([FromForm] AddSupermarketDto Service,   IFormFile files)//,  IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            superMarketServices.Create(Service, files);
            return new JsonResult(new { message = "تمت الاضافه بنجاح" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateSupermarket")]
        public ActionResult UpdateSupermarket(int id, [FromForm] AddSupermarketDto Service, IFormFile file, int ImageId)//, IFormFile file)
        {
            superMarketServices.Update(id, Service, file, ImageId);
            return new JsonResult(new { message = "تم التعديل بنجاح" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteSupermarket")]
        public ActionResult DeleteSupermarket(int id)
        {
            superMarketServices.Delete(id);

            return new JsonResult(new { message = "تم الحذف بنجاح" });
        }
        //...........................................................................................

        [HttpGet("GetAllSuperMarkets")]
        public IActionResult GetAllSuperMarkets()
        {
            var superMarkets = superMarketServices.GetAllSuperMarket();
            if (superMarkets == null)
                return BadRequest("There is No Data");
            return Ok(superMarkets);
        }


        [HttpGet("GetAllSuperMarkets2")]
        public IActionResult GetAllSuperMarkets2()
        {
            var superMarkets = superMarketServices.GetAllSuperMarket2();
            if (superMarkets == null)
                return BadRequest("There is No Data");
            return Ok(superMarkets);
        }
        [HttpGet("GetSuperMarketById")]
        public IActionResult GetWorkspaceById(int id)
        {
            var superMarket = superMarketServices.GetSuperMarketByID(id);
            if (superMarket == null)
                return BadRequest("There is No Data");
            return Ok(superMarket);
        }



        [HttpGet("Search")]
        //  [Authorize(Roles = UserRoles.Admin )]
        public ActionResult Search(  string name)
        {
            var superMarket  = superMarketServices.Search(name);
            if (superMarket == null)
                return BadRequest("There is No Data");
            return Ok(superMarket);
        }


        [HttpGet("GetAllSuperMarketsActiveNow")]
        public IActionResult GetAllWorkspacesActiveNow()
        {
            var superMarkets = superMarketServices.GetAllSuperMarketDtoActiveNow();
            if (superMarkets == null)
                return BadRequest("There is No Data");
            return Ok(superMarkets);
        }

        [HttpGet("GetAllSuperMarketbySortReview")]
        public IActionResult GetAllWorkspacesbySortReview()
        {
            var superMarkets = superMarketServices.GetAllSuperMarketByReview();
            if (superMarkets == null)
                return BadRequest("There is No Data");
            return Ok(superMarkets);
        }
         
        [HttpPost("CreateReviewForSuperMarket")]
        public async Task<IActionResult> CreateReview(int superMarketId, [FromForm] DTOReview dTOReview)//,  IFormFile file)
        {
            User user = await usermanger.GetUserAsync(User);
            var id = superMarketServices.CreateReview(user.Id, superMarketId, dTOReview);
            return Ok("Add Done");
        }


        [HttpPut("UpdateReview")]
        public ActionResult UpdateReview(int superMarketId, [FromForm] DTOReview dTOReview)//, IFormFile file)
        {
            superMarketServices.UpdateReview(superMarketId, dTOReview);
            return Ok("Update Review Done");
        }


        [HttpDelete("Delete  Review")]
        public ActionResult DeleteReview(int id)
        {
            superMarketServices.DeleteReview(id);
            return Ok("Delete  Review Done");
        }

        [HttpPost("GetAllReviewForSuperMarket")]
        public ActionResult GetAllReview(int superMarketId, [FromForm] string name)
        {
            List<DTOOReview> dTOReviews = superMarketServices.GetAllReviews(superMarketId, name);
            return Ok(dTOReviews);
        }
    }
}
