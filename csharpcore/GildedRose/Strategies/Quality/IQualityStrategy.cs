namespace GildedRoseKata.Strategies.Quality
{
    public interface IQualityStrategy
    {
        bool ApplyTo(Item item);
        int GetQuality(Item item);
    }
}
