using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class button_destroy : MonoBehaviour
{
    public GameObject npc;
    public TextMeshProUGUI TextPro;
    public GameObject Goblin;
    

    public void button_destory(){
        //npc.GetComponent.<npc>().sentquest = false;
        Destroy(this.gameObject);

    }
    
}
