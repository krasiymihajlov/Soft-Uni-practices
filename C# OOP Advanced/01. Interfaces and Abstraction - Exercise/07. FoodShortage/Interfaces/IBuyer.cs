namespace _07.FoodShortage.Interfaces
{
    public interface IBuyer
    {
        string Name { get; }

        int Food { get; }
        int BuyFood();
    }
}
