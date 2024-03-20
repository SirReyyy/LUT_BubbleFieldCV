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
    private float timer = 1.0f;
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
                SpawnBubble();
                /*
                GameObject bubble = Instantiate(bubblePrefab, Vector3.zero, Quaternion.identity);
                bubble.transform.position = transform.position + new Vector3(Random.Range(bounds_X, -bounds_X), Random.Range(bounds_Y, -bounds_Y), 0);
                bubble.transform.parent = bubbleHolder;

                bubbleCount++;
                timer = 0;
                */
            }
        }

        timer += Time.deltaTime;
    } //-- Update end

    private void SpawnBubble() {
        Vector3 spawnPosition;
        bool overlapping = true;
        int maxAttempts = 5;
        int attempts = 0;

        while (overlapping && attempts < maxAttempts) {
            spawnPosition = transform.position + new Vector3(Random.Range(-bounds_X, bounds_X), Random.Range(-bounds_Y, bounds_Y), 0);
            overlapping = CheckOverlap(spawnPosition);

            if (!overlapping) {
                GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
                bubble.transform.parent = bubbleHolder;

                bubbleCount++;
                timer = 0;
            }

            attempts++;
            Debug.Log(attempts);
        }
    } //-- SpawnPrefab end

    private bool CheckOverlap(Vector3 position) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 2.0f); // Adjust the radius as needed

        foreach (var collider in colliders) {
            if (collider.gameObject != gameObject && collider.gameObject.tag == "Bubble") {
                return true; // Overlapping with another bubble
            }
        }

        return false; // Not overlapping
    }

} //-- class end


/*
Project: 
Made by: 
*/

