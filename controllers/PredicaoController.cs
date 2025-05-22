using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using ImovelAPI.Model;
using ImovelAPI.Services;

namespace ImovelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredicaoController : ControllerBase
    {
        private readonly PredictionEngine<ImovelInput, ImovelOutput> _engine;
        private readonly string _modelPath = "MLModel.zip";

        public PredicaoController()
        {
            if (!System.IO.File.Exists(_modelPath))
                ModelTrainer.TreinarModelo();

            var mlContext = new MLContext();
            var model = mlContext.Model.Load(_modelPath, out var _);
            _engine = mlContext.Model.CreatePredictionEngine<ImovelInput, ImovelOutput>(model);
        }

        [HttpPost]
        public ActionResult<ImovelOutput> PreverPreco([FromBody] ImovelInput input)
        {
            var resultado = _engine.Predict(input);
            return Ok(resultado);
        }
    }
}
