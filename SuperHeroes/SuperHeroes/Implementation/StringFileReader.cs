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
        private readonly string FILE_LOCATION_CONFIG = "DataFileLocation";

        public StringFileReader(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public List<string> ReadFromFile()
        {
            var fileContents = new List<string>();

            var fileLocation = _configuration.GetValue<string>(FILE_LOCATION_CONFIG);

            //Set the path to read the file from
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileLocation);

            //Read from file and add to list
            string line;
            var file = new System.IO.StreamReader(path);
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    //Dont add if line is empty
                    if (!string.IsNullOrWhiteSpace(line)) 
                    {
                        fileContents.Add(line);
                    }
                }
            }
            catch (Exception e) 
            {
                // Log file reader exception
                throw new IOException(e.Message);
            }
            finally
            {
                // close the file connection
                if (file != null)
                {
                    file.Close();
                }
            }
            return fileContents;
        }
    }
}
