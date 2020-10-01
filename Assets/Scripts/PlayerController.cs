using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField, Header("プレイヤー移動速度")] private float speed = 10.0f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void FixedUpdate() 
    {
        float x =  Input.GetAxis("Horizontal") * speed;
        // float z = Input.GetAxis("Vertical") * speed;
        transform.Translate(Vector3.right * x * Time.deltaTime);
        // transform.Translate(Vector3.forward * z * Time.deltaTime);
    }
}
