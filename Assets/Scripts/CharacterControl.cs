using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 10f;
    public Rigidbody player;
    public Transform playerTransform;
    Vector3 directionSpeed;
    int coinCounter = 0;
    void Start() 
    {
        directionSpeed = new Vector3(speed, 0, speed);     
    }

    // Update is called once per frame
    void Update()
    {
        //This is player movement
        //I don't know why and I am quite frankly not in the mood to figure out why
        //But I needed to reverse the controls for it to work
        //But it works
        if (Input.GetKeyDown(KeyCode.W))
        {
                player.AddForce(player.rotation * (Vector3.back * speed), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
                player.AddForce(player.rotation * (Vector3.forward * speed), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
                player.AddForce(player.rotation *  (Vector3.right * speed), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
                player.AddForce(player.rotation *  (Vector3.left * speed),ForceMode.Impulse);
        }
        //player/camera rotation
        if (Input.GetKey(KeyCode.Q))
        {
                player.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (Input.GetKey(KeyCode.E))
        {
                player.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, Vector3.down); 
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Coin")
        {
                other.gameObject.tag = "Untagged";
                Destroy(other.gameObject);
                print("got coin");
                coinCounter++;
                if (coinCounter >= 10)
                {
                        SceneManager.LoadScene("End");
                }
        }       
    }
}
 