using System;
using BepInEx;
using BepInEx.Configuration;
using Jotunn;
using Jotunn.Managers;

namespace FurnaceConfig
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Main.ModGuid)]
    internal class FurnaceConfigPlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "org.bepinex.plugins.furnace.config";
        public const string PluginName = "FurnaceConfig";
        public const string PluginVersion = "0.1.0";

        private static ConfigEntry<int> _furnaceMaxOreInputCapacity;
        private static ConfigEntry<int> _furnaceMaxFuelInputCapacity;
        private static ConfigEntry<int> _furnaceFuelUsedPerProduct;
        private static ConfigEntry<int> _furnaceSecondsPerProduct;

        private void Awake()
        {
            const string furnaceMaxOreInputCapacityDescription = "How much ore you can put at once into the furnace.";
            _furnaceMaxOreInputCapacity = Config.Bind(PluginName, "Maximum Ore Input Capacity", 10,
                furnaceMaxOreInputCapacityDescription);

            const string furnaceMaxFuelInputCapacityDescription =
                "How much fuel (coal) you can put at once into the furnace.";
            _furnaceMaxFuelInputCapacity = Config.Bind(PluginName, "Maximum Fuel Input Capacity", 20,
                furnaceMaxFuelInputCapacityDescription);

            const string furnaceFuelPerProductDescription = "How many fuel items are consumed for one output product.";
            _furnaceFuelUsedPerProduct = Config.Bind(PluginName, "Fuel Per Product Consumption", 2,
                furnaceFuelPerProductDescription);

            const string furnaceSecondsPerProductDescription =
                "How many seconds it will take to create one output product.";
            _furnaceSecondsPerProduct = Config.Bind(PluginName, "Seconds Per Product Duration", 30,
                furnaceSecondsPerProductDescription);

            ItemManager.OnItemsRegistered += ConfigureFurnace;
        }

        private static void ConfigureFurnace()
        {
            try
            {
                var furnacePrefab = PrefabManager.Cache.GetPrefab<Smelter>("blastfurnace");
                furnacePrefab.m_maxOre = _furnaceMaxOreInputCapacity.Value;
                furnacePrefab.m_maxFuel = _furnaceMaxFuelInputCapacity.Value;
                furnacePrefab.m_fuelPerProduct = _furnaceFuelUsedPerProduct.Value;
                furnacePrefab.m_secPerProduct = _furnaceSecondsPerProduct.Value;
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while configuring furnace: {ex.Message}");
            }
            finally
            {
                ItemManager.OnItemsRegistered -= ConfigureFurnace;
            }
        }
    }
}