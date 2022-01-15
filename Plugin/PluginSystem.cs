using System;
using SharedAttribute;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Plugin
{
    public class PluginSystem
    {
        public List<Plugin> GetPlugins(string pluginsFolderPath)
        {
            var directory = new DirectoryInfo(pluginsFolderPath);
            var dllFiles = directory.GetFiles("*.dll").ToList();
            var allPlugins = new List<Plugin>();
            dllFiles.ForEach(dllFile =>
            {
                var dllFilePath = Path.Combine(pluginsFolderPath, dllFile.Name).ToString();
                var assembly = Assembly.LoadFile(dllFilePath);
                var types = assembly.GetTypes().ToList();
                var plugins = types.Where(type =>
                {
                    var isPlugin = type.GetCustomAttributes().Any(attribute => attribute is PluginAttribute);
                    return isPlugin;
                }).Select(type =>
                {
                    var pluginAttribute = (PluginAttribute) Attribute.GetCustomAttribute(type, typeof(PluginAttribute));
                    return new Plugin
                    {
                        Name = pluginAttribute?.Name,
                        ClassType = type,
                        DllFilePath = dllFilePath
                    };
                });
                allPlugins.AddRange(plugins);
            });

            return allPlugins;
        }

        public void InvokePluginMethods(string pluginsFolderPath, string pluginName)
        {
            var plugins = GetPlugins(pluginsFolderPath);
            foreach (var plugin in plugins)
            {
                if (plugin.Name != pluginName)
                {
                    continue;
                }

                var ctor = plugin.ClassType.GetConstructors()[0];
                var obj = ctor.Invoke(null);
                obj.GetType().GetMethods(BindingFlags.DeclaredOnly |
                                         BindingFlags.Public |
                                         BindingFlags.Instance).ToList().ForEach(method =>
                {
                    method.Invoke(obj, null);
                });
            }
        }
    }
}