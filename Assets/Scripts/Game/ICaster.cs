﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICaster
{
    bool CanCast { get; set; }
    float DamageModifier { get; set; }
}
