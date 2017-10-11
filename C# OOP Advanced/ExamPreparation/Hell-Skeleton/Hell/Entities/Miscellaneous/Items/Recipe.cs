using System.Collections.Generic;

public class Recipe : AbstractItem, IRecipe
{
    public Recipe(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, 
        long hitPointsBonus, long damageBonus) 
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
    }

    public List<string> RequiredItems { get; protected set; }
}

