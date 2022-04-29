using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfController : MonoBehaviour
{
    private Animator animator;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Anchor;

    public int health = 10;

    private GameObject playerPoint;
    private Vector3 anchorPointPos;
    private Vector3 playerPointPos;

    private GameObject enemyPoint;

    public float playerDistance;
    public float wolfAnchorDistance;
    public float playerAnchorDistance;
    private float speed = 5.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerPoint = GameObject.Find("Player");
        enemyPoint = GameObject.Find("Enemy");
    }
    public float timeLeft;
    void FixedUpdate()
    {

        //Controls Golem Following, Turning, and Attacking
        playerPointPos = new Vector3(playerPoint.transform.position.x, playerPoint.transform.position.y, playerPoint.transform.position.z);
        anchorPointPos = new Vector3(Anchor.transform.position.x, Anchor.transform.position.y, Anchor.transform.position.z);

        playerDistance = Vector3.Distance(Player.transform.position, Enemy.transform.position);
        wolfAnchorDistance = Vector3.Distance(Enemy.transform.position, Anchor.transform.position);
        playerAnchorDistance = Vector3.Distance(Player.transform.position, Anchor.transform.position);

        if (health > 0)
        {
            if (playerAnchorDistance < 10 && playerDistance > 1.9)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerPointPos, speed * Time.deltaTime);
                animator.SetBool("Moving", true);
            }

            if(playerAnchorDistance > 10 && wolfAnchorDistance > .25)
            {
                if (Anchor.transform.position.x > Enemy.transform.position.x)
                {
                    Enemy.transform.localScale = new Vector3(-1, -1, 1);
                }

                if (Anchor.transform.position.x < Enemy.transform.position.x)
                {
                    Enemy.transform.localScale = new Vector3(1, -1, 1);
                }

                transform.position = Vector3.MoveTowards(transform.position, anchorPointPos, speed * Time.deltaTime);
                animator.SetBool("Moving", true);
            }

            if (playerDistance < 1.9 || wolfAnchorDistance <= .25)
            {
                animator.SetBool("Moving", false);
            }
            if (playerDistance < 2 && animator.GetBool("Attacking") == false)
            {
                animator.SetBool("Attacking", true);
            }
            if (playerDistance > 1.9)
            {
                animator.SetBool("Attacking", false);
            }

            //handle flipping
            if (Player.transform.position.x > Enemy.transform.position.x)
            {
                Enemy.transform.localScale = new Vector3(1, 1, 1);
            }

            if (Player.transform.position.x < Enemy.transform.position.x)
            {
                Enemy.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (health <= 0)
        {
            animator.SetBool("Alive", false);
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(Enemy);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            health -= 1;
        }
    }


}