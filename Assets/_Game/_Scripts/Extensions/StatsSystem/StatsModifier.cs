using System;
using System.Collections.Generic;

public abstract class StatsModifier : IDisposable
{
    public bool MarkedForRemoval { get; private set; }
    public event Action<StatsModifier> OnDispose = delegate { };
    public abstract void Handle(object sender,Query query);

    private readonly CountdownTimer timer;

    protected StatsModifier(float duration)
    {
        if(duration <=0) return;
        timer = new CountdownTimer(duration);
        timer.OnTimerStop += Dispose;
    }
    
    public void Update(float deltaTime) => timer?.Tick(deltaTime);
    
    
    public void Dispose()
    {
        MarkedForRemoval = true;
        OnDispose?.Invoke(this);
    }
}

public class BasicStatModifier : StatsModifier
{
    private readonly StatType type;
    private readonly Func<int, int> operation;
    public BasicStatModifier(StatType type,float duration,Func<int,int> operation) : base(duration)
    {
        this.type = type;
        this.operation = operation;
    }

    public override void Handle(object sender, Query query)
    {
        if (query.StatType == type)
        {
            query.Value = operation(query.Value);
        }
    }
}