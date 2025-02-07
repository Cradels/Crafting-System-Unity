using UnityEngine;

namespace Crafting.Recipe
{
    public class Constraint : ScriptableObject
    {
        public virtual bool IsFullfilled()
        {
            return true;
        }
    }
}