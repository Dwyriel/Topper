using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace Topper
{
    static class ConfigManager
    {
        private static readonly string configFolderName = "Dwyriel";
        private static readonly string configFileName = "Topper.ini";
        private static string configFilePath;
        private static string configFolderPath;

        public static readonly Configuration DefaultConfig = new Configuration();
        public static Configuration Config;
        public static bool ConfigFileExists { get { return File.Exists(configFilePath); } }

        public static void Initialize()
        {
            bool loaded = false;
            configFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), configFolderName);
            configFilePath = Path.Combine(configFolderPath, configFileName);
            if (File.Exists(configFilePath))
                loaded = Load();
            if (loaded)
                return;
            Config = DefaultConfig;
        }

        public static void Save()
        {
            try
            {
                if (!Directory.Exists(configFolderPath))
                    Directory.CreateDirectory(configFolderPath);
                FileStream outFile = File.Create(configFilePath);
                try
                {
                    XmlSerializer format = new XmlSerializer(typeof(Configuration));
                    format.Serialize(outFile, Config);
                }
                catch (Exception e)
                {
                    ErrorLogger.ShowErrorTextWithExceptionMessage($"An error occurred while saving cache to {configFilePath}", e, true);
                }
                finally
                {
                    outFile.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage($"An error occurred while saving cache to {configFilePath}", ex, true);
            }
        }

        public static bool Load()
        {
            XmlSerializer format = new XmlSerializer(typeof(Configuration));
            FileStream inFile = new FileStream(configFilePath, FileMode.Open);
            try
            {
                byte[] buffer = new byte[inFile.Length];
                inFile.Read(buffer, 0, (int)inFile.Length);
                MemoryStream stream = new MemoryStream(buffer);
                Config = (Configuration)format.Deserialize(stream);
                return true;
            }
            catch (Exception e)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage($"An error occurred while reading {configFilePath}", e, true);
                return false;
            }
            finally
            {
                inFile.Close();
            }
        }
    }

    public class Configuration
    {
        public Point StartPosition = new Point();
        public int MakeTopMostKey = 107, UnmakeTopMostKey = 109;
    }
}
