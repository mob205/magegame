using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/DamageBuff")]
    public class ScriptableDamageBuff : ScriptableBuff
    {
        public ParticleSystem BuffParticles;
        public float DamageModifier;
        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new DamageBuff(this, obj);
        }
    }
}

