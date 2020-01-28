using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.IsolatedStorage;
using FileManagement.FileType;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;


namespace TestProject
{
    public class HomeTeam
    {
        public string Name { get; set; }
    }

    public class AwayTeam
    {
        public string Name { get; set; }
    }

    public class Match
    {
        public string Id { get; set; }

        public string HomeTeamFinalScore { get; set; }

        public string AwayTeamFinalScore { get; set; }

        public HomeTeam HomeTeam { get; set; }

        public AwayTeam AwayTeam { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Dsv csv = new Dsv(FileManagement.CustomFile.CombinePaths(FileManagement.CustomFile.CurrentUserDesktopPath, "kişiler.csv"), ',');
            //var results = csv.Split(13, false);


            //var isolatedFile = new TextFile("kişiler", ".csv");

            ////isolatedFile.WriteLineByStreamWriter(results, isolatedFile.GetIsolatedStorageFileStream());

            //var lines = isolatedFile.ReadLineByStreamReader(csv.GetIsolatedStorageFileStream());

            //var product = new
            //{
            //    Name = "Product1",
            //    Date = DateTime.Now
            //};

            //var file = Serializer.ConvertToFile("abc", ".txt", product);

            //file.Serializer.SetSerializationType(SerializationType.JSON)
            //    .Serialize();

            //var jsonStr = file.Serializer.JsonString;

            ////var obj = JsonConvert.DeserializeObject(json);


            //var jsonFile = new TextFile(FileManagement.CustomFile.CombinePaths(FileManagement.CustomFile.CurrentUserDesktopPath, "myJson.json"));
            //jsonFile.SetSerializer();

            //var objList = jsonFile.Serializer.Deserialize<List<Match>>();

        }
    }
}
