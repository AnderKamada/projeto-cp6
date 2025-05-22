using Microsoft.ML.Data;

namespace ImovelAPI.Model
{
    public class ImovelData
    {
        [LoadColumn(0)]
        public float Tamanho { get; set; }

        [LoadColumn(1)]
        public float Quartos { get; set; }

        [LoadColumn(2)]
        public float Banheiros { get; set; }

        [LoadColumn(3)]
        public float Preco { get; set; } // <-- ESSA É A LABEL
    }

    public class ImovelInput
    {
        public float Tamanho { get; set; }
        public float Quartos { get; set; }
        public float Banheiros { get; set; }
    }

    public class ImovelOutput
    {
        public float Score { get; set; }
    }
}
