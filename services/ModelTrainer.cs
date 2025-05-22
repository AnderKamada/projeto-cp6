using Microsoft.ML;
using ImovelAPI.Model;

namespace ImovelAPI.Services
{
    public class ModelTrainer
    {
        private static readonly string _dataPath = "DATA/dados.csv";
        private static readonly string _modelPath = "MLModel.zip";

        public static void TreinarModelo()
        {
            var mlContext = new MLContext();

            // Carrega os dados do CSV para a classe ImovelData
            var dados = mlContext.Data.LoadFromTextFile<ImovelData>(
                path: _dataPath,
                hasHeader: true,
                separatorChar: ',');

            // Divide os dados entre treino (70%) e teste (30%)
            var partes = mlContext.Data.TrainTestSplit(dados, testFraction: 0.3);

            // Define a pipeline de transformação e treinamento
            var pipeline = mlContext.Transforms
                .Concatenate("Features", "Tamanho", "Quartos", "Banheiros")
                .Append(mlContext.Transforms.CopyColumns("Label", "Preco"))
                .Append(mlContext.Regression.Trainers.FastTree());

            // Treina o modelo
            var modelo = pipeline.Fit(partes.TrainSet);

            // Salva o modelo treinado
            mlContext.Model.Save(modelo, partes.TrainSet.Schema, _modelPath);
        }
    }
}
