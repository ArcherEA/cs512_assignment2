using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Cinemachine;
using UnityEngine.SceneManagement;
public class playercontroller : MonoBehaviour
{
    public Camera fpscamera;
    public NavMeshAgent agent;
 
    public float turnSmoothTime=0.1f;
    float turnSmoothVelocity;
    private bool uicanvas=false;
    public bool melee_weapon=false;
    public bool attack_switch=true;
    private bool hit_enemy=false;
    public bool walk_run_switch=true;
    public GameObject katana;
    public GameObject bow;
    public GameObject arrow;
    public Animator anim;
    public float melee_range=1f;
    public float ranged_range=10f;
    public healthbar bar;
    public int maxhealth=100;
    public int curhealth;
    public Vector3 targetposition;
    public GameObject canvas;
    public GameObject buttons;
    public GameObject panel;
    public GameObject helppanel;
    public GameObject minimap;
    private bool showminimap=true;
    public bool ranged_weapon =false;
    private bool showmap=false;
    private bool help=false;
    private bool showquest=false;
    public GameObject hiteffect;
    public GameObject hitsound;
    private AudioSource aus ;
    public GameObject target=null;
    // public Transform groundCheck;
    // public LayerMask groundMask;
    // bool isGrounded;
    // public float speed = 5.0f;
    // public CharacterController controller;
    // private Vector3 direction;
    //private RaycastHit hit ;
    // Start is called before the first frame update
    void Start()
    {
        // direction=transform.position;
        // hit.point=transform.position;
        // Debug.Log(direction);
        // anim.SetBool("moving",false);
        // anim.SetBool("melee_attack",false);
        // anim.SetBool("ranged_attack",false);
        // anim.SetBool("attack",false);
        // anim.SetBool("walk_or_run",false);
        curhealth=50;
        bar.Sethealth(curhealth);
        canvas.SetActive(false);
        aus= GetComponent<AudioSource>();
        // buttons.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray=fpscamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit ;
        //Vector3 targetPoint ;
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("Alpha1 down");
            anim.SetBool("melee_attack",true);
            anim.SetBool("ranged_attack",false);
            melee_weapon=true;
            ranged_weapon =false;
            katana.SetActive(true);
            bow.SetActive(false);
            arrow.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Debug.Log("Alpha2 down");
            anim.SetBool("ranged_attack",true);
            anim.SetBool("melee_attack",false);
            melee_weapon=false;
            ranged_weapon =true;
            katana.SetActive(false);
            bow.SetActive(true);
            arrow.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Debug.Log("Alpha3 down");
            anim.SetBool("melee_attack",false);
            anim.SetBool("ranged_attack",false);
            anim.SetBool("attack",false);
            melee_weapon=false;
            ranged_weapon =false;
            katana.SetActive(false);
            bow.SetActive(false);
            arrow.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Debug.Log("r down");
            if(walk_run_switch){
                anim.SetBool("walk_or_run",true);
                agent.speed=8f;
                aus.pitch=1.7f;
                walk_run_switch=false;
            }
            else{
                anim.SetBool("walk_or_run",false);
                agent.speed=5f;
                aus.pitch=1.2f;
                walk_run_switch=true;
            }
        }
        if(Input.GetKeyDown(KeyCode.J)){
            Debug.Log("J down");
            if(showquest){
                showquest=false;
                panel.SetActive(false);
            }
            else{
                showquest=true;
                panel.SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.N)){
            Debug.Log("N down");
            if(showminimap){
                showminimap=false;
                minimap.SetActive(false);
            }
            else{
                showminimap=true;
                minimap.SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.H)){
            Debug.Log("H down");
            if(help){
                help=false;
                helppanel.SetActive(false);
            }
            else{
                help=true;
                helppanel.SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.M)){
            if(!showmap){
            canvas.SetActive(true);
            showmap=true;
            }
            else{
                showmap=false;
                canvas.SetActive(false);
            }
        }
        
        if(Input.GetKey(KeyCode.LeftControl)){     
            uicanvas=true;
        }else{uicanvas=false;}
        if(Input.GetKey(KeyCode.LeftShift)){
            Debug.Log("lshift down");
            anim.SetBool("attack",true);
            attack_switch=true;
            // if(attack_switch){
            //     attack_switch=false;
            //     // anim.SetBool("attack",false);
            //     }
            // else{attack_switch=true;
            //     // anim.SetBool("attack",true);
            //     }
        }
        else{attack_switch=false;}
        
