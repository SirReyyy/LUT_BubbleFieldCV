using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    public enum GameState
    {
        TitleState,
        PlayState,
        ScoreState
    }
    [HideInInspector]
    public GameState gameState = GameState.TitleState;
    [HideInInspector]
    public string player_rfid_serial_number = "";
    [HideInInspector]
    public int currentScore = 0;
    [HideInInspector]
    public int minimumScore, maximumScore = 3000;
    [HideInInspector]
    public bool tapEnabled = true, isLoggedIn = false;

    [HideInInspector]
    public float currentHealth = 100.0f;
    [HideInInspector]
    public int shotsRemaining = 3;


    public static Singleton Instance {
        get { return instance; }
    } //-- Singleton Instance end

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    } //-- Awake end

} //-- class end


/*
Project: 
Made by: 
*/

