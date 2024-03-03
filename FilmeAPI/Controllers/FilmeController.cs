using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models;
using FilmeAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtêm todos os filmes do banco de dados
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns code="200">Caso a busca seja feita com sucesso</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadFilmeDTO> ObterFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadFilmeDTO>>(_context.Filme.Skip(skip).Take(take));
        }

        /// <summary>
        /// Obtêm um filme por id do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns code="200">Caso a busca seja feita com sucesso</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObterFilmeById([FromRoute] int id)
        {
            var filme = _context.Filme.FirstOrDefault(f => f.Id == id);

            if (filme == null) return NotFound();

            var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);

            return Ok(filmeDTO);
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDTO"></param>
        /// <returns code="201">Caso inserção seja feita com sucesso</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            
            _context.Filme.Add(filme);
            _context.SaveChanges();
           return CreatedAtAction(nameof(ObterFilmeById), new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Atualiza todos os campos de um filme do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filmeDTO"></param>
        /// <returns code="204">Caso atualização seja feita com sucesso</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult AtualizarFilme([FromRoute] int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            var filme = _context.Filme.FirstOrDefault(f => f.Id == id);

            if (filme == null) return NotFound();

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Atualiza algum campo de um filme do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filmeParcial"></param>
        /// <returns code="204">Caso atualização seja feita com sucesso</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult AtualizarFilmeParcial([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateFilmeDTO> filmeParcial)
        {
            var filme = _context.Filme.FirstOrDefault(f => f.Id == id);

            if (filme == null) return NotFound();

            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

            filmeParcial.ApplyTo(filmeParaAtualizar, ModelState);

            if (!TryValidateModel(filmeParaAtualizar)) return ValidationProblem(ModelState);

            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Exclui um filme do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns code="204">Caso a exclusão seja feita com sucesso</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ExcluirFilme([FromRoute] int id)
        {
            var filme = _context.Filme.FirstOrDefault(f => f.Id == id);

            if (filme == null) return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
