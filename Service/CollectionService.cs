using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository;
using static System.Net.Mime.MediaTypeNames;

namespace Service
{

   
        public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository _CollectionRepository;

        public CollectionService(ICollectionRepository CollectionRepository)
        {
            _CollectionRepository = CollectionRepository;
        }
        public List<Collection> Collections = new List<Collection>();

        public Collection get(string collectionSymbolization)
        {
            return _CollectionRepository.get(collectionSymbolization);


        }

        public bool post(MyImage[] images)
            {
                if (_CollectionRepository != null)
                {
                    return _CollectionRepository.post(images);
                }
                else
                {
                    Console.WriteLine("_CollectionRepository is null. Make sure it is properly initialized.");
                    return false; 
                }
            }
        public bool put(Collection collection) { return _CollectionRepository.put(collection); }  


    }

}
