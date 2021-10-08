using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/ImmobileBuff")]
    public class ScriptableImmobileBuff : ScriptableBuff
    {
        public ParticleSystem ImmobilizedParticles;
        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new ImmobileBuff(this, obj);
        }
    }
}

