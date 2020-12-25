using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class quest_update : MonoBehaviour
{
    public TextMeshProUGUI TextPro;
    public npc npcscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num=transform.GetComponent<count_enemy>().count;
        if(num>0){
            TextPro.text="target:"+Environment.NewLine+"    you need kill " +num+" goblins" +Environment.NewLine+"    you can press M to see the location";
        }else{
            npcscript.finishquest=true;
            TextPro.text="completed!"+Environment.NewLine+"Go back to take reward";
        }
    }
}
