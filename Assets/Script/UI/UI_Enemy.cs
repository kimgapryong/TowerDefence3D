using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Enemy : UI_SliderBase
{
    private GameObject myEnemy;
    GameObject player;


    protected override void Start()
    {
        player = MapManager.Player;
        base.Start();
       
    }
    protected override void Update()
    {
        base.Update();
        UpdateUI();
    }
    public void SetMyEnemy(GameObject obj)
    {
        myEnemy = obj;
    }
    void UpdateUI()
    {
        /* Vector3 enemyUi_Pos = Camera.main.WorldToScreenPoint(myEnemy.transform.position);
         gameObject.transform.position = enemyUi_Pos + Vector3.up * (60 - Vector3.Distance(player.transform.position, myEnemy.transform.position));*/

        if(Vector3.Distance(player.transform.position, myEnemy.transform.position) > 8f)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
        }
        
    }
    
}
