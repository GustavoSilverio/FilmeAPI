using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models;
using FilmeAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ReadEnderecoDTO> ObterEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDTO>>(_context.Endereco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult ObterEnderecoById([FromRoute] int id)
        {
            var endereco = _context.Endereco.FirstOrDefault(e => e.Id == id);
            if (endereco == null) return NotFound();

            ReadEnderecoDTO enderecoDTO = _mapper.Map<ReadEnderecoDTO>(endereco);
            return Ok(enderecoDTO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enderecoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterEnderecoById), new { Id = endereco.Id }, endereco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enderecoDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco([FromRoute] int id, [FromBody] UpdateEnderecoDTO enderecoDTO)
        {
            var endereco = _context.Endereco.FirstOrDefault(e => e.Id == id);
            if (endereco == null) return NotFound();

            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult ExcluirEndereco([FromRoute] int id)
        {
            var endereco = _context.Endereco.FirstOrDefault(e => e.Id == id);
            if (endereco == null) return NotFound();
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
