using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace UnityStandardAssets.Vehicles.Car
{
    public class LoadConfig : MonoBehaviour
    {

        private int forwardCarsCount = 12;
        private int reverseCarsCount = 6;

        // properties
        public int GetForwardCarsCount()
        {
            return forwardCarsCount;

        }

        public int GetReverseCarsCount()
        {
            return reverseCarsCount;
        }

        // Use this for initialization
        void Start()
        {
            var args = System.Environment.GetCommandLineArgs();
            Config config;

            for (int i=0; i<args.Length; i++)
            {
                Debug.Log("Comand line argument " + args[i]);
            }

            if (args.Length == 2)
            { // Runs from command line
                string configFilename = args[1];
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
            this.forwardCarsCount = config.forwardCarsCount;
            this.reverseCarsCount = config.reverseCarsCount;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}