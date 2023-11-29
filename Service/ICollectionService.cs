using Entity;

namespace Service

{
    public interface ICollectionService
    {
        Collection get(string collectionSymbolization);

        public bool post(MyImage[] images);
      public  bool put(Collection collection);


    }
}