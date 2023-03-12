using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CarRunner : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody r;

    public static bool go = true;
   
    public Spawn s;
    GameObject g;
    GameObject wallr;
    GameObject walll;
    bool coll;



    // Start is called before the first frame update
    void Start()
    {
       g = GameObject.FindGameObjectWithTag("Ground");
       r = GetComponent<Rigidbody>();
       CarRunner.go = true;
       wallr = GameObject.FindGameObjectWithTag("Wall");
       walll = GameObject.FindGameObjectWithTag("WallL");
    }



    // Update is called once per frame
    void Update()
    {
    
    /*
            float moveHori = Input.GetAxis("Horizontal") * speed;
            float moveVer = Input.GetAxis("Vertical")* speed;

            if(coll){
                moveHori = -moveHori;
            }
            transform.Translate(new Vector3(-moveHori, 0, -moveVer - speed) * Time.deltaTime);
            g.transform.Translate(new Vector3(0,0,moveVer + speed)*Time.deltaTime);
            */
  
         
         
     }
 
    

    private void OnTriggerEnter(Collider c){
        if(c.CompareTag("Trigger")){
            s.action();
            Debug.Log("Triggered by " + c.gameObject.name);
            
            }else if(c.CompareTag("Wall")){
            coll = true;
            Debug.Log("Colliding with wall");
            
            }
    }
    void OnTriggerExit(Collider c) {
        if(c.CompareTag("Wall")){
        coll = false;
        Debug.Log("Stopped Colliding with wall");
        }
    }

    private void FixedUpdate()
 {
    if(go){
     float moveHori = Input.GetAxisRaw("Horizontal") * speed;
     float moveVer = Input.GetAxisRaw("Vertical") * speed;

     r.position += (moveVer+speed) * -transform.forward * Time.deltaTime;
     if(coll){
        moveHori = 0;
     }
     r.position += moveHori * -transform.right * Time.deltaTime;

     //transform.Translate(new Vector3(-moveHori, 0, -moveVer - speed) * Time.deltaTime);
     g.transform.Translate(new Vector3(0,0,moveVer + speed)*Time.deltaTime);
    }else{
            Invoke("LoadCurrentLevel", 4);
            
        }
    }

 void LoadCurrentLevel(){
        go = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
