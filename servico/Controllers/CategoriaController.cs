using Microsoft.AspNetCore.Mvc;
using Tarefas.Entidades;
using Tarefas.Interfaces;

namespace Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRep;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaController(ICategoriaRepository categoriaRep, IUnitOfWork unitOfWork)
        {
            _categoriaRep = categoriaRep;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody] string nome)
        {
            try
            {
                if (!string.IsNullOrEmpty(nome))
                {
                    Categoria categoria = new(nome);
                    _categoriaRep.Create(categoria);
                    await _unitOfWork.Commit();

                    return Ok("Categoria adiciona com sucesso!");
                }
                else
                {
                    return Ok("Informe o nome da categoria");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put([FromBody] int id, string nome)
        {
            try
            {
                if (!string.IsNullOrEmpty(nome))
                {
                    Categoria categoria = await _categoriaRep.GetById(id);
                    if(categoria != null)
                    {
                        categoria.Editar(nome);
                        _categoriaRep.Update(categoria);
                        await _unitOfWork.Commit();

                        return Ok("Categoria adiciona com sucesso!");
                    }
                    else
                        return Ok("Categoria não encontrada!");
                }
                else
                {
                    return Ok("Informe o nome da categoria");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var categorias = await _categoriaRep.GetAll();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
