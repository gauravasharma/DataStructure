using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmazonOnlineAssesment;

namespace AmazonTest
{
    [TestClass]
    public class AmazonUnitTest
    {
        [TestMethod]
        public void MostFrequentWords()
        {
            var featureList = new string[]{"I wish my Kindle had even more storage.",
                "I wish the battery life on my Kindle lasted 2 years.",
                "I read in the bath and would enjoy a waterproof Kindle.",
                "waterproof and increased battery are my top two requests.",
                "I want to take my Kindle intor the shower. Waterproof please waterproof!",
                "I would be neat if my Kindle would hover on my desk when not in use.",
                "How cool would it be if my Kindle charged in the sun via solar power." };
            var possible_features = new string[] { "storage", "battery", "hover", "alexa", "waterproof", "solar" };
            int k = 2;
            var result = AmazonProblems.popularNFeatures(possible_features.Length, k, possible_features, featureList.Length, featureList);
        }

        [TestMethod]
        public void TransactionLog()
        {
            string[] input = new string[] { "345366 89921 45",
                                            "029323 38239 23",
                                            "38239 345366 15",
                                            "029323 38239 77",
                                            "345366 38239 23",
                                            "029323 345366 13",
                                            "38239 38239 23" };
            int t = 3;
            var result = AmazonProblems.TransactionLogs(input, t);
        }

        [TestMethod]
        public void RoverControl()
        {
            int n = 4;
            string[] commands = new string[] { "RIGHT", "DOWN", "LEFT", "LEFT", "DOWN" };
            var res = AmazonProblems.RoverControl(n, commands);
        }

        [TestMethod]
        public void BaseBalGameScoring()
        {
            var res = AmazonProblems.BaseBallGame(new string[] { "5", "2", "C", "D", "+" });
        }

        [TestMethod]
        public void ThrottlingGateway()
        {
            var requestTime = new int[] { 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 7, 11, 11, 11, 11 };
            var res = AmazonProblems.ThrottlingGateWay(requestTime, 27);
        }

        [TestMethod]
        public void MaxUnits()
        {
            int[][] nums = new int[4][];
            nums[0] = new int[] { 5, 10 };
            nums[1] = new int[] { 2, 5 };
            nums[2] = new int[] { 4, 7 };
            nums[3] = new int[] { 3, 9 };

            var res = AmazonProblems.MaximumUnits(nums, 10);
        }

        [TestMethod]
        public void FindNearestCities()
        {
            var res = AmazonProblems.findNearestCities(3, new string[] { "C1", "C2", "C3" }, new int[] { 3, 2, 1 }, new int[] { 3, 2, 3 }, 3, new string[] { "C1", "C2", "C3" });
        }

        [TestMethod]
        public void MultiProcessor()
        {
            var res = AmazonProblems.multiprocessorSystem(new int[] { 3, 1, 7, 2, 4 }, 5, 15);
        }

        [TestMethod]
        public void StringDivisibility()
        {
            //string s = "bcdbcdbcd";
            //string t = "bcdbcd";
            //string s = "ABABABAB";
            //string t = "ABAB";

            string s = "TAUXXTAUXXTAUXXTAUXXTAUXX";
            string t = "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX";
            var res = AmazonProblems.findSmallestDivisor(s,t);
        }

        [TestMethod]
        public void LabelingSystem()
        {
            var res = AmazonProblems.Labeling("baccc", 2);
        }

        [TestMethod]
        public void EarliestTimeToCompleteDeliveries()
        {
            var res = AmazonProblems.EarliestTimeToCompleteDeliveries(new int[] { 8, 10 }, new int[] { 2, 2, 3, 1, 8, 7, 4, 5 });
        }

        [TestMethod]
        public void LRUCacheMiss()
        {
            var res = AmazonProblems.LRUCacheMiss(new int []{1,2,1,3,1,2 },2);
        }

        [TestMethod]
        public void Dietry()
        {
            var res = AmazonProblems.DietPlanPerformance(new int[] { 3,2},2,0,1);
        }


        [TestMethod]
        public void Array()
        {
            int[][] arr = new int[4][];

            arr[0]= new int[] {0,1 };
            arr[1] = new int[] { 1, 2 };
            arr[2] = new int[] { 0, 2 };
            arr[3] = new int[] { 3,4 };
            var res = AmazonProblems.CountComponents(arr);
        }

        [TestMethod]
        public void Prisoncells()
        {
            int[] cells = new[] { 0, 1, 0, 1, 1, 0, 0, 1 };
            var res = AmazonProblems.PrisonAfterNDays(cells, 7);
        }
    }
}
