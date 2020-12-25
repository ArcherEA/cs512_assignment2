using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_death : MonoBehaviour
{
    public bool destroy_or_deactive=true;
    // Start is called before the first frame update
    void Start()
    {
        if(destroy_or_deactive){
        Destroy(this.gameObject);}
        else{this.gameObject.SetActive(false);}
    }

    // Update is called once per frame
    void Update()
    {
        if(destroy_or_deactive){
        Destroy(this.gameObject);}
        else{this.gameObject.SetActive(false);}
    }
}
