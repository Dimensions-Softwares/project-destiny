using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "My Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public AnimationClip frontAttack;
    public AnimationClip backAttack;
    public AnimationClip leftAttack;
    public AnimationClip rightAttack;
    public AnimationClip upLeft;
    public AnimationClip upRight;
    public AnimationClip downLeft;
    public AnimationClip downRight;

}
