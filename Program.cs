using System;
using System.Collections.Generic;

namespace TechJobsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two Dictionary vars to hold info for menu and data

            // Top-level menu options
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");

            // Column options
            Dictionary<string, string> columnChoices = new Dictionary<string, string>();
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");

            Console.WriteLine("Welcome to LaunchCode's TechJobs App!");

            // Allow user to search/list until they manually quit with ctrl+c
            while (true)
            {

                string actionChoice = GetUserSelection("View Jobs", actionChoices);

                if (actionChoice.Equals("list"))
                {
                    string columnChoice = GetUserSelection("List", columnChoices);

                    if (columnChoice.Equals("all"))
                    {
                        PrintJobs(JobData.FindAll());
                    }
                    else
                    {
                        List<string> results = JobData.FindAll(columnChoice);

                        Console.WriteLine("\n*** All " + columnChoices[columnChoice] + " Values ***");
                        foreach (string item in results)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else // choice is "search"
                {
                    // How does the user want to search (e.g. by skill or employer)
                    string columnChoice = GetUserSelection("Search", columnChoices);

                    // What is their search term?
                    Console.WriteLine("\nSearch term: ");
                    string searchTerm = Console.ReadLine();

                    List<Dictionary<string, string>> searchResults;

                    // Fetch results
                    if (columnChoice.Equals("all"))
                    {
                        Console.WriteLine("Search all fields not yet implemented.");
                    }
                    else
                    {
                        searchResults = JobData.FindByColumnAndValue(columnChoice, searchTerm);
                        PrintJobs(searchResults);
                    }
                }
            }
        }

        /*
         * Returns the key of the selected item from the choices Dictionary
         */
        private static string GetUserSelection(string choiceHeader, Dictionary<string, string> choices)
        {
            int choiceIdx;
            bool isValidChoice = false;
            string[] choiceKeys = new string[choices.Count];

            int i = 0;
            foreach (KeyValuePair<string, string> choice in choices)
            {
                choiceKeys[i] = choice.Key;
                i++;
            }

            do
            {
                Console.WriteLine("\n" + choiceHeader + " by:");

                for (int j = 0; j < choiceKeys.Length; j++)
                {
                    Console.WriteLine(j + " - " + choices[choiceKeys[j]]);
                }

                string input = Console.ReadLine();
                choiceIdx = int.Parse(input);

                if (choiceIdx < 0 || choiceIdx >= choiceKeys.Length)
                {
                    Console.WriteLine("Invalid choices. Try again.");
                }
                else
                {
                    isValidChoice = true;
                }

            } while (!isValidChoice);

            return choiceKeys[choiceIdx];
        }

        private static void PrintJobs(List<Dictionary<string, string>> someJobs)
        {

            // create list called headers
            List<string> headers = new List<string>();
            List<string> itemKey = new List<string>();
            List<string> itemValue = new List<string>();
            int i=0;

            // create dictionary with strings called row
            Dictionary<string, string> row = someJobs[i];
            
            for(i=0; i<someJobs.Count; i++)
            { 
                row = someJobs[i];

                // loop through the row dictionary 
                foreach(KeyValuePair<string, string> jobSet in row)
                {                                               
                    // add each key in row dictionary to headers       
                    headers.Add(jobSet.Key);                    
                }

                foreach(KeyValuePair<string, string> jobSet in row)
                {
                    
                }

                // loop through the row dictionary
                foreach(KeyValuePair<string, string> jobSet in row)
                {
                    // add each value in row dictionary to itemValue
                    itemValue.Add(jobSet.Value);
                }

                break;  
            }

            for(i=0; i<someJobs.Count; i++)
            {
                if(i<someJobs.Count){
                // loop through the list headers 
                foreach(string word in headers)
                {
                    // display the words in list headers
                    Console.WriteLine(word);
                }

                // loop through the list itemValue
                /*foreach(string word in itemValue)
                {
                    // display the words in list itemValue
                    Console.WriteLine(word);
                }*/
            } }
        } 



    }
}