# 🏡 ImovelAPI - Previsão de Preço de Imóveis com ML.NET

Este projeto consiste em uma API desenvolvida com ASP.NET Core e ML.NET que realiza a **previsão de preços de imóveis** com base em características como tamanho, quantidade de quartos e banheiros.

---

## 👥 Integrantes do Grupo

* **Ander Kamada** - RM553449

---

## 🎯 Objetivo do Projeto

Aplicar conceitos de **Machine Learning** utilizando o ML.NET em um projeto de Web API, com divisão 70% para treino e 30% para teste, para resolver um problema prático de regressão: **estimar o preço de um imóvel**.

---

## 🛠️ Tecnologias Utilizadas

* ASP.NET Core Web API
* ML.NET (`FastTreeRegression`)
* Visual Studio / VS Code
* C#
* Postman (para testes)
* CSV como base de dados

---

## 🧠 Modelo Treinado

O modelo utiliza o algoritmo `FastTreeRegression` do ML.NET, com as seguintes **features de entrada**:

* `Tamanho` (em m²)
* `Quartos`
* `Banheiros`

**Target (Label):**

* `Preco`

---

## 🗂️ Estrutura do Projeto

```
ImovelAPI/
├── data/
│   └── dados.csv
├── controllers/
│   └── PredicaoController.cs
├── model/
│   └── ImovelData.cs
├── services/
│   └── ModelTrainer.cs
├── Program.cs
└── README.md
```

---

## 📊 Dataset de Entrada

**Arquivo:** `data/dados.csv`

```csv
Tamanho,Quartos,Banheiros,Preco
50,2,1,180000
60,2,2,210000
80,3,2,250000
100,4,3,350000
120,4,3,420000
...
```

---

## ▶️ Como Executar o Projeto

### Pré-requisitos

* .NET SDK 6.0 ou superior
* Visual Studio Code ou Visual Studio

### Passo a passo

```bash
cd C:\projeto\projeto_cp6
dotnet run
```

A API será iniciada em:

```
http://localhost:5055
```

---

## 📬 Teste com Postman

**Endpoint:**

```
POST /api/predicao
```

**Exemplo de Body (raw JSON):**

```json
{
  "Tamanho": 85,
  "Quartos": 3,
  "Banheiros": 2
}
```

**Exemplo de resposta:**

```json
{
  "score": 275000.0
}
```

## 🧪 Divisão dos Dados

A divisão do dataset foi feita automaticamente:

* 70% dos dados para treinamento
* 30% para teste

---

## ✅ Conclusão

Este projeto demonstra a aplicação prática de **regressão supervisionada com ML.NET**, integrando aprendizado de máquina com uma API Web funcional. A solução permite prever preços de imóveis e pode ser expandida com novos dados e algoritmos mais robustos.
