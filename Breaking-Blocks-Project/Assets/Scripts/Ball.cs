using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Configuration Parameter
    [SerializeField] Paddle paddle;     //paddle object
    [SerializeField] float xPush = 20f;  //first push position on x
    [SerializeField] float yPush = 15f; //firsh push position on y 
    [SerializeField] AudioClip[] ballSounds;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references 
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position; //Distance between paddle and the ball
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        } 
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y); //position of paddle on the screen

        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted == true)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
