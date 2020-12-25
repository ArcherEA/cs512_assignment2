using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count_enemy : MonoBehaviour
{
    public int count;
    //public GameObject[] enemys;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("enemy")==null){
            count=0;
        }
        else{count=GameObject.FindGameObjectsWithTag("enemy").Length;}
    }
}
