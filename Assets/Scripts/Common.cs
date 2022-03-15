using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
    //Absolute Sensibility above which we consider the player is moving
    public static float MOVEMENT_SENSIBLITY = 0.01f;

    //If the player is idle and pressing Dash Button, this will be the dash direction
    public static Vector2 defaultDashDirection = Vector2.down;
}
