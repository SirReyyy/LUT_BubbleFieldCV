using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenHitScript : MonoBehaviour
{
    private Singleton _singletonManager;
    public GameObject gameObj;

    int shotCount;
    bool shotAllowed = true, shotFired = false;

    void Start() {
        _singletonManager = Singleton.Instance;
        shotCount = _singletonManager.shotsRemaining;
    } //-- start end


    void Update() {
        // CheckShotCount();
        MouseShot();
    } //-- Update end

    public void CheckShotCount(){
        if(shotCount > 0 && shotCount <= 3) {
            shotAllowed = true;
        } else if (shotCount == 0) {
            shotAllowed = false;
            Invoke("ShotReload", 1.0f);
        }
    } //-- CheckShotCount

    public void MouseShot() {
        if (shotAllowed && !shotFired) {
            if (Input.GetMouseButton(0)) {
                shotCount--;
                _singletonManager.shotsRemaining = shotCount;
                shotFired = true;

                CheckHit();
                Invoke("ShotDelay", 2.0f);
            }
        }
    } //-- MouseShot end

    public void ShotDelay() {
        shotFired = false;
        CheckShotCount();
    } //-- ShotDelay end

    public void ShotReload() {
        _singletonManager.shotsRemaining = 3;
        shotCount = _singletonManager.shotsRemaining;
        shotAllowed = true;
    } //-- ShotReload end

    public void CheckHit() {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(worldPos.x, worldPos.y);

        if(GetComponent<Collider2D>() != Physics2D.OverlapPoint(mousePos)) {
            gameObj = Physics2D.OverlapPoint(mousePos).gameObject;
            
            if(gameObj.name == "Asteroid(Clone)") {
                _singletonManager.currentScore += 5;
                Destroy(gameObj);
            }

            if(gameObj.tag == "Asteroid") {
                _singletonManager.currentScore += 5;
                Destroy(gameObj);
            }
        }
    } //-- CheckHit

} //-- class end


/*
Project: 
Made by: 
*/

