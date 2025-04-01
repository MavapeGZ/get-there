using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rig;

    [SerializeField]
    private float speed;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rig.AddForce (new Vector3(horizontal,0,vertical) * speed * Time.deltaTime);
    }
}
