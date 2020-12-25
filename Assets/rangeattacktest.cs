using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeattacktest : MonoBehaviour
{
    public GameObject bullet;
    public GameObject hand;
    public GameObject aim;
    public float FireRate =1000f;
    public float lastfired;
    public bool fire=false;
    //public int count =0;
    //public GameObject target;
    public float speed=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //aim=this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(GetComponent<playercontroller>().targetposition);
        Vector3 direction = (GetComponent<playercontroller>().targetposition -transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=lookRotation;//Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
        if(fire&&Time.time-lastfired>1/FireRate){
            lastfired=Time.time;
            fire=false;
            //count=1;
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = hand.transform.position;
            newBullet.transform.rotation = hand.transform.rotation;
            Vector3 direction1 =aim.transform.position-newBullet.transform.position;//aim.transform.position
            //newBullet.transform.position = transform.position+transform.forward;
            newBullet.GetComponent<Rigidbody>().velocity =direction1.normalized* speed;
        }
    }
    
}
