using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 dragDirection = touch.deltaPosition;
                
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dragDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);


                transform.Translate(dragDirection * moveSpeed * Time.deltaTime, Space.World);
                //transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Goblin"))
        {
            logic.AddScore();
            Destroy(collision.gameObject);
        }
    }
}
