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

    public GameObject Player;
    public bool facingRight;

    public int health = 3;
    public static int oreCount;
    public static int woodCount;

    [SerializeField]
    private Text oreCounter, woodCounter;

    public float moveY;
    public float moveX;

    public Transform craftingUI;

    public bool axeOwned = false;
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

        if (moveX != 0) //if player inputs a move, make sure they face the direction of movement
        {
            animator.SetBool("Moving", true);
            if(moveX == -1 && facingRight)
            {
                Player.transform.localScale = new Vector3(-6, 6, 1);
                facingRight = false;
            }
            if(moveX == 1 && !facingRight)
            {
                Player.transform.localScale = new Vector3(6, 6, 1);
                facingRight = true;
            }
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    public float timeLeft = 3f;

    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attack", true);     
        }

        if (moveX != 0)
        {
            animator.SetFloat("XDirection", moveX);
        }

        //display crafting menu
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (craftingUI.gameObject.activeSelf)
            {
                craftingUI.gameObject.SetActive(false);
            }
            else
            {
                craftingUI.gameObject.SetActive(true);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //item Pickup
        if (collision.gameObject.tag == "OreDrop")
        {
            Destroy(collision.gameObject);
            oreCount += 1;
        }
        if (collision.gameObject.tag == "WoodDrop")
        {
            Destroy(collision.gameObject);
            woodCount += 1;
        }
        //Enemy Hit
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            health -= 1;
        }
    }

    void Move()
    {
        if (animator.GetBool("Attack") == true)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
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

}