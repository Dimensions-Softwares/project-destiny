using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
    //Absolute Sensibility above which we consider the player is moving
    public static float MOVEMENT_SENSIBLITY = 0.01f;
    //If the player is idle and pressing Dash Button, this will be the dash direction
    public static Vector2 defaultDashDirection = Vector2.down;
    [SerializeField]
    public static Dictionary<string, WeaponData> weaponDictionary;
    public enum DIRECTIONS
    {
        NORTH = 1,
        EAST = 2,
        SOUTH = 3,
        WEST = 4
    }
}
