using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace UnityStandardAssets.Vehicles.Car
{
    public class LoadConfig : MonoBehaviour
    {

        private Config config;

        // properties
        public int GetForwardCarsCount()
        {
            return config.forwardCarsCount;
        }

        public int GetReverseCarsCount()
        {
            return config.reverseCarsCount;
        }

        public float GetDMin()
        {
            return config.d_min;
        }

        public float GetDMax()
        {
            return config.d_max;
        }

        public int GetZeroSpeedInterval()
        {
            return config.zero_speed_interval;
        }


        public float GetDistanceWithoutIncident()
        {
            return config.dist_without_incident;
        }


        public float GetMaximumDistance()
        {
            return config.dist_max;
        }

        // Use this for initialization
        void Awake()
        {
            // load configuration file
            string configFilename = Environment.GetEnvironmentVariable("CONFIG_FILE");
            if (configFilename!=null)
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
            // load configuration file
            string configFilename = Environment.GetEnvironmentVariable("CONFIG_FILE");
            Config config = new Config();

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
            }
            return config;
        }


    }
}