using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMovement : MonoBehaviour
{
    [HideInInspector]
    public float moonSpeed;

    private Rigidbody2D myBody;

    private string MOON_TAG = "Moon";
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        moonSpeed = 0.2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(moonSpeed, myBody.velocity.y);
    }
}
