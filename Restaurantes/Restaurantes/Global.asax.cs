using System.Collections.Concurrent;
using System.Web.Http;
using Restaurantes.Models;

namespace Restaurantes
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MemoryRepository<Comida>.Repo = new ConcurrentDictionary<int, Comida>();
            MemoryRepository<Comida>.Repo.TryAdd(1, new Comida { Restaurant = "Arkady Plotnitsky", Id = 1, Precio = 10, Cantidad = 10, Nombre = "Epistemology and Probability: Bohr, Heisenberg, Schrödinger, and the Nature of Quantum-Theoretical Thinking" });
            MemoryRepository<Comida>.Repo.TryAdd(2, new Comida { Restaurant = "Brian Cox", Id = 2, Precio = 15, Cantidad = 100, Nombre = "The Quantum Universe: Everything that can happen does happen" });
            MemoryRepository<Comida>.Repo.TryAdd(3, new Comida { Restaurant = "Jim Al-Khalili", Id = 3, Precio = 20, Cantidad = 1000, Nombre = "Quantum: A Guide For The Perplexed" });
        }
    }
}
