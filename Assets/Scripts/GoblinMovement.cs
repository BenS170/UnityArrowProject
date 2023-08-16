using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed*Time.deltaTime);
    }
}
