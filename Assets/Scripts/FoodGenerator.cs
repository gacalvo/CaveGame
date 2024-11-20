using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject orangePrefab;

    //pre-set valid tree positions
    //in the format lowerX, upperX, lowerY, upperY
    float[,] appleTreeLimits = {{-26, -20, -26, -17}, {-49, -42, -47, -39}};
    float[,] orangeTreeLimits  = {{-26, -20, -50, -44}, {-78, -71, -33, -28}};
        
    //create game objects
    //GameObject applePrefab = new GameObject("Apple", typeof(SpriteRenderer));
    //for checking collisions
    //list stores game objects so that objects can be references in the coroutine that makes them visible
    List<GameObject> existingFruit = new List<GameObject>();

    private bool checkDistance(Vector2 newFood, int distance){
        //if the location is within ceratin distance of an existing fruit, dont spawn
        for(int i = 0; i < existingFruit.Count; i++){
            //get the position from the existing fruit object
            Vector2 existingFood = existingFruit[i].transform.position;
            if(Mathf.Abs(newFood.x - existingFood.x) < distance || Mathf.Abs(newFood.y - existingFood.y) < distance){
                //Debug.Log("invalid location" + newFood + ", conflicts with: "+ existingFood);
                return false;
            }
        }
        return true;

    }
    //for removing objects from the list when the player eats them
    public void removeList(GameObject fruit){
        existingFruit.Remove(fruit);
    }

    //generate food
    private void SpawnFood(float[,] limits, GameObject fruit, int treeNum){
        //variable to store the food position
        //randomly choose position
        Vector2 foodGridPosition = new Vector2(Random.Range(limits[treeNum,0], limits[treeNum,1]), Random.Range(limits[treeNum,2], limits[treeNum,3]));

        //distance check to make sure they arent too close
        bool distanceValid = false;
        int distance = 1;
        int tries = 0;
        int maxTry = 50;
        while(!distanceValid && tries < maxTry){
            //call helper
            if(checkDistance(foodGridPosition, distance)){
                //location is valid
                distanceValid = true;
            }
            else{
                //generate a new location
                foodGridPosition = new Vector2(Random.Range(limits[treeNum,0], limits[treeNum,1]), Random.Range(limits[treeNum,2], limits[treeNum,3]));
                tries ++;
            }

        }
        //add to existing fruit
        //existingFruit.Add(foodGridPosition);
        GameObject currFruit = Instantiate(fruit, foodGridPosition, Quaternion.identity);
        existingFruit.Add(currFruit);
        
        //make fruit invisible
        SpriteRenderer spriteRenderer = currFruit.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    //food appears temporarily
    private IEnumerator ShowFruit(GameObject fruit){
        if (fruit != null){
            SpriteRenderer spriteRenderer = fruit.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // enable sprite to show
                spriteRenderer.enabled = true;  
                yield return new WaitForSeconds(2f);  
                //hide fruit again
                spriteRenderer.enabled = false;
            }
        }
        
        
    }

    //since food should onyl appear after the space button is pressed, put in Update()
    void Update(){
        //start coroutine when space bar is pressed
        if(Input.GetKey(KeyCode.Space)){
            foreach (GameObject fruit in existingFruit){
                StartCoroutine(ShowFruit(fruit));
            }
            
        }
        //chek if all the fruit is gone
        if (existingFruit.Count == 0){
            //player has beat the first stage
            Debug.Log("player has beat the first stage");
        }
        
    }



    
    void Start(){
        //fruits should not be visible

        //spawn 10 in trees 1
        for(int i = 0; i < 5; i++){
            SpawnFood(appleTreeLimits, applePrefab, 0);
            SpawnFood(orangeTreeLimits, orangePrefab, 0);
        }
        //spawn 10 in trees 2
        for(int i = 0; i < 5; i++){
            SpawnFood(appleTreeLimits, applePrefab, 1);
            SpawnFood(orangeTreeLimits, orangePrefab, 1);
        }
        
    }

}
