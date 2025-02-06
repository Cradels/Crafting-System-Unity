using System;


namespace Crafting.Recipe
{
    [Serializable]
    public struct InputStack<T>
    {
        public T Item;
        public int Amount;
    }
}