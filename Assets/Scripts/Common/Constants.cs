using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{

    #region Player Movement

    //Absolute Sensibility above which we consider the player is moving
    public static float MOVEMENT_SENSIBLITY = 0.01f;
    //If the player is idle and pressing Dash Button, this will be the dash direction
    public static Vector2 DEFAULT_DASH_DIRECTION = Vector2.down;

    #endregion


    #region Inventory

    //Max Stack Size for Collectibles
    public static int MAX_ITEM_STACK_SIZE = 99;

    #endregion
}
