using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 4f;

    [SerializeField]
    public float jumpForce = 11f;

    private float movementX;

    public Rigidbody2D myBody;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private SpriteRenderer sr;

    public bool isGrounded ;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }
    // Update is called once per frame
    void Update()
    { 
        PlayerMoveKeyBoard();
        AnimatePlayer();
    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxis("Horizontal");

       // Debug.Log("movement x is equal to " + movementX);

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }  
    
    void AnimatePlayer()
    {
        // we are going to the right side
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            // we are going to the left side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    public void PlayerJump()
    {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
           // Debug.Log("JUMPED PRESSED");
                isGrounded = false;
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }

}

