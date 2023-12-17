using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "ScriptableObject/Player")]
public class PlayerStatSO : ScriptableObject
{
    public float speedBuff = 1;
    public float jumpHeightBuff = 1;
    public bool isDead = false;
}
