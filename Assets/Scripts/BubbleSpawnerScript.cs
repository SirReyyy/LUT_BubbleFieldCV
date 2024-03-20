using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawnerScript : MonoBehaviour
{
    private Singleton _singletonManager;
    public GameObject bubblePrefab;
    public Transform bubbleHolder;

    private int bubbleCount = 0, maxCount = 20;
    private float bounds_X = 7.5f, bounds_Y = 3.5f;
    private float timer = 3.0f;
    public float maxTime = 5.0f;

    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end

    void FixedUpdate() {
        // if(_singletonManager.gameState != Singleton.GameState.PlayState)
        //      return;
        // }

        if (timer > maxTime) {
            if (bubbleCount < maxCount) {
                GameObject bubble = Instantiate(bubblePrefab, Vector3.zero, Quaternion.identity);
                bubble.transform.position = transform.position + new Vector3(Random.Range(bounds_X, -bounds_X), Random.Range(bounds_Y, -bounds_Y), 0);
                bubble.transform.parent = bubbleHolder;

                bubbleCount++;
                timer = 0;
            }
        }
        timer += Time.deltaTime;
    } //-- Update end

} //-- class end


/*
Project: 
Made by: 
*/

