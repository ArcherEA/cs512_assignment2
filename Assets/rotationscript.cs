using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class rotationscript : MonoBehaviour
{
    private CinemachineFreeLook freeLook;

    // Start is called before the first frame update
    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            freeLook.m_XAxis.m_MaxSpeed=300f; 
            freeLook.m_YAxis.m_MaxSpeed=2f;
        }
        else{
            freeLook.m_XAxis.m_MaxSpeed=0f; 
            freeLook.m_YAxis.m_MaxSpeed=0f;
        
        }
    }
}
