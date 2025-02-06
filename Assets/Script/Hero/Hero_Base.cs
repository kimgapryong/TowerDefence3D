using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Hero_Base : MonoBehaviour
{
    public enum HeroState
    {
        Atk,
        Idle,
        Cool,
    }
    protected Hero_Data data;
    GameObject parent;
    protected Hero_Controller heroController;
    protected List<GameObject> monList = new List<GameObject>();


    private HeroState _state = HeroState.Idle;
    public HeroState State { get { return _state; } set { _state = value; } }
    private float time = 0;

    protected GameObject currentMonster;

    protected virtual void Update()
    {
        switch (_state)
        {
            case HeroState.Cool:
                {
                    Debug.Log("coolTime");
                    time += Time.deltaTime;
                    if(time >= data.AtkCool)
                    {
                        time = 0;
                        State = HeroState.Idle;
                    }

                }
                break;
            case HeroState.Atk:
                Debug.Log("AtkTime");
                AtKHero();
                break;
            case HeroState.Idle:
                {
                    Debug.Log("IdleTime");
                    if (monList.Count > 0) 
                        State = HeroState.Atk;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
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
