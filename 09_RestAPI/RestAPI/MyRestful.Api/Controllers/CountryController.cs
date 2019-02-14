using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuRestful.Core.Domains;
using MyRestful.Api.ViewModels;
using MyRestful.Infrastructure.Repositories;
using MyRestful.Infrastructure.UnitOfWork;

namespace MyRestful.Api.Controllers
{
    [Authorize]
    [Route("api/countries")]
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CountryViewModel newCountry)
        {
            newCountry = new CountryViewModel
            {
                Id = 777,
                ChineseName = "777",
                EnglishName = "575675",
                Abbreviation = "777",
            };


            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                //return View("Create", person);
            }

            var resultsCountry = _mapper.Map<Country>(newCountry);
            await _countryRepository.Add(resultsCountry);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<CountryViewModel>(newCountry);
            return CreatedAtRoute("GetCountry", new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var newCountry = new Country
            {
                ChineseName = "666",
                EnglishName = "666",
                Abbreviation = "666",
            };
            await _countryRepository.Add(newCountry);
            await _unitOfWork.SaveAsync();

            var queryResults = await _countryRepository.GetAll();
            var results = _mapper.Map<List<CountryViewModel>>(queryResults);
            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetCountry")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var queryResult = await _countryRepository.Get(id);
                var result = _mapper.Map<CountryViewModel>(queryResult);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(QueryPage queryPage)
        //{
        //    return _countryRepository.GetByPage(queryPage);
        //}
    }
}
