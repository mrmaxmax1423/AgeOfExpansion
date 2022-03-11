using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    public GameObject oreDrop;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Test" || collision.gameObject.tag == "Weapon")
        {
            Instantiate(oreDrop, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
