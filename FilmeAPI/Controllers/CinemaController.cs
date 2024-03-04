using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models;
using FilmeAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDTO> ObterCinemas()
        {
            return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinema.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult ObterCinemaPorId([FromRoute] int id)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(c => c.Id == id);
            if (cinema == null) return NotFound();

            ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDTO);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Cinema.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterCinemaPorId), new { Id = cinema.Id }, cinemaDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema([FromRoute] int id, [FromBody] UpdateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(c => c.Id == id);
            if (cinema == null) return NotFound();

            _mapper.Map(cinemaDTO, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirCinemaById([FromRoute] int id)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(c => c.Id == id);
            if (cinema == null) return NotFound();

            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
