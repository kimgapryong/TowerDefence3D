using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeroData", menuName = "Data")]
public class Hero_Data : ScriptableObject
{
    public int Money;
    public UI_Scene.Hero name;
    public Sprite Icon;
    public float Damage;
    public float Radious;
    public float AtkCool;
}
