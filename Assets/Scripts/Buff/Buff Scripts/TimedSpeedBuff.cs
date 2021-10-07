
using ScriptableObjects;
using UnityEngine;

public class TimedSpeedBuff : TimedBuff
{
    private readonly PlayerMovement _playerMovement;

    public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        _playerMovement = obj.GetComponent<PlayerMovement>();
    }

    protected override void ApplyEffect()
    {
        //Add speed increase to MovementComponent
        ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff) Buff;
        _playerMovement.movementSpeed *= speedBuff.SpeedModifier;
    }

    public override void End()
    {
        //Revert speed increase
        ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff) Buff;
        _playerMovement.movementSpeed /= speedBuff.SpeedModifier * EffectStacks;
        EffectStacks = 0;
    }
}
