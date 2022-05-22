using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour



{
    private static GameManager instance;

    public static GameManager Instance { get => instance; private set => instance = value; }
    
    //private Queue weapons = new Queue();
    public Queue<string> Weapons{get; private set; } 
    private void Awake()
    {
        Weapons = new Queue<string>() ; 
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
}
