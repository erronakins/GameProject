using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> road;
    // Start is called before the first frame update
    void Start()
    {
        //road = new List<GameObject>(GameObject.FindGameObjectsWithTag("Respawn"));
        
        foreach(GameObject item in road){
            Debug.Log(item);
        }


    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shift(){

        GameObject target = road[0];

        Debug.Log(road.Count - 1);
        GameObject t = road[road.Count - 1];
        target.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,t.transform.position.z+(t.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().bounds.size.y * 13));
        
        road.Add(target);
        road.Remove(road[0]);
    }
}
