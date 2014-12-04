using System.Collections.Generic;
using System.Web.Http;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class ComidaController : ApiController
    {
        private readonly IRepository<Comida> _repository;

        public ComidaController()
            : this(new MemoryRepository<Comida>())
        {
        }

        public ComidaController(IRepository<Comida> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Comida> Get()
        {
            return _repository.Items;
        }
    }
}
