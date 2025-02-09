using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkManager
{
    public void RemoteAtk(Hero_Base hero, GameObject obj, float damage)
    {
       FindPathEnemy findPath = obj.GetComponent<FindPathEnemy>();

        if(findPath == null )
            return;

        findPath.currentHp -= damage;

        //죽음
        if( findPath.currentHp <= 0)
        {
            hero.DeathData(obj);   
            return;
        }

        //TODO 여기에서 체력 깎는 이벤트 보내기
        MapManager.Ui.EnemyBarSlider<UI_Enemy>(obj, findPath.currentHp, findPath.maxHp);
    }

    public void PoopAtk(Poop_Tower poop, float damage)
    {
        poop.current -= damage;

        GameObject obj = poop.gameObject;
        MapManager.Ui.EnemyBarSlider<UI_Tower>(obj, poop.current, poop.maxHp);
    }
}
