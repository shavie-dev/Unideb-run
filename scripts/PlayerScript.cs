using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float fallMultiplier;
    public Animator animator;
    public GameObject player;
    public Rigidbody rb;
    public CapsuleCollider CapsuleCollider;
    public EnvromentScript envromentScript;
    public logicScript logic;
    private int jumpCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        envromentScript = GameObject.FindGameObjectWithTag("enviroment").GetComponent<EnvromentScript>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
        animator = player.GetComponent<Animator>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
        
        animator.SetBool("isRunning", true);


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            role();
        }
    }

    public void movement()
    {
        float moveX = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(moveX, 0, 0);
        transform.Translate(move * speed * Time.deltaTime);

    }

    public void jump()
    {
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpCount == 1)
        {
            rb.velocity = Vector3.up * jumpSpeed;
              animator.SetTrigger("jump");
            jumpCount = 0;
            StartCoroutine(jumptime());
        }
        
        if (rb.velocity.y <= 0)
        {
            
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        
    }
    public IEnumerator jumptime()
    {
        CapsuleCollider.center = new Vector3(0, 0.78f, 0);
        yield return new WaitForSeconds(0.6f);
        CapsuleCollider.center = new Vector3(0, 0, 0);
    }


    public void role()
    {
        animator.SetTrigger("role");
        StartCoroutine(roletime());
        animator.SetBool("isRunning", false);
    }
    public IEnumerator roletime()
    {
        CapsuleCollider.height = 0.675f;
        CapsuleCollider.center = new Vector3(-0.19f, -0.38f, 0.54f);

        //Debug.Log("capsle shrink");
        yield return new WaitForSeconds(0.29f);
        CapsuleCollider.center = new Vector3(0, -0.39f, 0.39f);
        yield return new WaitForSeconds(0.29f);
        
        CapsuleCollider.height = 1.35f;
        CapsuleCollider.center = new Vector3(0, 0, 0);

    }

    public void hitObstacle()
    {
        logic.isAlive = false;
        envromentScript.moveSpeed = 0;
        StartCoroutine(hitTime());
    }

    public IEnumerator hitTime()
    {
        animator.SetTrigger("fall");
        yield return new WaitForSeconds(1.5f);
        logic.gameOver();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("lane"))
        {
            jumpCount = 1;
        }

        if (collision.gameObject.CompareTag("danger"))
        {
            hitObstacle();
        }
       
        
    }




}
