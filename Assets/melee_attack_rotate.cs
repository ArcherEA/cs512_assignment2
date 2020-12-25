using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_attack_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //transform.LookAt(GetComponent<playercontroller>().targetposition);

        Vector3 direction = (GetComponent<playercontroller>().targetposition -transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation,Time.deltaTime*5f);
    }
}
