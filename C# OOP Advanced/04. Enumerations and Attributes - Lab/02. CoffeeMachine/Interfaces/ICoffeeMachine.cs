using System.Collections.Generic;

public interface ICoffeeMachine
{
    void BuyCoffee(string size, string type);


    void InsertCoin(string coin);

    IList<CoffeeType> CoffeesSold { get; }
}

