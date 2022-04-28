using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
    public GameObject oreDrop;
    public GameObject woodDrop;
    public int health = 5;
    public int dropAmount = 1;
    Vector3 spawnVariation;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            health -= 1;
            if (health == 0)
            {
                for (int i = 0; i < dropAmount; i++)
                {
                    spawnVariation = new Vector3(Random.Range(-.25f, .25f), Random.Range(-.25f, .25f), Random.Range(-.25f, .25f)); //helps avoids spawning entities ontop of eachother
                    if(gameObject.tag == "Ore")
                    {
                        Instantiate(oreDrop, gameObject.transform.position + spawnVariation, gameObject.transform.rotation);
                    }
                    if (gameObject.tag == "Tree")
                    {
                        Instantiate(woodDrop, gameObject.transform.position + spawnVariation, gameObject.transform.rotation);
                    }
                }
            Destroy(gameObject);
            }
        }
    }
}
