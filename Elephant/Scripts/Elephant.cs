using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : MonoBehaviour
{
    private Animator elephant;
    CharacterController characterController;
    public float gravity = 2.0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool Speed1 = true;
    private bool Speed2 = false;
    private bool Speed3 = false;
    // Start is called before the first frame update
    void Start()
    {
        elephant = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Speed1 = !Speed1;
            Speed2 = false;
            Speed3 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Speed2 = !Speed2;
            Speed1 = false;
            Speed3 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Speed3 = !Speed3;
            Speed1 = false;
            Speed2 = false;
        }
        if (elephant.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            elephant.SetBool("attack", false);
            elephant.SetBool("trumpet", false);
            elephant.SetBool("eat", false);
            elephant.SetBool("drink", false);
            elephant.SetBool("lay", false);
            elephant.SetBool("getup", false);
            elephant.SetBool("walkleft", false);
            elephant.SetBool("walkright", false);
            elephant.SetBool("walk", false);
            elephant.SetBool("run", false);
            elephant.SetBool("swim", false);
        }
        if ((Input.GetKeyDown(KeyCode.W))&&(Speed1==true))
        {
            elephant.SetBool("idle", false);
            elephant.SetBool("walk", true);
        }
        if ((Input.GetKeyUp(KeyCode.W))&&(Speed1==true))
        {
            elephant.SetBool("walk", false);
            elephant.SetBool("idle", true);
        }
        if ((Input.GetKeyDown(KeyCode.A)) && (Speed1 == true))
        {
            elephant.SetBool("walk", false);
            elephant.SetBool("walkleft", true);
        }
        if ((Input.GetKeyUp(KeyCode.A)) && (Speed1 == true))
        {
            elephant.SetBool("walk", true);
            elephant.SetBool("walkleft", false);
        }
        if ((Input.GetKeyDown(KeyCode.D)) && (Speed1 == true))
        {
            elephant.SetBool("walk", false);
            elephant.SetBool("walkright", true);
        }
        if ((Input.GetKeyUp(KeyCode.D)) && (Speed1 == true))
        {
            elephant.SetBool("walk", true);
            elephant.SetBool("walkright", false);
        }
        if ((Input.GetKeyDown(KeyCode.W)) && (Speed2 == true))
        {
            elephant.SetBool("idle", false);
            elephant.SetBool("run", true);
        }
        if ((Input.GetKeyUp(KeyCode.W)) && (Speed2 == true))
        {
            elephant.SetBool("run", false);
            elephant.SetBool("idle", true);
        }
        if ((Input.GetKeyDown(KeyCode.A)) && (Speed2 == true))
        {
            elephant.SetBool("run", false);
            elephant.SetBool("runleft", true);
        }
        if ((Input.GetKeyUp(KeyCode.A)) && (Speed2 == true))
        {
            elephant.SetBool("run", true);
            elephant.SetBool("runleft", false);
        }
        if ((Input.GetKeyDown(KeyCode.D)) && (Speed2 == true))
        {
            elephant.SetBool("run", false);
            elephant.SetBool("runright", true);
        }
        if ((Input.GetKeyUp(KeyCode.D)) && (Speed2 == true))
        {
            elephant.SetBool("run", true);
            elephant.SetBool("runright", false);
        }
        if ((Input.GetKeyDown(KeyCode.W)) && (Speed3 == true))
        {
            elephant.SetBool("idle", false);
            elephant.SetBool("swim", true);
        }
        if ((Input.GetKeyUp(KeyCode.W)) && (Speed3 == true))
        {
            elephant.SetBool("swim", false);
            elephant.SetBool("idle", true);
        }
        if ((Input.GetKeyDown(KeyCode.A)) && (Speed3 == true))
        {
            elephant.SetBool("swim", false);
            elephant.SetBool("swimleft", true);
        }
        if ((Input.GetKeyUp(KeyCode.A)) && (Speed3 == true))
        {
            elephant.SetBool("swim", true);
            elephant.SetBool("swimleft", false);
        }
        if ((Input.GetKeyDown(KeyCode.D)) && (Speed3 == true))
        {
            elephant.SetBool("swim", false);
            elephant.SetBool("swimright", true);
        }
        if ((Input.GetKeyUp(KeyCode.D)) && (Speed3 == true))
        {
            elephant.SetBool("swim", true);
            elephant.SetBool("swimright", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            elephant.SetBool("backward", true);
            elephant.SetBool("idle", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            elephant.SetBool("backward", false);
            elephant.SetBool("idle", true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            elephant.SetBool("attack", true);
            elephant.SetBool("run", false);
            elephant.SetBool("runleft", false);
            elephant.SetBool("runright", false);
            elephant.SetBool("idle", false);
            elephant.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            elephant.SetBool("trumpet", true);
            elephant.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            elephant.SetBool("idle", false);
            elephant.SetBool("eat", true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            elephant.SetBool("idle", false);
            elephant.SetBool("drink", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            elephant.SetBool("lay", true);
            elephant.SetBool("idle", false);
            elephant.SetBool("getup", true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            elephant.SetBool("idle", false);
            elephant.SetBool("die", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            elephant.SetBool("turnleft", true);
            elephant.SetBool("idle", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            elephant.SetBool("turnleft", false);
            elephant.SetBool("idle", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            elephant.SetBool("turnright", true);
            elephant.SetBool("idle", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            elephant.SetBool("turnright", false);
            elephant.SetBool("idle", true);
        }
    }
}
