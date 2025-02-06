using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkManager
{
    public void RemoteAtk(GameObject obj, float damage)
    {
        MonsterScriptable data =  obj.GetComponent<FindPathEnemy>().data;

        if(data == null )
            return;

        data.currentHp -= damage;

        //TODO 여기에서 체력 깎는 이벤트 보내기
    }
}
