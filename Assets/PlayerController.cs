using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float steerSpeed = 0.01f;
    [SerializeField] float roadSpeed = 0.01f;
    [SerializeField] float offRoadSpeed = 0.01f;
    bool isOnRoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Road")
        {
            moveSpeed = roadSpeed;
        }
        if (collision == null) 
        {
            moveSpeed = offRoadSpeed;
        }
    }
void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount);
    }
}
