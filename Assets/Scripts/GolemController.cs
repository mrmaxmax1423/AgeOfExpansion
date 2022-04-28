using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.AI;

public class GolemController : MonoBehaviour
{
    private Animator animator;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Anchor;

    public int health = 50;

    private GameObject playerPoint;
    private Vector3 playerPointPos;

    private GameObject enemyPoint;

    public float playerDistance;
    public float anchorDistance;
    private float speed = 3.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPoint = GameObject.Find("Player");
        enemyPoint = GameObject.Find("Enemy");
    }
    public float timeLeft = 3f;
    void FixedUpdate()
    {

        //Controls Golem Following, Turning, and Attacking
        playerPointPos = new Vector3(playerPoint.transform.position.x, playerPoint.transform.position.y, playerPoint.transform.position.z);
        playerDistance = Vector3.Distance(Player.transform.position, Enemy.transform.position);
        anchorDistance = Vector3.Distance(Player.transform.position, Anchor.transform.position);
        if(health > 0)
        {
            if (playerDistance > .95 && anchorDistance < 6.5)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerPointPos, speed * Time.deltaTime);
                animator.SetBool("Moving", true);
            }

            if (playerDistance < 1 || anchorDistance > 6.5)
            {
                animator.SetBool("Moving", false);

            }
            if (playerDistance < 1.2 && animator.GetBool("Attacking") == false)
            {
                animator.SetBool("Attacking", true);
            }
            if (playerDistance > 1.2)
            {
                animator.SetBool("Attacking", false);
            }

            if (Player.transform.position.x > Enemy.transform.position.x)
            {
                Enemy.transform.localScale = new Vector3(1, 1, 1);
            }

            if (Player.transform.position.x < Enemy.transform.position.x)
            {
                Enemy.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        
        if(health <= 0)
        {
            animator.SetBool("Alive", false);
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(Enemy);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            health -= 1;
        }
    }

}