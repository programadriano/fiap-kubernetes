using KubernetesRESTful.Infra;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesRESTful.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KubernetesController : ControllerBase
    {


        private readonly ILogger<KubernetesController> _logger;
        private readonly KubernetesLib _kubernetesLib;

        public KubernetesController(ILogger<KubernetesController> logger, KubernetesLib kubernetesLib)
        {
            _logger = logger;
            _kubernetesLib = kubernetesLib;
        }

        [HttpGet("BuscarEventos")]
        public IActionResult Get()
        {
            return Ok(_kubernetesLib.GetEvents());
        }
    }
}