using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/DefenseBuff")]
    public class ScriptableDefenseBuff : ScriptableBuff
    {
        public float DefenseModifier;

        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new DefenseBuff(this, obj);
        }
    }
}
