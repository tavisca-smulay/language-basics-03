using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });

            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static List<int> CalculateMax(int[] nutrientArray, List<int> indexArray)
        {
            List<int> temp = new List<int>();
            int maxElement = 0;
            if (indexArray.Count() == nutrientArray.Count())
            {
                maxElement = nutrientArray.Max();
            }
            else
            {
                List<int> tieBreaker = new List<int>();
                for (var a = 0; a < indexArray.Count(); a++)
                {
                    tieBreaker.Add(nutrientArray[indexArray[a]]);
                }
                maxElement = tieBreaker.Max();
            }
            for (var i = 0; i < indexArray.Count(); i++)
            {
                if (nutrientArray[indexArray[i]].Equals(maxElement))
                {
                    temp.Add(indexArray[i]);
                }
            }
            return temp;
        }
        public static List<int> CalculateMin(int[] nutrientArray, List<int> indexArray)
        {
            List<int> temp = new List<int>();
            int minElement = 0;
            if (indexArray.Count() == nutrientArray.Count())
            {
                    minElement = nutrientArray.Min();
            }
            else {
                List<int> tieBreaker = new List<int>();
                for (var a = 0; a < indexArray.Count(); a++) {
                    tieBreaker.Add(nutrientArray[indexArray[a]]);
                }
                minElement = tieBreaker.Min();
            }
            for (var i = 0; i < indexArray.Count(); i++)
            {
                if (nutrientArray[indexArray[i]].Equals(minElement))
                {
                    temp.Add(indexArray[i]);
                }
            }
            return temp;
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            var noOfDishes = protein.Length;
            int[] calorie = new int[noOfDishes];

            for (var i = 0; i < noOfDishes; i++)
            {
                calorie[i] = (protein[i] + carbs[i]) * 5 + fat[i] * 9;
            }

            int[] selectedMenu = new int[dietPlans.Length];

            for (var i = 0; i < dietPlans.Length; i++)
            {
                List<int> indexArray = new List<int>();
                for (var j = 0; j < protein.Length; j++)
                    indexArray.Add(j);

                for (var k = 0; k < dietPlans[i].Length; k++)
                {
                   if (dietPlans[i][k] == 'C')
                            indexArray = CalculateMax(carbs, indexArray);
                        else if (dietPlans[i][k] == 'c')
                            indexArray = CalculateMin(carbs, indexArray);
                        else if (dietPlans[i][k] == 'P')
                            indexArray = CalculateMax(protein, indexArray);
                        else if (dietPlans[i][k] == 'p')
                            indexArray = CalculateMin(protein, indexArray);
                        else if (dietPlans[i][k] == 'F')
                            indexArray = CalculateMax(fat, indexArray);
                        else if (dietPlans[i][k] == 'f')
                            indexArray = CalculateMin(fat, indexArray);
                        else if (dietPlans[i][k] == 'T')
                            indexArray = CalculateMax(calorie, indexArray);
                        else if (dietPlans[i][k] == 't')
                            indexArray = CalculateMin(calorie, indexArray);
                   
                    if (indexArray.Count == 1)
                    {
                        selectedMenu[i] = indexArray[0];
                        break;
                    }
                }

                if (indexArray.Count > 1)
                    selectedMenu[i] = indexArray[0];

            }

            return selectedMenu;
            //throw new NotImplementedException();
        }
    }
}