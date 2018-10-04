using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        //Obtiene el movimiento de las teclas 'A' y 'D',
        //y de las teclas de direccion
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        //Detecta si el usuario pulsa el boton asignado a saltar
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        //Detecta si el usuario pulsa el boton asignado para agacharse
        if(Input.GetButtonDown("Crouch")){
            crouch = true;
        }else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }
    }

    public void OnLanding(){
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching){
        animator.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        //Genera el movimiento del personaje
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
