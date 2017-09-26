using System;
using System.Collections.Generic;
using System.Text;

namespace NDAGenLib.Common
{
    public static class NDAConfig
    {
        public static string ConnectionString { get; set; }
        public static string Path { get; set; }
        public static string Type { get; set; }
        public static string PropertyPrefix { get; set; } = "";
    }
}
