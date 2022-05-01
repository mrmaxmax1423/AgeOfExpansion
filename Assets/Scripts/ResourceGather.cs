using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
    public GameObject oreDrop;
    public GameObject woodDrop;
    public GameObject runePillarDrop;
    public int health = 5;
    public int dropAmount = 1;
    Vector3 spawnVariation;

    public AudioSource miningSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {

            health -= 1;
            miningSound.Play();
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
                    if (gameObject.tag == "RunePillar")
                    {
                        Instantiate(runePillarDrop, gameObject.transform.position + spawnVariation, gameObject.transform.rotation);
                    }
                }
            Destroy(gameObject);
            }
        }
    }
}
