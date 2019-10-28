using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f, yPush = 10f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float random_factor = 0f;
    
    
    // State
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    // Cached component references
    private AudioSource myAudioSource;
    private Rigidbody2D my_RigidBody2D;
    
    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        my_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            LockBallToPaddle();
            BallLaunch();
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }

    private void BallLaunch() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            my_RigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        int x = 5, y = 5;
        
        Vector2 velocity_mod = new Vector2(UnityEngine.Random.Range(0f, random_factor), UnityEngine.Random.Range(0f, random_factor));
        
        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            my_RigidBody2D.velocity += velocity_mod;
        }
    }
}
