using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models;
using FilmeAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDTO> ObterSessoes()
        {
            return _mapper.Map<List<ReadSessaoDTO>>(_context.Sessao.ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]
        public IActionResult ObterSessaoPorId([FromRoute] int filmeId, [FromRoute] int cinemaId)
        {
            Sessao Sessao = _context.Sessao.FirstOrDefault(s => s.FilmeId == filmeId && s.CinemaId == cinemaId);
            if (Sessao == null) return NotFound();

            ReadSessaoDTO SessaoDTO = _mapper.Map<ReadSessaoDTO>(Sessao);
            return Ok(SessaoDTO);
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDTO SessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(SessaoDTO);
            _context.Sessao.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterSessaoPorId), new { sessao.FilmeId, sessao.CinemaId }, SessaoDTO);
        }
    }
}
