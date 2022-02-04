using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncukontrolü : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D playerRB;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;


    bool facingRight = true;
    public bool isGrounded = false;


    void Awake() // kod aktif olsun ya da olmasın, sahne aktif olduğunda çalışır.
    {
       
    }
    
    void Start() // kod aktif olduğunda çalışır.
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    
    void Update() // frame odaklı çalışma prensibi var.
    {
        HorizontalMove();
        OnGroundCheck();
        
        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace(); // yüzünü çevir.
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace(); // yüzünü çevir.
        }

        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        // kullanıcı yukarı ok tuşuna basıyorsa ve karakter yere değiyorsa:
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void FixedUpdate() // zaman odaklı çalışma prensibi var.
    {

    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed,playerRB.velocity.y); // durmak için sürtünmeye İHTİYACIMIZ YK.
        playerAnimator.SetFloat("playerspeed",Mathf.Abs(playerRB.velocity.x)); // yürümeden koşmaya geçebilmek için mutlak değer ataması.
    }

    void FlipFace() // yüz çevirme fonksiyonu
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnGroundCheck() // sanal bir daire oluşturuyoruz. böylece karakterin yere değip değmediği anlaşılablir.
    {
      isGrounded =  Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
      playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}