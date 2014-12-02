using System.Web.Http;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IRepository<Comida> _repository;

        public AdminController()
            : this(new MemoryRepository<Comida>())
        { }

        public AdminController(IRepository<Comida> repository)
        {
            _repository = repository;
        }
    }
}
