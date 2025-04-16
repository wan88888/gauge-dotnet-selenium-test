using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebAutomation.Framework.Config
{
    public static class ConfigurationManager
    {
        private static readonly Dictionary<string, string> _configCache = new Dictionary<string, string>();
        private const string DefaultConfigPath = "env/default/driver.properties";
        
        static ConfigurationManager()
        {
            LoadConfig();
        }
        
        public static string GetString(string key, string defaultValue = "")
        {
            if (_configCache.TryGetValue(key, out var value))
            {
                return value;
            }
            
            return Environment.GetEnvironmentVariable(key) ?? defaultValue;
        }
        
        public static bool GetBool(string key, bool defaultValue = false)
        {
            var stringValue = GetString(key);
            return !string.IsNullOrEmpty(stringValue) ? Convert.ToBoolean(stringValue) : defaultValue;
        }
        
        public static int GetInt(string key, int defaultValue = 0)
        {
            var stringValue = GetString(key);
            return !string.IsNullOrEmpty(stringValue) ? Convert.ToInt32(stringValue) : defaultValue;
        }
        
        private static void LoadConfig()
        {
            try
            {
                var configPath = Path.Combine(Directory.GetCurrentDirectory(), DefaultConfigPath);
                if (File.Exists(configPath))
                {
                    var lines = File.ReadAllLines(configPath);
                    
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                            continue;
                            
                        var parts = line.Split('=', 2);
                        if (parts.Length == 2)
                        {
                            var key = parts[0].Trim();
                            var value = parts[1].Trim();
                            _configCache[key] = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
            }
        }
        
        public static void ReloadConfig()
        {
            _configCache.Clear();
            LoadConfig();
        }
    }
} 