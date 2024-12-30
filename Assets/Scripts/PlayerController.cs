using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;
    public float runSpeed; //forward move
    public float horizontalSpeed; //right left move
    public Rigidbody rb;
    float horizontalInput;
    [SerializeField] private float JumpForce = 350; //serializefield is used to show variable in inspector frame even the variable is private
    [SerializeField] private LayerMask GroundMask; //used to declare ground from where we jump the player

    public float speedIncrease;

    public void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate(){
        if(isAlive){
            Vector3 forwardMovement = transform.forward * runSpeed * Time.fixedDeltaTime; //Time.fixedDeltaTime - to keep the frames constant
            Vector3 horizontalMovement = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime; //Time.fixedDeltaTime - to keep the frames constant
            rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float playerHeight = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight/2) + 0.1f, GroundMask);

        //when to jump
        if(Input.GetKeyDown(KeyCode.Space) && isAlive && isGrounded==true){
            Jump();
        }
    }
    public void Jump(){ //called in update function
        SoundManager.PlaySound("Jump");
        rb.AddForce(Vector3.up * JumpForce);
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name=="Graphic"){
            SoundManager.PlaySound("Game Over");
            Dead();
        }
        if(collision.gameObject.name == "Coin(Clone)"){
            SoundManager.PlaySound("Coin");
            Destroy(collision.gameObject);
            GameManager.MyInstance.Score++;
            runSpeed+=speedIncrease;
        }
    }
    public void Dead(){
        isAlive = false;
        GameManager.MyInstance.GameOverPanel.SetActive(true);
    }
}