using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI
{
    public class MachineLearningService
    {
        static readonly string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "MachineLearning", "TrainData.csv");
        static readonly string _testDataPath = Path.Combine(Environment.CurrentDirectory, "MachineLearning", "TestData.csv");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "MachineLearning", "Model.zip");
        public static ITransformer Train(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<GameData>(dataPath, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Result")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "OpponentIdEncoded", inputColumnName: "OpponentId"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "IsHomeEncoded", inputColumnName: "IsHome"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "IsDayAfterDayEncoded", inputColumnName: "IsDayAfterDay"))
                .Append(mlContext.Transforms.Concatenate("Features", "OpponentIdEncoded", "IsHomeEncoded", "IsDayAfterDayEncoded"))
                .Append(mlContext.Regression.Trainers.FastTree());

            //Create the model
            var model = pipeline.Fit(dataView);

            //Return the trained model
            return model;
        }
        public static void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<GameData>(_testDataPath, hasHeader: true, separatorChar: ',');
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics output         ");
            Console.WriteLine($"*------------------------------------------------");

            Console.WriteLine($"*       R-Squared Score:      {metrics.RSquared:0.###}");

            Console.WriteLine($"*       Root-Mean-Squared Error:      {metrics.RootMeanSquaredError:#.###}");
        }
        public static float TestSinglePrediction(MLContext mlContext, ITransformer model, GameData gameToPredict)
        {
            var predictionFunction = mlContext.Model.CreatePredictionEngine<GameData, GameDataPrediction>(model);

            ////Create a single GameData object to be used for predicting
            //var gameToPrecict = new GameData()
            //{
            //    OpponentId = 2,
            //    IsHome = true,
            //    IsDayAfterDay = false,
            //};
            //Make a prediction
            var prediction = predictionFunction.Predict(gameToPredict);
            return prediction.Result;
        }
        public static float PredictGame(GameData gameDataToPredict)
        {
            MLContext mlContext = new MLContext(seed: 0);

            var model = Train(mlContext, _trainDataPath);

            Evaluate(mlContext, model);

            var result = TestSinglePrediction(mlContext, model, gameDataToPredict);
            return result;
        }
    }
}
