public enum StatType
{
    Attack,Defense
}

public class Stats
{
    private readonly StatsMediator mediator;
    private readonly BaseStats baseStats;
    public StatsMediator Mediator => mediator;
    public int Attack
    {
        get
        {
            var q = new Query(StatType.Attack, baseStats.Attack);
            mediator.PerformQuery(this,q);
            return q.Value;
        }
    }

    public int Defense
    {
        get
        {
            var q = new Query(StatType.Defense, baseStats.Defense);
            mediator.PerformQuery(this,q);
            return q.Value;
        }
    }

    public Stats(StatsMediator mediator,BaseStats baseStats)
    {
        this.mediator = mediator;
        this.baseStats = baseStats;
    }

    public override string ToString() => $"Attack: { Attack }, Defense : {Defense} ";

}