﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace UnityStandardAssets.Vehicles.Car
{
    public class LoadConfig : MonoBehaviour
    {

        static readonly Config config;

        static LoadConfig()
        {
            // load configuration file
            string configFilename = Environment.GetEnvironmentVariable("CONFIG_FILE");
            if (configFilename != null)
            {
                Debug.Log("Loading configuration from file " + configFilename);
                if (System.IO.File.Exists(configFilename))
                {
                    string fileContent = System.IO.File.ReadAllText(configFilename);
                    config = JsonUtility.FromJson<Config>(fileContent);
                }
                else
                {
                    config = new Config();
                    Debug.LogError("Config file " + configFilename
                        + " does not exists. A file with default values will be created!");
                    string fileContent = JsonUtility.ToJson(config);
                    using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(configFilename))
                    {
                        outputFile.WriteLine(fileContent);
                    }
                }
            }
            else
            {
                Debug.LogWarning("No configuration file provided, using default values!");
                config = new Config();
            }
        }


        public static Config GetConfig()
        {
           return config;
        }


    }
}