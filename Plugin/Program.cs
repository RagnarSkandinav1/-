using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Plugin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var json = await File.ReadAllTextAsync("../../../appsettings.json");
            var configuration = JsonConvert.DeserializeObject<Configuration>(json);
            var path = configuration?.RootFolderPath;

            var pluginSystem = new PluginSystem();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - List of plugins");
                Console.WriteLine("2 - Load the specified plugin and invoke its methods.");
                Console.WriteLine("3 - Exit");
                var t = int.Parse(Console.ReadLine() ?? string.Empty);
                switch (t)
                {
                    case 1:
                        {
                            Console.Clear();
                            var plugins = pluginSystem.GetPlugins(path);
                            Console.WriteLine("All plugins");
                            Console.WriteLine("Plugin Name \t ClassTypeName \t DllFilePath");
                            plugins.ForEach(plugin => Console.WriteLine(plugin.Name + ' ' + plugin.ClassType.Name + ' ' + plugin.DllFilePath));
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Input plugin name: ");
                        var pluginName = Console.ReadLine();
                        pluginSystem.InvokePluginMethods(path, pluginName);
                        Console.ReadKey();
                        break;
                    }
                    case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("\tGood bye!");
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }
    }
}
