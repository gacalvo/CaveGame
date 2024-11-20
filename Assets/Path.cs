using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    //baed on youtube tutorial for an object following a path
    //reference points
    [SerializeField]Transform[] Points;

    [SerializeField]private float moveSpeed;

    private Vector2 previousPosition;
    private SpriteRenderer spriteRenderer;

    //object for player
    public Transform player;
    private int pointsIndex;
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position; 
        transform.position = Points[pointsIndex].transform.position;
        //for switching the sprite direction
        spriteRenderer = GetComponent<SpriteRenderer>();
        //give the player a head start
        //yield return new WaitForSeconds(10f);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if(pointsIndex <= Points.Length -1 ){
            //move the enemy to the next point
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            //check if we have reached the current point
            if(transform.position == Points[pointsIndex].transform.position){
                //update pointsIndex to the next point
                pointsIndex +=1;
            }
        }
    }
}
