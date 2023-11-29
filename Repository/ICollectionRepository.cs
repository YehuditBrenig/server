using Entity;

namespace Repository
{
    public interface ICollectionRepository
    {
        public Collection get(string collectionSymbolization);

        bool post(MyImage[] images);
        bool put(Collection collection);

    }


}