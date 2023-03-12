using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Spawner s;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<Spawner>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void action(){
        s.shift();
    }
}
