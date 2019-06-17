using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using SuperHeroes.Interfaces;

namespace SuperHeroes.Implementation
{
    public class StringFileReader : IFileReader<string>
    {
        private IConfiguration _configuration;
        public List<string> fileContents;

        public StringFileReader(IConfiguration configuration)
        {
            _configuration = configuration;
            fileContents = new List<string>();
        }

        public List<string> ReadFromFile()
        {
            // Check if file contents has already been loaded
            try 
            {
                var fileLocation = _configuration.GetValue<string>("DataFileLocation");
                //Set the path to read the file from
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileLocation);
                string line;

                //Read from file and add to list
                var file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    //Dont add if line is empty
                    if (!string.IsNullOrWhiteSpace(line)) 
                    {
                        fileContents.Add(line);
                    }
                }
                file.Close();
            }
            catch (Exception e) 
            {
                throw new IOException(e.Message);
            }
            return fileContents;
        }
    }
}
