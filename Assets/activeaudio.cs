using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeaudio : MonoBehaviour
{
    public GameObject player;
    public float playradius=10f;
    private AudioSource aus ;
    // Start is called before the first frame update
    void Start()
    {
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position,transform.position)<=playradius){
            if(!aus.isPlaying){
            aus.Play();}
        }
        else{aus.Stop();}
    }
}
