using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private Singleton _singletonManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // private Rigidbody2D rbody;

    private float elapsedTime; //, rotSpeed;
    private float targetScale, scaleSpeed = 0.5f;
    private float minTargetScale = 0.8f, maxTargetScale = 1.2f;
    private float floatHeight, floatSpeed, floatPause = 0.1f;
    private bool isMoving = false;

    private Vector3 originalPosition;

    void Awake() {
        floatHeight = Random.Range(0.5f, 1.0f);
        floatSpeed = Random.Range(0.2f, 0.5f);
        targetScale = Random.Range(minTargetScale, maxTargetScale);
    } //-- Awake end

    void Start(){
        _singletonManager = Singleton.Instance;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Color randomColor = new Color(Random.value, Random.value, Random.value);
        spriteRenderer.color = randomColor;

        originalPosition = transform.position;
        // rbody = GetComponent<Rigidbody2D>();
        // rotSpeed = Random.Range(0, 2) * 2 - 1;

        StartCoroutine(ScaleCoroutine());
    } //-- Start end

    void Update() {
        if (isMoving) {
            elapsedTime += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Sin(elapsedTime * Mathf.PI * floatSpeed) * floatHeight + originalPosition.y, transform.position.z);
            // transform.position = new Vector3(transform.position.x, Mathf.Sin(elapsedTime * floatSpeed) * floatHeight, transform.position.z);
        }
    } //-- Update end

    IEnumerator ScaleCoroutine() {
        float currentScale = 0.1f;
        while (currentScale < targetScale) {
            currentScale += scaleSpeed * Time.deltaTime;
            transform.localScale = new Vector3(currentScale, currentScale, 1.0f);
            yield return null;
        }

        // yield return new WaitForSeconds(0.2f);
        isMoving = true;
    } //-- ScaleCoroutine end

    IEnumerator BubblePop() {
        animator.SetTrigger("BubblePop");
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    } //-- BubblePop

} //-- class end


/*
Project: Bubble Field CV
Made by: Sir Reyyy
*/

