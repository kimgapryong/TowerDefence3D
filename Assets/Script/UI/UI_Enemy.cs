using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Enemy : UI_Base
{
    private GameObject myEnemy;
    GameObject player;
    enum Sliders
    {
        Monster_Health,
    }
    enum Texts
    {

    }
    private void Start()
    {
        player = MapManager.Player;
        Bind<Slider>(typeof(Sliders));
    }
    private void Update()
    {
        UpdateUI();
    }
    public void SetMyEnemy(GameObject obj)
    {
        myEnemy = obj;
    }
    void UpdateUI()
    {
        Vector3 enemyUi_Pos = Camera.main.WorldToScreenPoint(myEnemy.transform.position);
        gameObject.transform.position = enemyUi_Pos + Vector3.up * (60 - Vector3.Distance(player.transform.position, myEnemy.transform.position));

        if(Vector3.Distance(player.transform.position, myEnemy.transform.position) > 8f)
        {
            Get<Slider>((int)Sliders.Monster_Health).gameObject.SetActive(false);
        }
        else
        {
            Get<Slider>((int)Sliders.Monster_Health).gameObject.SetActive(true);
        }
    }
    
}
