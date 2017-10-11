using System;
using System.Collections.Generic;

public class CoffeeMachine : ICoffeeMachine
{
    private int coins;
    public IList<CoffeeType> CoffeesSold { get; private set; }

    public CoffeeMachine()
    {
        this.CoffeesSold = new List<CoffeeType>();
    }
    
    public void BuyCoffee(string size, string type)
    {
        CoffeePrice price = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

        if ((int)price >= this.coins)
        {
            this.CoffeesSold.Add(coffeeType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin newCoin = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)newCoin;
    }
}

