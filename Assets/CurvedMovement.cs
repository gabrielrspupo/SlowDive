using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedMovement : MonoBehaviour {
    /*
    public Vector2 startPosition = new Vector2(-10,0);    //The starting position in world space
    public Vector2 endPosition = new Vector2(10,0);    //The ending position in world space
    public Vector2 bending = new Vector2.up;                //Bend factor (on all axes)
    float timeToTravel = 10.0f;                //The total time it takes to move from start- to end position

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedPosition() {
        MoveToPosition();
    }
    private void MoveToPosition()
    {
        float timeStamp = Time.time;
        while (Time.time < timeStamp + timeToTravel)
        {
            Vector2 currentPos = transform.position;//new Vector2.Lerp(transform.position.x, endPosition, (Time.time - timeStamp) / timeToTravel);

            currentPos.x += bending.x * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            currentPos.y += bending.y * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            //currentPos.z += bending.z * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);


            //currentPos.x += bending.x * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            //currentPos.y += bending.y * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / timeToTravel) * Mathf.PI);
            rb.MovePosition(currentPos);
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) * timeToTravel * Time.deltaTime);
            //transform.position = currentPos;

        }
    }*/
}
