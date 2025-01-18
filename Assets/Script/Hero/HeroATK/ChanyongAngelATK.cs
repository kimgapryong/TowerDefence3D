using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanyongAngelATK : Hero_Base
{
    GameObject obj;
    Transform fire;

    private void Start()
    {
        obj = MapManager.Resources.Load<GameObject>("Prefab/Shooting/Heart");
    }
    private void Update()
    {
        if(currentMonster != null)
            heroController.gameObject.transform.LookAt(currentMonster.transform.position);
    }
    protected override void AtKHero()
    {
        

    }

}
