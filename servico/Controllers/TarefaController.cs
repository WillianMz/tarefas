using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Entidades;
using Tarefas.Interfaces;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITarefaRepository _tarefaRep;
        private readonly ICategoriaRepository _categoriaRep;
        private readonly IMapper _mapper;

        public TarefaController(IUnitOfWork unitOfWork, ITarefaRepository tarefaRep, ICategoriaRepository categoriaRep, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tarefaRep = tarefaRep;
            _categoriaRep = categoriaRep;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody] TarefaModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Informe os dados!");

                Categoria categoria = await _categoriaRep.GetById(model.CategoriaId);
                if (categoria != null)
                {
                    Tarefa tarefa = new(model.Titulo, model.Descricao, categoria, DateOnly.Parse(model.DataInicio));
                    _tarefaRep.Create(tarefa);
                    await _unitOfWork.Commit();
                    return Ok("Tarefa adicionada com sucesso!");
                }
                else
                    return Ok("Categoria não encontrada!");
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var tarefas = await _tarefaRep.GetAll();
                return Ok(_mapper.Map<List<TarefaModel>>(tarefas));
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
