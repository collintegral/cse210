using System.Text.Json.Serialization;

class Hero : Creature
{
    public List<string> Abilities {get; set;}


    [JsonConstructor] public Hero() {}
    public Hero(string name, int level, string description) : base(name, level, description)
    {}


    public override void UpdateCreature()
    {
        base.UpdateCreature();
    }

    public void UpdateAbilities()
    {

    }

    public override string PrintCreature()
    {
        throw new NotImplementedException();
    }
}