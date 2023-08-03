﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;

        public ProductsController (IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepository = hangHoaRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts(string search, double? from, double? to, string sortBy)
        {
            try
            {
                var result = _hangHoaRepository.GetAll(search, from, to, sortBy);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Can't get product");
            }
           
        }
    }
}
