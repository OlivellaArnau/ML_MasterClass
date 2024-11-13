using System;
using MyFirstMLModel_ConsoleApp1;
using Test_ML;

namespace MyFirstMLModel_ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Benvingut a l'aplicació de sentiment prediction!\n");

            // Demana el text de l'usuari
            Console.Write("Introdueix el text del sentiment: ");
            string sentimentText = Console.ReadLine();

            // Demana l'estat de connexió de l'usuari (LoggedIn)
            Console.Write("Estàs connectat? (sí/no): ");
            string loggedInInput = Console.ReadLine().Trim().ToLower();
            bool isLoggedIn = loggedInInput == "sí";

            // Crea un objecte ModelInput amb les dades introduïdes per l'usuari
            var input = new MyFirstMLModel.ModelInput
            {
                SentimentText = sentimentText,
                LoggedIn = isLoggedIn
            };

            // Realitza la predicció utilitzant el mètode Predict
            var prediction = MyFirstMLModel.Predict(input);

            // Mostra el resultat de la predicció
            Console.WriteLine($"\nPredicció del Sentiment: {prediction.PredictedLabel}");
            Console.WriteLine("Scores per cada classe:");

            // Mostra els scores per cada etiqueta de sentiment
            var scores = MyFirstMLModel.GetSortedScoresWithLabels(prediction);
            foreach (var score in scores)
            {
                Console.WriteLine($"Sentiment: {score.Key}, Score: {score.Value}");
            }
        }
    }
}
