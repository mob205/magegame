using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuffableEntity: MonoBehaviour
{
    [SerializeField] ScriptableBuff[] startingBuffs;
    private readonly Dictionary<ScriptableBuff, TimedBuff> _buffs = new Dictionary<ScriptableBuff, TimedBuff>();
    private void Start()
    {
        foreach(var buff in startingBuffs)
        {
            AddBuff(buff.InitializeBuff(gameObject));
        }
    }
    void Update()
    {
        if (PauseMenu.IsPaused)
        {
            return;
        }
        foreach (var buff in _buffs.Values.ToList())
        {
            buff.Tick(Time.deltaTime);
            if (buff.IsFinished)
            {
                _buffs.Remove(buff.Buff);
            }
        }
    }

    public void AddBuff(TimedBuff buff)
    {
        if (_buffs.ContainsKey(buff.Buff))
        {
            _buffs[buff.Buff].Activate();
        }
        else
        {
            _buffs.Add(buff.Buff, buff);
            buff.Activate();
        }
    }
    public TimedBuff[] GetBuffs() => _buffs.Values.ToArray();
}
