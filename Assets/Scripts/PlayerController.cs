using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D body;
    private Vector2 direction;

    //for changing directions of the animation
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       direction = transform.position;
       if(Input.GetKey("w")){
            direction.y += speed * Time.deltaTime;
       }
       if(Input.GetKey("s")){
            direction.y -= speed * Time.deltaTime;
       }
       if(Input.GetKey("d")){
            direction.x += speed * Time.deltaTime;
            spriteRenderer.flipX = false;
       }
       if(Input.GetKey("a")){
            direction.x -= speed * Time.deltaTime;
            spriteRenderer.flipX = true;
       }
       transform.position = direction;

       
    }

    
    
}   

