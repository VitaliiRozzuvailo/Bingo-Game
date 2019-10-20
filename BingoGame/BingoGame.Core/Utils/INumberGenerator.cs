namespace BingoGame.Core.Utils
{
    public interface INumberGenerator
    {
        int Generate();
        int Generate(int min, int max);
    }
}
