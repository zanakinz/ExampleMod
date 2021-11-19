using System;
using BepInEx;
using UnityEngine;


namespace ExampleMod
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)] //Required or BepInEx will not recognize plugin
    [BepInDependency("zanakinz.craftopia.CommandHandler")] //Required to use CommandHandler
    public class MyScript : BaseUnityPlugin //Make sure to always add : BaseUnityPlugin to your main script
    {
        //These are required to input into the BepInPlugin above
        public const string pluginGuid = "zanakinz.craftopia.ExampleMod"; //GUID of plugin ..  [Username].[craftopia].[Modname] is a good standard to use
        public const string pluginName = "ExampleMod"; //Plugin name
        public const string pluginVersion = "0.0.0.1"; //Plugin version

        public void Awake()
        {
            //Add Awake code if any
        }

        //We use Update() as it updates every frame
        public void Update()
        {
            String cmd = CommandHandler.CommandHandler.FinalizedText; //Gathers Information from text input
            CommandHandler.CommandHandler.ExteriorMod = true; //Tells CommandHandler theres another mod accessing it
            Commands(cmd); //Activates the Command method below
        }

        public static void Commands(string cmd)
        {
            try
            {
                //Seperates the arguments up by: (strArray[0], strArray[1], strArray[2] and so forth.  strArray[0] is always the command name, arguments are strArray[1] and up
                string cmdName = cmd.ToLower();
                string[] strArray = cmd.Split(' ');

                //Creates a command based off the info
                if (cmdName.Contains("test")) //Contains the name of the command we are looking for
                {
                    //Add code for commands
                    Debug.Log("Hello World!");
                    CommandHandler.CommandHandler.ExternalMod(); //Required at the END of all commands
                }
            }
            catch (Exception ex)
            {
                //Spit out any errors into console log
                Debug.Log(ex);
            }
        }
    }
}
