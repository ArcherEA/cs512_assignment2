using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemycobtroller : MonoBehaviour
{
    //Transform target;

    public float lookRadius = 10f;
    public float attackRadius=1f;
    public NavMeshAgent agent;
    public healthbar bar;
    public int maxhealth=100;
    public int curhealth;
    public float movetime;
    public Animator anim;
    public float activeRadius=30f;
    public GameObject player;
    public GameObject hiteffect;
    public GameObject hitsound;
    public GameObject healobject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        curhealth=maxhealth;
        bar.SetMaxHealth(maxhealth);
        //target = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position,transform.position)>=activeRadius){
            if(agent.isStopped){
                Debug.Log("agent.isstoped=true");
                anim.SetBool("walk",false);
                anim.SetBool("combat",false);
                anim.SetBool("dead",false);
                anim.SetBool("attackrange",false);
            }
            if(agent.destination.x==transform.position.x&&agent.destination.z==transform.position.z){
                anim.SetBool("walk",false);
            }
        }
        else if(Vector3.Distance(player.transform.position,transform.position)<activeRadius&&(Vector3.Distance(player.transform.position,transform.position)>=lookRadius))
        {
            anim.SetBool("combat",false);
            anim.SetBool("attackrange",false);
            agent.speed=3.5f; 
            if(Time.time-movetime>=10f){
                Vector3 position = new Vector3(Random.Range(transform.position.x-10.0f, transform.position.x+10.0f), 0.4f, Random.Range(transform.position.z-10.0f, transform.position.z+10.0f));
                agent.SetDestination(position);
                movetime=Time.time;
                anim.SetBool("walk",true);
            }
            if(agent.destination.x==transform.position.x&&agent.destination.z==transform.position.z){
                anim.SetBool("walk",false);
            }
        }
        else if(Vector3.Distance(player.transform.position,transform.position)<lookRadius&&(Vector3.Distance(player.transform.position,transform.position)>=attackRadius))
        { 
            agent.SetDestination(player.transform.position);
            anim.SetBool("combat",true);
            anim.SetBool("attackrange",false);
            agent.speed=5f;            
        }
        else{
            //transform.LookAt(player.transform.position);
            Vector3 direction = (player.transform.position -transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
            transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation,Time.deltaTime*5f);    
            anim.SetBool("attackrange",true);
            agent.ResetPath();
        }

    }
    private void OnCollisionEnter(Collision other){
        if (other.collider.tag=="weapon"){
            GameObject newhiteffect = Instantiate(hiteffect);
            GameObject newhitsound = Instantiate(hitsound);
            newhitsound.transform.position = transform.position;
            newhiteffect.transform.position = transform.position;
            curhealth-=20;
            bar.Sethealth(curhealth);
            if(curhealth<=0)
            {
                anim.SetBool("dead",true);
                GameObject potion = Instantiate(healobject);
                potion.transform.position = transform.position;
                //Destroy(this.gameObject);
            }
        }
    }
}
