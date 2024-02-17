using System.Text.Json.Serialization;

class Npc : Creature
{
    [JsonConstructor] public Npc() {}
    public Npc(string name, int level, string description) : base(name, level, description)
    {}


    public override void UpdateCreature()
    {
        base.UpdateCreature();
    }
    
    public override string PrintCreature()
    {
        throw new NotImplementedException();
    }
}