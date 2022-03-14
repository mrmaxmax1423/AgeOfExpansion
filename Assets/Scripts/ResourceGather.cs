using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
    public GameObject oreDrop;
    public int health = 5;
    public int dropAmount = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            health -= 1;
            if (health == 0)
            {
                for (int i = 0; i < dropAmount; i++)
                {
                    Instantiate(oreDrop, gameObject.transform.position, gameObject.transform.rotation);
                }
            Destroy(gameObject);
            }
        }
    }
}
