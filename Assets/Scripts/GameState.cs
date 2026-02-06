using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    private float controlSpeed;
    private bool isPaused;

    private int rep;
    private int cash;
    private int upTime;
    private int netData;
    private int roundNum;
    
    private string map;
    private float speed;
    private bool singlePath;
    private string access;
    private string connection;
    private bool penTest;
    
    private string hero;
    // just towerInfo script to manage which towers are unlocked (make another instance of the script in this scene)
    
    public GameState()
    {
        controlSpeed = 1.0f;
        isPaused = false;
        roundNum = 1;
        upTime = 0;
        

        map = "Bus"; // Change to get map type from external script
        speed = 1.0f; 
        
    }
    
    
    // modifiers
    
    
    // game controls
    // public float Speed;
    // public bool IsPaused;
    //
    //
    // public int RoundNum;
    
}
