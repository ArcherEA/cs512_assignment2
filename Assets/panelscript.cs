using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class panelscript : MonoBehaviour
{
     public GameObject panel;
     public GameObject helppanel;
     public GameObject accept_button;
     public GameObject finish_button;
     public GameObject goblin;
     public GameObject spawnplace;
     public GameObject firework;
     public GameObject npc;
     public npc npcscript;

    public void closepanel(){
        panel.SetActive(false);
    }
    public void showpanel(){
        panel.SetActive(true);
    }
    public void closehelppanel(){
        helppanel.SetActive(false);
    }
    public void showhelppanel(){
        helppanel.SetActive(true);
    }
    public void acceptbutton(){
        accept_button.SetActive(false);
        for(int i =0;i<=5;i++){
            GameObject newGoblin = Instantiate(goblin);
            Vector3 pos = new Vector3(Random.Range(spawnplace.transform.position.x-20.0f, spawnplace.transform.position.x+20.0f), 1f, Random.Range(spawnplace.transform.position.z-20.0f, spawnplace.transform.position.z+20.0f));
            newGoblin.transform.position = pos;
            newGoblin.SetActive(true);
        }
        spawnplace.GetComponent<quest_update>().enabled = true;
        npcscript.sentquest=false;

    }
    public void finishbutton(){
        finish_button.SetActive(false);
        panel.SetActive(false);
        for(int i =0;i<=7;i++){
            GameObject newfirework = Instantiate(firework);
            Vector3 pos = new Vector3(Random.Range(npc.transform.position.x-5.0f, npc.transform.position.x+5.0f), 1f, Random.Range(npc.transform.position.z-5.0f, npc.transform.position.z+5.0f));
            newfirework.transform.position = pos;
        }
        npcscript.finishquest=false;
    }
    // public void acceptquest(){
    //     helppanel.SetActive(true);
    // }
    public void mainmenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

}
