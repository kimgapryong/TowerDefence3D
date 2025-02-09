using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop_Tower : MonoBehaviour
{
    public float maxHp;
    public float current;
    public void SetPoopTower(GameObject obj, int x, int z, float stageHp)
    {
        maxHp = stageHp;
        current = maxHp;

        obj.transform.position  = new Vector3(x * 2, 2, z * 2);
        UI_Tower tower = MapManager.Ui.CreateUI<UI_Tower>("Enemy_Bar", obj.transform);
        tower.name = tower.name.Replace("(Clone)", "");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            MapManager.Atk.PoopAtk(this, collision.gameObject.GetComponent<FindPathEnemy>().currentHp);
        }
    }

}
