using System.Text.Json.Serialization;

class Monster : Creature
{
    public string Biome {get; set;}


    [JsonConstructor] public Monster() {}
    public Monster(string name, int level, string description, string biome) : base(name, level, description)
    {
        Biome = biome;
    }

    public override void UpdateCreature()
    {
        base.UpdateCreature();
    }

    public override string PrintCreature()
    {
        throw new NotImplementedException();
    }
}