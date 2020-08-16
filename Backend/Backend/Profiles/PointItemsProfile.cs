using AutoMapper;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Profiles
{
    public class PointItemsProfile : Profile
    {
        public PointItemsProfile()
        {
            CreateMap<PointItemCreateDto, PointItem>();
        }
    }
}
