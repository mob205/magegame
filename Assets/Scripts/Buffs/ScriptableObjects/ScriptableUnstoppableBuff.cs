using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/UnstoppableBuff")]
    public class ScriptableUnstoppableBuff : ScriptableBuff
    {
        public ScriptableBuff[] ImmobilizationBuffs;
        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new UnstoppableBuff(this, obj);
        }
    }
}