using AutoMapper;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Profiles
{
    public class PointProfile : Profile
    {
        public PointProfile()
        {
            CreateMap<Point, PointItemReadDto>();
            CreateMap<Point, PointReadDto>();
            CreateMap<PointCreateDto, Point>();
        }
    }
}
