using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; protected set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        protected set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        protected set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        protected set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        protected set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        protected set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; } // possible bug
    }

    public long SecondaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; } // possible bug
    }

    //REFLECTION
    public ICollection<IItem> Items { get; }

    public void AddRecipe(Recipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }
    
    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        int primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }
}