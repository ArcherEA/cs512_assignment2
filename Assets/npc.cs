using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class npc : MonoBehaviour
{
    public GameObject Player;
    public float lookRadius=5f;
    // public text title;
    //public  Text content;

    public TextMeshProUGUI TextPro;
    private GameObject Goblin;
    //private bool objectcomplete=false;
    //private bool showquest=true;
    public GameObject panel;

    public bool sentquest=true;
    public bool finishquest=false;
    public GameObject acceptbutton;
    public GameObject finishbutton;
    public GameObject spawnplace;
    // Start is called before the first frame update
    void Start()
    {
        Goblin=GameObject.FindGameObjectWithTag ("enemy");
        //content.text="you do not have quest now!";
        TextPro.text="you do not have quest now!"+Environment.NewLine+" Lord Goldbloom may has quest for you"
            +Environment.NewLine+"press M to see the location of Lord Goldbloom(green point)";
    }

    // Update is called once per frame
    void Update()
    {
        // Goblin=GameObject.FindGameObjectWithTag ("enemy");
        // if(Goblin!=null){
        //     //Debug.Log("find target");
        //     objectcomplete=false;
        // }
        // else{
        //     //Debug.Log("target dead");
        //     objectcomplete=true;
        // }
        //Debug.Log(Vector3.Distance(Player.transform.position,transform.position));
        
        if(Vector3.Distance(Player.transform.position,transform.position)<=lookRadius)
        {
            if(Input.GetKeyDown(KeyCode.F)){
                if(sentquest){
                    panel.SetActive(true);
                    //sentquest=false;
                    acceptbutton.SetActive(true);
                    //GameObject newacceptbutton = Instantiate(acceptbutton);
                    TextPro.text="Please help us to kill bog goblin, you can press M to find Bog goblin(red point) "
                        +Environment.NewLine+"The Bog Goblinwas last spotted in the Peter Curry marsh,wandering around muttering obscenities.";
                }
                 if(finishquest){
                    spawnplace.GetComponent<quest_update>().enabled = false;
                    panel.SetActive(true);
                    //finishquest=false;
                    finishbutton.SetActive(true);
                    // GameObject newfinishbutton = Instantiate(finishbutton);
                    TextPro.text="Congratulations on completing this quest!"+Environment.NewLine+"click finish button to collect your reward(firework show!)";
                }
                panel.SetActive(true);
            }
            //Debug.Log("prepare quest");
            // if(Input.GetKeyDown(KeyCode.F)){
            //     // Debug.Log("F down");
            //     showquest=true;
            //     panel.SetActive(true);
            // }
            // if(objectcomplete){
            //     //Debug.Log("quest completed");
            //     //content.text="object complete! thank you!";
            //     TextPro.text="object complete! thank you!";
            // }
            // else{
            //     //Debug.Log("quest released");
            //     //content.text="Please help us to kill bog goblin, you can press M to find Bog goblin(red point)";
            //     TextPro.text="Please help us to kill bog goblin, you can press M to find Bog goblin(red point)";
            //     }
        }
        else{
            //Debug.Log("???");
        }
    }
}
