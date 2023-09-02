using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Helpers;
using SampleWebApiAspNetCore.Services;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;
using System.Text.Json;

namespace SampleWebApiAspNetCore.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly ILinkService<MoviesController> _linkService;

        public MoviesController(
            IMovieRepository movieRepository,
            IMapper mapper,
            ILinkService<MoviesController> linkService)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingleMovie))]
        public ActionResult GetSingleMovie(ApiVersion version, int id)
        {
            MovieEntity movieItem = _movieRepository.GetSingle(id);

            if (movieItem == null)
            {
                return NotFound();
            }

            MovieDto item = _mapper.Map<MovieDto>(movieItem);

            return Ok(_linkService.ExpandSingleMovieItem(item, item.Id, version));
        }

        [HttpPost(Name = nameof(AddMovie))]
        public ActionResult<MovieDto> AddMovie(ApiVersion version, [FromBody] MovieCreateDto movieCreateDto)
        {
            if (movieCreateDto == null)
            {
                return BadRequest();
            }

            MovieEntity toAdd = _mapper.Map<MovieEntity>(movieCreateDto);

            _movieRepository.Add(toAdd);

            if (!_movieRepository.Save())
            {
                throw new Exception("Creating a drinkitem failed on save.");
            }

            MovieEntity newMovieItem = _movieRepository.GetSingle(toAdd.Id);
            MovieDto movieDto = _mapper.Map<MovieDto>(newMovieItem);

            return CreatedAtRoute(nameof(GetSingleMovie),
                new { version = version.ToString(), id = newMovieItem.Id },
                _linkService.ExpandSingleMovieItem(movieDto, movieDto.Id, version));
        }

        [HttpDelete]
        [Route("{id:int}", Name = nameof(RemoveMovie))]
        public ActionResult RemoveMovie(int id)
        {
            MovieEntity movieItem = _movieRepository.GetSingle(id);

            if (movieItem == null)
            {
                return NotFound();
            }

            _movieRepository.Delete(id);

            if (!_movieRepository.Save())
            {
                throw new Exception("Deleting a movieitem failed on save.");
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}", Name = nameof(UpdateMovie))]
        public ActionResult<MovieDto> UpdateMovie(ApiVersion version, int id, [FromBody] MovieUpdateDto movieUpdateDto)
        {
            if (movieUpdateDto == null)
            {
                return BadRequest();
            }

            var existingMovieItem = _movieRepository.GetSingle(id);

            if (existingMovieItem == null)
            {
                return NotFound();
            }

            _mapper.Map(movieUpdateDto, existingMovieItem);

            _movieRepository.Update(id, existingMovieItem);

            if (!_movieRepository.Save())
            {
                throw new Exception("Updating a movieitem failed on save.");
            }

            MovieDto movieDto = _mapper.Map<MovieDto>(existingMovieItem);

            return Ok(_linkService.ExpandSingleMovieItem(movieDto, movieDto.Id, version));
        }
    }
}
