using Microsoft.CodeAnalysis;

namespace FunctionGenerator
{
    [Generator]
    public class Program: ISourceGenerator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Generator test");
        }
        public void Execute(GeneratorExecutionContext context)
        {
            // Find the main method
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);

            // Build up the source code
            string source = 
                $@"// <Kod wygenerowany do zarządzania plikami/>
using System;
namespace {mainMethod.ContainingNamespace.ToDisplayString()}
{{
    public static partial class {mainMethod.ContainingType.Name}
    {{
        public static partial void CreateFile(string path_to_file)
        {{  
            using (FileStream fs = File.Create(path_to_file));
        }}
        public static partial void PrintFileContents(string path_to_file)
        {{
            var file = File.ReadAllText(path_to_file);
            Console.WriteLine(file);
        }}
        public static partial void AppendtoFile(string path_to_file, string text)
        {{
            File.AppendAllText(path_to_file,text);
        }}
        public static partial void ReplaceFileContents(string path_to_file, string text)
        {{
            File.WriteAllText(path_to_file,text);
        }}
        static List<int> SortArray(List<int> array, int leftIndex, int rightIndex)
        {{
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {{
                while (array[i] < pivot)
                {{
                    i++;
                }}
        
                while (array[j] > pivot)
                {{
                    j--;
                }}
                if (i <= j)
                {{
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }}
            }}
    
            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
        }}
        public static partial void SortinFile(string path_to_file)
        {{
            string[] numbers = File.ReadAllText(path_to_file).Split(' ');
            List<int> int_numbers = new List<int>();
            foreach(string number in numbers)
            {{
                int int_number = int.Parse(number);
                int_numbers.Add(int_number);
            }}
            int_numbers=SortArray(int_numbers,0,int_numbers.Count-1);
            ReplaceFileContents(path_to_file, """");
            foreach(int number in int_numbers)
            {{
                string numbertoString = number.ToString();
                AppendtoFile(path_to_file,numbertoString+"" "");
            }}
        }}
    }}
    
}}
";
            var typeName = mainMethod.ContainingType.Name;

            // Add the source code to the compilation
            context.AddSource($"{typeName}.g.cs", source);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}