        if(Input.GetMouseButton(0)&&(!uicanvas)){ 
            Debug.Log("MouseButton(0) down");
            if(Physics.Raycast(ray, out hit,1000f)){
                // int layerMask = 0 << 11;
                Debug.Log(hit.transform.gameObject.name);
                targetposition=hit.point;
                agent.isStopped=false;
                agent.SetDestination(hit.point);
                anim.SetBool("moving",true);
                if(!aus.isPlaying){   
                    aus.Play();
                }
                if(Vector3.Distance(agent.destination,transform.position)<=agent.stoppingDistance){
                    agent.isStopped=true;
                    anim.SetBool("moving",false);
                    if(aus.isPlaying){
                    aus.Stop();
                    }
                    agent.ResetPath();
                    //transform.LookAt(hit.transform.position);
                }
                if(hit.transform.gameObject.tag=="enemy"){
                    target=hit.transform.gameObject;
                    hit_enemy=true;
                    // if(melee_weapon){
                    //     Vector3 direction = new Vector3(hit.point.x-transform.position.x,0,hit.point.z-transform.position.x).normalized;
                    //     if (direction.magnitude>0.1f){
                    //         float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg;
                    //         transform.rotation = Quaternion.Euler(0f,targetAngle,0f);
                    //     }
                    // }
                    anim.SetBool("attack",true);
                }
                else{
                    hit_enemy=false;
                    target=null;
                }
                // if(agent.isStopped){
                    // if(aus.isPlaying){
                    //     aus.Stop();
                    //     }
                // }
                // else{
                    // if(!aus.isPlaying){   
                    //     aus.Play();
                    // }
                // }
                //else{anim.SetBool("attack",true);}

                //Debug.Log("press button");
                //targetPoint = hit.point;
                //Debug.Log(hit.point);
                // Vector3 direction = new Vector3(hit.point.x,0,hit.point.z).normalized;
                // if (direction.magnitude>0.1f){
                //     float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg;
                    
                //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                //     transform.rotation = Quaternion.Euler(0f,angle,0f);
                //     controller.Move(direction*speed*Time.deltaTime);
                // }

            }
                
        }
        if(target!=null){targetposition=target.transform.position;}
        //else{anim.SetBool("attack",false);}
        // agent.destination.x==transform.position.x&&agent.destination.z==transform.position.z){

        if((!hit_enemy)&&Vector3.Distance(agent.destination,transform.position)<=agent.stoppingDistance){
            agent.isStopped=true;
            anim.SetBool("moving",false);
            if(aus.isPlaying){
                aus.Stop();
            }
            agent.ResetPath();
        }

        if(hit_enemy&&(!ranged_weapon)&&Vector3.Distance(agent.destination,transform.position)<=melee_range){
            agent.isStopped=true;
            anim.SetBool("moving",false);
            if(aus.isPlaying){
                aus.Stop();
            }
            agent.ResetPath();
        }
        if(hit_enemy&&ranged_weapon&&Vector3.Distance(agent.destination,transform.position)<=ranged_range){
            agent.isStopped=true;
            anim.SetBool("moving",false);
            if(aus.isPlaying){
                aus.Stop();
            }
            agent.ResetPath();
        }
        if((!hit_enemy)&&attack_switch){
            agent.isStopped=true;
            anim.SetBool("moving",false);
            if(aus.isPlaying){
                aus.Stop();
            }
            agent.ResetPath();
        }

        // else{controller.Move(direction*speed*Time.deltaTime);}
        
        
    }
    private void OnCollisionEnter(Collision other){
        Debug.Log("player collision");
        if (other.collider.tag=="enemy_weapon"){
            GameObject newhiteffect = Instantiate(hiteffect);
            GameObject newhitsound = Instantiate(hitsound);
            newhitsound.transform.position = transform.position;
            newhiteffect.transform.position = transform.position;
            curhealth-=2;
            bar.Sethealth(curhealth);
            if(curhealth<=0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
                //Destroy(this.gameObject);
            }
        }
        if (other.collider.tag=="healobject"){
            if((curhealth+50)<=maxhealth){
                curhealth=curhealth+50;
            }
            else{curhealth=maxhealth;}
            bar.Sethealth(curhealth);
            Destroy(other.gameObject);
            }
    }


    

}
