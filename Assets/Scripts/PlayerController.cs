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

    //for updating the score on collisions with fruit and bugs
    public ScoreManager scoreManager;

    //for eating sound
    //[SerializeField] private AudioS
    //for echolocation sound
    public FoodGenerator foodGenerator;
    //for game end animation
    public Animator animator;

    public GameOverScreen gameOverScreen;
    //for end condition
    private int fruitCount = 0;
    //for audio clips
    [SerializeField] private AudioClip eatSoundClip;

    [SerializeField] private AudioClip hitSoundClip;

    [SerializeField] private AudioClip endSoundClip;

    [SerializeField] private AudioClip echolocationClip;

    

    // Start is called before the first frame update
    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        //following code from Apple Picker score counter
        GameObject scoreGO = GameObject.Find("ScoreManager");
        scoreManager = scoreGO.GetComponent<ScoreManager>();
        animator = GetComponent<Animator>();
        //make sure lost is set to false
        //animator.SetBool(".lost", false);
        animator.Play("Player_fly");


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

        //echolocation functionality
        if(Input.GetKey(KeyCode.Space)){
            //in this script it just plays the noise
            SoundFXManager.instance.PlaySoundFXClip(echolocationClip, transform, 1f);
        }
       //check for a losing score of 0
       if(scoreManager.score < 0){
        //game is over

        //SoundFXManager.instance.PlaySoundFXClip(endSoundClip, transform, 1f);
        animator.SetTrigger("deathAnimation"); // play death animation
        
        gameOverScreen.ShowGameOverScreen(); //call end screen
       }
       if(fruitCount == 20){
        Debug.Log("player wins");
        //move player to next stge
        //transform.position = new Vector2(-39, 5);
        
       }
       
    }

    //for colliding with fruit and bugs
    //based off apple picker code
    void OnCollisionEnter2D(Collision2D coll){
        Debug.Log("collided");
        GameObject collidedWith = coll.gameObject;
        //check to see if its a fruit
        if(collidedWith.CompareTag("Fruit")){
            //delete from list using foodGenrator method
            //foodGenerator.removeList(coll.gameObject);
            //destroy the fruit object
            Destroy(collidedWith);
            //increase score
            scoreManager.score += 50;
            fruitCount+=1;
            //play eat sound
            SoundFXManager.instance.PlaySoundFXClip(eatSoundClip, transform, 1f);
            //bring in later
            //HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
        // if(collidedWith.CompareTag("LightBeam")){
        //     //destroy the fruit object
           
        //     //increase score
        //     scoreManager.score -= 100;
        //     //play eat sound
        //     //add later
        //     //bring in later
        //     //HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightBeam"))
        {
            Debug.Log("hit the light");
            scoreManager.score -= 100;
            //play hit sound
            SoundFXManager.instance.PlaySoundFXClip(hitSoundClip, transform, 1f);
            
        }
    }

    public int getScore(){
        return scoreManager.score;
    }

    
    
}   

