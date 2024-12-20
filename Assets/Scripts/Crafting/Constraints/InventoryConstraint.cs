using System;
using System.Collections.Generic;
using Crafting.Recipe;
using UnityEngine;

public class InventoryConstraint<T> : Constraint
{
    public Func<List<T>> getPlayerInventory;
    public T requiredItem;

    public override bool IsFullfilled()
    {
        return getPlayerInventory().Contains(requiredItem);
    }
}