using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public void Start()
    {

        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private float moveSpeed = 10f;
    private Animator animator;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    public int oreCount;
    public int woodCount;

    [SerializeField]
    private Text oreCounter, woodCounter;

    public float moveY;
    public float moveX;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        oreCounter.text = "Ore: " + oreCount;
        woodCounter.text = "Wood: " + woodCount;
    }

    void FixedUpdate() //physics calcs due to fixed rate
    {
        Move();

        if (moveX != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if(moveX != 0)
        {
            animator.SetFloat("XDirection", moveX);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attack", true);
        }



    }

    //item pickup
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ItemDrop")
        {
            Destroy(collision.gameObject);
            oreCount += 1;
        }
    }

    void Move()
    {
        if (animator.GetBool("Attack") == true)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void StopAttack()
    {
        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
    }

    public bool test;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ore")
        {
            Debug.Log("Collision detected!");
            test = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
            test = true;
    }
}