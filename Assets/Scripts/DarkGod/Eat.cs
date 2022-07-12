using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{

    public GameObject currentVillager = null;
    public Animator DarkGodAnim;

    public bool ateVillager = false;

    private float _eatingDelay;

    [SerializeField]
    private bool _isChewing;

    private string currentState;

    //Animation States
    const string DARKGOD_IDLE = "DarkGod_Idle";
    const string DARKGOD_CHEWING = "God_Chewing";
    const string DARKGOD_OPENING = "God_Opening";




    private void Start()
    {
        DarkGodAnim = GetComponent<Animator>();
        ChangeAnimationState(DARKGOD_IDLE);

    }

    private void Update()
    {
        if (_isChewing)
        {
            ChangeAnimationState(DARKGOD_CHEWING);
        }
        else
        {
            ChangeAnimationState(DARKGOD_IDLE);
        }
    }

    public void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState)
        {
            return;
        }
            
        //play the animation
        DarkGodAnim.Play(newState);

        //reassign the current state
        currentState = newState;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Villager"))
        {
            _isChewing = true;
            currentVillager = collision.gameObject;
            Destroy(currentVillager);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _eatingDelay = DarkGodAnim.GetCurrentAnimatorStateInfo(0).length;
        Invoke("FinishedEating", _eatingDelay);
        currentVillager = null;
    }


    public void FinishedEating()
    {
        _isChewing = false;
    }
}
