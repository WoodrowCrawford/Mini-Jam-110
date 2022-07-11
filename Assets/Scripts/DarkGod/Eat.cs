using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public bool ateVillager = false;

    public GameObject currentVillager = null;

    public Animator DarkGodAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Villager"))
        {
            DarkGodAnim.SetBool("isChewing", true);
            currentVillager = collision.gameObject;
            Destroy(currentVillager);
            
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        currentVillager = null;
    }
}
