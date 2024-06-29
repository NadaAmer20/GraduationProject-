using GraduationProject.DTO.DTOForDoctors;
using GraduationProject.DTO.DTOForWorkspace;
using GraduationProject.DTO.DTOPharmacies;
using GraduationProject.DTO.DTOReview;
using GraduationProject.Models;
using GraduationProject.Services.DoctorsServices;
using GraduationProject.Services.PharmaciesServices;
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
    [Authorize]
    public class pharmacieController : ControllerBase
    {
        private readonly IPharmaciesServices   pharmaciesServices;
        private readonly UserManager<User> usermanger;
        public pharmacieController(IPharmaciesServices _pharmaciesServices, UserManager<User> usermanger)
        {
            pharmaciesServices = _pharmaciesServices;
            this.usermanger = usermanger;
        }
        //create,,delete,,update for pharmacie.....................................................................................
        [Authorize(Roles = "Admin")]
        [HttpPost("CreatePharmacie")]
        public ActionResult CreatePharmacie([FromForm] AddPharmacieDto dTOPharmacie,   IFormFile files)//,  IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            pharmaciesServices.Create(dTOPharmacie, files);
            return new JsonResult(new { message = "تمت الاضافه بنجاح" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePharmacie")]
        public ActionResult UpdatePharmacie(int id, [FromForm] AddPharmacieDto dTOPharmacie, IFormFile file, int ImageId)
        {
            pharmaciesServices.Update(id, dTOPharmacie, file, ImageId);
            return new JsonResult(new { message = "تم التعديل بنجاح" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePharmacie")]
        public ActionResult DeletePharmacie(int id)
        {
            pharmaciesServices.Delete(id);

            return new JsonResult(new { message = "تم الحذف بنجاح" });
        }

        //................................................................
        [HttpGet("GetAllPharmacies")]
        public IActionResult GetAllPharmacies()
        {
            List<DTOOPharmacie>   pharmacies  = pharmaciesServices.GetAllPlayPharmacies();
            if (pharmacies  == null)
                return BadRequest("There is No Data");
            return Ok(pharmacies);
        }
        [HttpGet("GetAllPharmacies2")]
        public IActionResult GetAllPharmacies2()
        {
           var pharmacies = pharmaciesServices.GetAllPlayPharmacies2();
            if (pharmacies == null)
                return BadRequest("There is No Data");
            return Ok(pharmacies);
        }
        [HttpGet("GetAllPharmaciesBySortReview")]
        public IActionResult GetAllPharmaciesBySortReview()
        {
            List<Pharmacies> pharmacies = pharmaciesServices.GetAllPlayPharmaciesBySortReview();
            if (pharmacies == null)
                return BadRequest("There is No Data");
            return Ok(pharmacies);
        }

        [HttpGet("GetPharmacieById")]//route
        //  [Authorize(Roles = UserRoles.Admin )]
        public ActionResult GetPharmacieById(int id)
        {
             DTOOPharmacie pharmacies = pharmaciesServices.GetPharmacieByID(id);
            if (pharmacies == null)
                return BadRequest("There is No Data");
            return Ok(pharmacies);
        }


        [HttpGet("Search")]
        //  [Authorize(Roles = UserRoles.Admin )]
        public ActionResult Search(  string name)
        {
            var pharmacie = pharmaciesServices.Search(name) ;
            if (pharmacie == null)
                return BadRequest("There is No Data");
            return Ok(pharmacie);
        }


        [HttpGet("GetAllPharmaciesActiveNow")]
        public IActionResult GetAllPharmaciesActiveNow()
        {
            List<DTOOPharmacie> pharmacies = pharmaciesServices.GetAllPharmaciesActiveNow();
            if (pharmacies == null)
                return BadRequest("There is No Data");
            return Ok(pharmacies);
        }

         //Review............................................................................

        [HttpPost("CreateReviewForPharmacie")]
        public  async Task<IActionResult> CreateReview(int pharmacieId, [FromForm] DTOReview dTOReview)//,  IFormFile file)
        {
            User user = await usermanger.GetUserAsync(User);
            var id = pharmaciesServices.CreateReview(user.Id, pharmacieId, dTOReview);
            return Ok("Add Done");
        }


        [HttpPut("UpdateReview")]
        public ActionResult UpdateReview(int pharmacieId, [FromForm] DTOReview dTOReview)//, IFormFile file)
        {
            pharmaciesServices.UpdateReview(pharmacieId, dTOReview);//,file);
            return Ok("Update Review Done");
        }


        [HttpDelete("DeleteReview")]
        public ActionResult DeleteReview(   int id)
        {
            pharmaciesServices.DeleteReview(id);
            return Ok("Delete  Review Done");
        }

        [HttpPost("GetAllReviewForPharmacies")]
        public ActionResult GetAllReview(int pharmacieId, string name)
        {
            List<DTOOReview> dTOReviews = pharmaciesServices.GetAllReviews(pharmacieId, name);
            return Ok(dTOReviews);
        }
        
    
    }
}
