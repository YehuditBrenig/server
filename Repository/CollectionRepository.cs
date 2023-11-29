using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using Entity;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace Repository
{
    public class CollectionRepository : ICollectionRepository

    {

        static string filePath = Path.Combine(Environment.CurrentDirectory, "NewFolder", "Collections.json");

        List<Collection> Collections = ReadCollectionFromJsonFile(filePath);

        static List<Collection> ReadCollectionFromJsonFile(string filePath)
        {
            try
            {
                string jsonText = File.ReadAllText(filePath);
                List<Collection> collectionArray = JsonConvert.DeserializeObject<List<Collection>>(jsonText);

                return collectionArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the JSON file: {ex.Message}");
                return null;
            }
        }
        public Collection get(string collectionSymbolization)

        {


            foreach (var item in Collections)
            {

                if (item != null && item.collectionSymbolization == collectionSymbolization)
                {
                    return item;
                }

            }

            return null;
        }

        public bool post(MyImage[] images)
        {

            foreach (var image in images)
            {
                object jsonData;

                if (image.ifbackImage == false)
                {

                    jsonData = new
                    {
                        collectionNmber = image.collectionNmber,
                        collectionName = image.collectionName,
                        imageNmber = image.imageNmber,
                        imageSavePath = image.imageSavePath,



                    };

                }
                else
                {
                    jsonData = new
                    {
                        collectionNmber = image.collectionNmber,
                        collectionName = image.collectionName,
                        imageNmber = image.imageNmber,
                        imageSavePath = image.imageSavePath,
                        ifBackImage = image.ifbackImage,
                        imageBackupPath = image.imageBackupPath,
                    };
                }

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.None);
                string fileName = $"{image.collectionNmber}_{image.imageNmber}.json";

                string filePath = Path.Combine(Environment.CurrentDirectory, "NewFolder", fileName);

                File.WriteAllText(filePath, json);

                Console.WriteLine($"JSON file created: {filePath}");
            }
            return true;

        }
        public bool put(Collection collection)
        {

            foreach (var item in Collections)
            {

                if (item != null && item.collectionSymbolization == collection.collectionSymbolization)
                {


                    item.quantityCollection = collection.quantityCollection;


                    File.WriteAllText(filePath, string.Empty);
                    string json = JsonConvert.SerializeObject(Collections, Newtonsoft.Json.Formatting.None);

                    File.WriteAllText(filePath, json);
                    return true;
                }

            }

            return false;
        }

    }


    
}