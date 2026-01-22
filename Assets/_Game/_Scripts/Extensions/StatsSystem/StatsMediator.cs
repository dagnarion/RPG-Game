using System;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class StatsMediator
{
    private readonly LinkedList<StatsModifier> modifiers = new LinkedList<StatsModifier>();
    public event EventHandler<Query> Queries;
    public void PerformQuery(object sender, Query query) => Queries?.Invoke(sender, query);

    public void AddModifier(StatsModifier modifier)
    {
        modifiers.AddLast(modifier);
        Queries += modifier.Handle;
    }

    public void Update(float deltaTime)
    {
        var node = modifiers.First;
        while (node != null)
        {
            var modifier = node.Value;
            modifier.Update(deltaTime);
            node = node.Next;
        }

        node = modifiers.First;
        while (node != null)
        {
            var nextNode = node.Next;
            if (node.Value.MarkedForRemoval)
            {
                modifiers.Remove(node);
                node.Value.Dispose();
            }

            node = nextNode;
        }
    }
    
}

public class Query
{
    public readonly StatType StatType;
    public int Value;

    public Query(StatType statType,int value)
    {
        StatType = statType;
        Value = value;
    }
}

/*
 tôi khong hiểu gì cả SOS =))
 */

