using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public enum PathType
    {
        txt,
        json
    }
    internal static class PathHalper
    {

        public static string GetPath(string filename)
        {
            
            filename.Replace(".txt", "").Replace(".json", "");

            var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyTODOFolder");
            return Path.Combine(path, filename + ".json");
        }

        internal static void Delete(string fileName)
        {

            if (File.Exists(GetPath(fileName)))
                File.Delete(GetPath(fileName));
        }
    }
}
