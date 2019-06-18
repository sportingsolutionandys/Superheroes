using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SuperHeroes.Interfaces;

namespace SuperHeroes.Implementation
{
    /// <summary>
    /// String file reader.
    /// This class reads the contents of the file from the specified location
    /// </summary>
    public class StringFileReader : IFileReader<string>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly string FILE_LOCATION_CONFIG = "DataFileLocation";

        public StringFileReader(IConfiguration configuration, ILogger<StringFileReader> logger)
        {
            _configuration = configuration;
            _logger = logger;

        }

        /// <summary>
        /// Reads from file.
        /// </summary>
        /// <returns>The from file.</returns>
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
                _logger.LogInformation("Contents of file successfully read");
            }
            catch (Exception e) 
            {
                // Log file reader exception
                _logger.LogWarning(e.Message);
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
