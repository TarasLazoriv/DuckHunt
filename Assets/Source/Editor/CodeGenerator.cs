using System.IO;
using UnityEditor;

namespace DuckHunt
{
    public static partial class CodeGenerator
    {
        [MenuItem("Custom/Generate Code")]
        public static void GenerateCode()
        {
            string stateName = "MyState";
            GenerateInterface(stateName);
            GenerateClass(stateName);
        }

        private static void GenerateInterface(string stateName)
        {
            string interfaceCode = $"public interface I{stateName} {{\n\t// Place your interface methods here\n}}";
            File.WriteAllText($"Assets/{stateName}Interface.cs", interfaceCode);
        }

        private static void GenerateClass(string stateName)
        {
            string classCode = $"public class {stateName} : I{stateName} {{\n\t// Place your class implementation here\n}}";
            File.WriteAllText($"Assets/{stateName}.cs", classCode);
        }
    }
}
