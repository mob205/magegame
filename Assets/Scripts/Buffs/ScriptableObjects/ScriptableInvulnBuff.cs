using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/InvulnerableBuff")]
    public class ScriptableInvulnBuff : ScriptableBuff
    {
        public ParticleSystem InvulnerableParticles;
        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new InvulnerableBuff(this, obj);
        }
    }
}

