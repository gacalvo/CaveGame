using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Transform rotateAround;

    private SpriteRenderer spriteRenderer;
    private Collider2D lightCollider;
    //private bool autoRotate = false;
    // Update is called once per frame
    void Start()
    {
        // if(Input.GetKey(KeyCode.R)){
        //     transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        // }

        StartCoroutine(LightDelayAndRotate());

        spriteRenderer = GetComponent<SpriteRenderer>();
        lightCollider = GetComponent<Collider2D>();

        // spriteRenderer.enabled = false;
        // lightCollider.enabled = false;
    }

    //function for delaying the light direction
    private IEnumerator LightDelayAndRotate(){
        Debug.Log("Starting rotation");
        while(rotateAround.position.x<20){
            //yield return new WaitForSeconds(10f);
            //turn on flashlight
            // spriteRenderer.enabled = true;
            // lightCollider.enabled = true;
            transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed*4);
            yield return new WaitForSeconds(1f);
            transform.RotateAround(rotateAround.position, Vector3.forward, -rotationSpeed*2);
            yield return new WaitForSeconds(1f);
            transform.RotateAround(rotateAround.position, Vector3.forward, -rotationSpeed*2);
            yield return new WaitForSeconds(1f);
            // transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed*4);
            // yield return new WaitForSeconds(1f);
        }
       
    }
}
