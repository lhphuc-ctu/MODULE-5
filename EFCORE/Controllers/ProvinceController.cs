using AutoMapper;
using EFCORE.Context;
using EFCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCORE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProvinceController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Address.
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns>Get all provine</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Address
        ///     {
        ///        "provinceName": "An Giang",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns all provine or provine contain input name</response>
        [HttpGet]
        public async Task<IActionResult> Get(string? provinceName = null)
        {
            var province = await _context.Provinces.ToListAsync();

            if (provinceName != null) 
            {
                province = province.Where(x => x.ProvinceName!.ToLower()
                                      .Contains(provinceName.ToLower()))
                      .ToList();
            }

            var dto = _mapper.Map<IEnumerable<Province>, IEnumerable<ProvinceDTO>>(province);
            return Ok(dto);
        }

        /// <summary>
        /// Create new Province.
        /// </summary>
        /// <param name="province"></param>
        /// <returns>Newly create provine</returns>
        /// <remarks>
        /// Sample request
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProvinceDTO provinceDTO)
        {
            if (ModelState.IsValid)
            {
                var province = _mapper.Map<ProvinceDTO, Province>(provinceDTO);

                _context.Provinces.Add(province);
                await _context.SaveChangesAsync();
                var res = _mapper.Map<Province,ProvinceDTO>(province);
                return Created($"/Address/{province.ProvinceID}", res);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProvince(int id)
        {
            var province = await _context.Provinces.FindAsync(id);


            if (province == null)
            {
                return NotFound();
            }

            return Ok(province);
        }

        [HttpGet("/test")]
        public IActionResult Test()
        {
            int id = 3;

            IEnumerable<Province> list = _context.Provinces.Where(x => x.ProvinceID == id);
            Console.WriteLine(list.Where(x=> x.Code == "CT").ToList());

            IQueryable<Province> query = _context.Provinces.Where(x => x.ProvinceID == id);
            Console.WriteLine(query.Where(x => x.Code == "CT").ToList());
            return Ok(id);
        }

        [HttpGet("/groupbycode")]
        public IActionResult GroupByCode()
        {
            List<KeyValuePair<string, int>> list = new();

            var group = _context.Provinces.GroupBy(x => x.Code);

            foreach(var groupCode in group)
            {
                list.Add(new KeyValuePair<string, int>(groupCode.Key!, groupCode.Count()));
            }
            
            var res = list.OrderByDescending(x => x.Value);
            return Ok(res);
        }
    }
}
