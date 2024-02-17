using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Hero), typeDiscriminator: "hero")]
[JsonDerivedType(typeof(Monster), typeDiscriminator: "monster")]
[JsonDerivedType(typeof(Npc), typeDiscriminator: "npc")]

abstract class Creature
{
    public string Name {get; set;}
    public int Level {get; set;}
    public string Description {get; set;}
    public List<KeyItem> KeyItems {get; set;}


    [JsonConstructor] public Creature() {}
    public Creature(string name, int level, string description)
    {
        Name = name;
        Level = level;
        Description = description;
    }

    public void AddItem(KeyItem item)
    {
        KeyItems.Add(item);
    }

    public void TakeItem()
    {

    }

    public virtual void UpdateCreature()
    {

    }

    public virtual string PrintCreature()
    {
        return null;
    }
}