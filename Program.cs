namespace GA_HashTable_Ronda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, string> favoriteArtist = new HashTable<string, string>();
            favoriteArtist.Add("Henry", "Deino");
            favoriteArtist.Add("Daniel", "AC/DC");


            Console.WriteLine(favoriteArtist.Get("Daniel"));
        }
    }
}
