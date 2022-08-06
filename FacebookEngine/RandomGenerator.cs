﻿using System;
using System.Collections.Generic;

namespace FacebookEngine
{
    internal class RandomGenerator
    {
        private static Random m_Random = new Random(DateTime.Now.Second);

        internal static string GetRandomFromType(string i_Type)
        {
            string answer = null;
            switch (i_Type)
            {
                case "Name":
                    {
                        answer = generateRandomName();
                        break;
                    }

                case "Post":
                    {
                        answer = generateRandomPost();
                        break;
                    }
            }

            return answer;
        }

        private static string generateRandomName()
        {
            List<string> listOfFirstNames = new List<string> { "Sebastian", "Ethan", "Logan", "Owen", "Samuel", "Jacob", "Asher", "Aiden", "John", "Joseph", "Wyatt", "David", "Leo", 
                                                            "Luke", "Julian", "Hudson", "Grayson", "Matthew", "Ezra", "Gabriel", "Carter", "Isaac", "Weston", "Austin", "Connor", "Carson", "Dominic", "Xavier", "Jaxson", "Jace", "Emmett",
                                                            "Adam", "Declan", "Rowan", "Micah", "Kayden", "Gael", "River", "Ryder", "Kingston", "Damian", "Sawyer", "Luka", "Evan", "Vincent", "Legend",
                                                            "Myles", "Harrison", "August", "Bryson", "Amir", "Giovanni", "Chase", "Diego", "Milo", "Jasper", "Walker", "Jason", "Brayden",
                                                            "Cole", "Nathaniel", "George", "Lorenzo", "Zion", "Luis", "Archer", "Enzo", "Jonah", "Thiago", "Theo", "Ayden", "Zachary",
                                                            "Calvin", "Braxton", "Ashton", "Rhett", "Atlas", "Jude", "Bentley", "Carlos", "Ryker"
                                                        };
            List<string> listOfLastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez",
                                                                "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas" };
            return listOfFirstNames[m_Random.Next(0, listOfFirstNames.Count)] + " " + listOfLastNames[m_Random.Next(0,listOfLastNames.Count)];
        }

        public static DateTime GenerateRandomDateTime()
        {
            int randomMonth = m_Random.Next(1, 11);
            int randomDay = m_Random.Next(1, 28);
            int randomYear = m_Random.Next(1980, 2020);
            int randomHour = m_Random.Next(0, 23);
            int randomMinute = m_Random.Next(0, 59);
            int randomSecond = m_Random.Next(0, 59);
            return new DateTime(randomYear, randomMonth, randomDay, randomHour, randomMinute, randomSecond);
        }

        private static string generateRandomPost()
        {
            List<string> listOfWords = new List<string>
                                           { "abandon", "ability", "able", "beautiful", "beauty", "because", "become",
                                               "candidate", "cap", "capability", "capable", "capacity", "code", "coffee", "cognitive", "customer", "cut", "cycle", "dad",
                                               "daily", "damage", "dance", "economy", "edge", "edition", "female", "fence", "few", "garage", "garden", "garlic",
                                               "gas", "gate", "gather", "gaze", "gear", "ideal", "identification", "identify", "knock", "know", "knowledge", "lab",
                                               "label", "labor", "laboratory", "lack", "lady", "mayor", "me", "meal", "mean", "meaning", "meanwhile", "measure" };
            string randomPost = string.Empty;
            int numberOfWords = m_Random.Next(1, 15);
            for(int i = 0; i < numberOfWords; i++)
            {
                int randomWord = m_Random.Next(0, listOfWords.Count);
                randomPost += listOfWords[randomWord] + " ";
            }

            return randomPost;
        }
    }
}
