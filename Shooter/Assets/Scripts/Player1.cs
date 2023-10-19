using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public ControlType controlType;
    public float speed;
    public Joystick joystick;
    public enum ControlType { PC, Android };
    public Animator animator;

    public int hp;
    public int exp;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    private bool facingright = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(controlType == ControlType.PC) 
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else 
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        
        moveVelocity = moveInput.normalized * speed;
        if(moveInput.x == 0 && moveInput.y == 0)
        {
            animator.SetBool("IsRun", false);
        }
        else
        {
            animator.SetBool("IsRun", true);
        }
        if(!facingright && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingright && moveInput.x < 0)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (moveVelocity * Time.fixedDeltaTime));
    }
    private void Flip()
    {
        facingright = !facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void ChangeHealth(int health) 
    {
        this.hp += health;
    }
}
