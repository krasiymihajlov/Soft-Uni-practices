public abstract class Monument
{
    private string name;

    public Monument(string name)
    {
        this.name = name;
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        string monumentType = this.GetType().Name;
        int index = monumentType.IndexOf("Monument");
        monumentType = monumentType.Insert(index, " ");
        return $"{monumentType}: {this.name}";
    }
}

