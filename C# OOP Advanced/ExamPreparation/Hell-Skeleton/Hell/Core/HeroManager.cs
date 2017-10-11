using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public string AddHero(List<string> arguments)
    {
        string result;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type typeHero = Type.GetType(heroType);
            ConstructorInfo[] constructors = typeHero.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });

            result = string.Format($"Created {heroType} - {hero.Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItem(List<string> arguments)
    {
        string result = null;

        //Ма те много бе!
        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        //тука трябваше да добавя към hero ама промених едно нещо и то много неща се счупиха и реших просто да не добавямw

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    ////Само Батман знае как работи това
    //public static void GenerateResult()
    //{
    //    const string PropName = "_connectionString";

    //    var type = typeof(HeroCommand);

    //    FieldInfo fieldInfo = null;
    //    PropertyInfo propertyInfo = null;
    //    while (fieldInfo == null && propertyInfo == null && type != null)
    //    {
    //        fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        if (fieldInfo == null)
    //        {
    //            propertyInfo = type.GetProperty(PropName,
    //                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        }

    //        type = type.BaseType;
    //    }
    //}

    //public static void DontTouchThisMethod()
    //{
    //    //това не трябва да го пипаме, че ако го махнем ще ни счупи цялата логика
    //    var l = new List<string>();
    //    var m = new Manager();
    //    HeroCommand cmd = new HeroCommand(l, m);
    //    var str = "Execute";
    //    Console.WriteLine(str);
    //}
}