using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    #region Text
    //Regex to separates sentences into words
    public static readonly string SEPARATORS_REGEX = @"(?<=[ ])";
    //For Dialog Box, speed at which the characters display one after the other (value in second per character)
    public static readonly float CHARACTER_DISPLAY_SPEED = 0.025f;
    #endregion


    #region Player Info
    //Tag of the Player. This tag MUST BE used only by the player prefab.
    public static readonly string PLAYER_TAG = "Player";

    #endregion


    #region Player Movement

    //Absolute Sensibility above which we consider the player is moving
    public static readonly float MOVEMENT_SENSIBLITY = 0.01f;
    //If the player is idle and pressing Dash Button, this will be the dash direction
    public static readonly Vector2 DEFAULT_DASH_DIRECTION = Vector2.down;

    #endregion


    #region Inventory

    //Max Stack Size for Collectibles
    public static readonly int MAX_ITEM_STACK_SIZE = 99;

    #endregion
}
