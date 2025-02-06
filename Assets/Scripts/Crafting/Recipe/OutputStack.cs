using System;
namespace Crafting.Recipe
{
[Serializable]
    public struct OutputStack<T>
    {
        public T Item;
        public int Amount;
        public float SkillValue;
    }
}