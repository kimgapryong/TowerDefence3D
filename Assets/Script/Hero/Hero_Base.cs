using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Hero_Base : MonoBehaviour
{
    protected Hero_Data data;
    GameObject parent;
    protected Hero_Controller heroController;
    protected List<GameObject> monList = new List<GameObject>();

    protected GameObject currentMonster;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("¾ÈµÅ");
            monList.Add(other.gameObject);
            if(currentMonster == null || monList.Count == 1)
                currentMonster = monList[0];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("³ª°¨");
            monList.Remove(other.gameObject);
            monList = monList.OrderBy(x => Vector3.Distance(x.transform.position,parent.transform.position)).ToList();
            if(monList.Count > 0 && other.gameObject == currentMonster)
                currentMonster = monList[0];
            Debug.Log(monList.Count);
        }
    }
    public void setData(Hero_Data data)
    {
        this.data = data;
        parent = transform.parent.gameObject;
        heroController = parent.GetComponent<Hero_Controller>();
    }
    protected abstract void AtKHero();
}
