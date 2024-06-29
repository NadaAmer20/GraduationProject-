using GraduationProject.DTO;
using GraduationProject.DTO.DTOForRestaurants;
using GraduationProject.DTO.DTOReview;
using GraduationProject.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace GraduationProject.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        RestaurantDto GetResturantById(int id);
        List<RestaurantDto> getAll(); 
        List<DtoService> getAll2();


        List<Restaurant> getAllBtSortReview();

        int Create(AddRestaurantDto dto,  IFormFile imageFiles);
        void Delete(int id);
        void Update(int id, AddRestaurantDto dto, IFormFile file, int ImageId);

        int CreateMenuForRest(AddMenuItemsDto dto);
        void DeleteMenu(int id);
        void UpdateMenuItem(int id, AddMenuItemsDto dto);

        List<RestaurantDto> Search(string name);
 
        List<MenuItemsDto> GetAll(int restaurantId);
         int CreateReview(string UserId, int WorkspaceId, DTOReview dTOReview);
        void DeleteReview(int id);
        void UpdateReview(int id, DTOReview dto);
        List<DTOOReview> GetAllReviews(int ServiceId, string name);
    }
}
