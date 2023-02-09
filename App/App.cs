namespace App
{
    public partial class Program
    {
        public static partial void PrintFileContents(string path_to_file);
        public static partial void CreateFile(string path_to_file);
        public static partial void AppendtoFile(string path_to_file, string text);
        public static partial void ReplaceFileContents(string path_to_file, string text);
        public static partial void SortinFile(string path_to_file);
        public static void Main(string[] args)
        {
            CreateFile("plik.txt");
            AppendtoFile("plik.txt","Witaj Kuba");
            PrintFileContents("plik.txt");
            //AppendtoFile("plik.txt","Dodano poprawnie");
            PrintFileContents("plik.txt");
            ReplaceFileContents("plik.txt","5 2 1 0 6 34 2 53 56 231");
            PrintFileContents("plik.txt");
            SortinFile("plik.txt");
            PrintFileContents("plik.txt");
        }
        
    }
}