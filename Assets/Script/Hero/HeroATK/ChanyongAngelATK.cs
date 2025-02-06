using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanyongAngelATK : Hero_Base
{
    public GameObject obj;

    private void Start()
    {
        obj = MapManager.Resources.Load<GameObject>("Prefab/Shooting/Heart");
    }
    protected override void Update()
    {
        if (currentMonster != null)
            heroController.gameObject.transform.LookAt(currentMonster.transform.position);
        base.Update();
        
    }
    protected override void AtKHero()
    {
        GameObject clone = Instantiate(obj, gameObject.transform.position, Quaternion.identity);
        Debug.Log(clone);

        if(currentMonster != null)
        {
            Vector3 dir = (currentMonster.transform.position - gameObject.transform.position).normalized;

            BulletSpeed bullet = Util.GetOrAddComponent<BulletSpeed>(clone);
            bullet.SetDirectory(dir);

            MapManager.Atk.RemoteAtk(currentMonster, data.Damage);
        }
           

        State = HeroState.Cool;

    }

}
