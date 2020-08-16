using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.config;
using Backend.Dtos;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointsController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPointRepository _pointRepository;
        private readonly IApplicationUploadFiles _uploadsFiles;
        private readonly IMapper _mapper;

        public PointsController(IItemRepository itemRepository, IPointRepository pointRepository, IApplicationUploadFiles uploadFiles, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _pointRepository = pointRepository;
            _uploadsFiles = uploadFiles;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointReadDto>>> GetFilteredPoints([FromQuery] string city, [FromQuery] string uf, [FromQuery] string items)
        {
            if (city == null || uf == null) return NotFound(new { message = "City or UF Not Found" });

            List<int> parsedItems = items != null ? items.Split(',').Select(item => int.Parse(item.Trim())).ToList() : new List<int>();
            var points = await _pointRepository.GetFilteredPoints(city, uf, parsedItems);
            var pointReadDto = _mapper.Map<IEnumerable<PointReadDto>>(points);

            return Ok(pointReadDto);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PointItemReadDto>> GetPointsItemsById(int id)
        {
            var point = await _pointRepository.GetPointById(id);
            if (point == null) return NotFound(point);

            var pointItemsReadDto = _mapper.Map<PointItemReadDto>(point);
            var pointItems = await _itemRepository.GetItemsByPointId(id);
            var itemIntoPointReadDto = _mapper.Map<IEnumerable<ItemIntoPointReadDto>>(pointItems);
            pointItemsReadDto.ItemsIntoPoint = itemIntoPointReadDto;

            return Ok(pointItemsReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<Point>> CreatePoint([FromForm] PointCreateDto pointCreateDto, [FromForm] IFormFile image)
        {

            try
            {
                pointCreateDto.ImageUrl = await _uploadsFiles.UploadFile(image);

                var pointModel = _mapper.Map<Point>(pointCreateDto);
                await _pointRepository.CreatePoint(pointModel);

                var pointReadDto = _mapper.Map<PointReadDto>(pointModel);

                List<PointItemCreateDto> pointItems = new List<PointItemCreateDto>();

                foreach (int itemId in pointCreateDto.Items.Split(",").Select(item => int.Parse(item)).ToList())
                {
                    pointItems.Add(new PointItemCreateDto
                    {
                        ItemId = itemId,
                        PointId = pointReadDto.Id
                    });
                }

                var pointItemsModel = _mapper.Map<List<PointItem>>(pointItems);
                await _pointRepository.CreatePointItems(pointItemsModel);

                return CreatedAtRoute(new { Id = pointReadDto.Id }, pointReadDto);
            }
            catch (Exception)
            {

                return BadRequest(new { errorMessage = "Point is null or contains repeated name" });
            }

        }
    }
}
