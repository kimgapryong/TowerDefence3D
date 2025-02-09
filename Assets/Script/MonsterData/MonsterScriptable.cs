using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterData", menuName = "Monster/MonsterData")]
public class MonsterScriptable : ScriptableObject
{
    public float health;
    public float currentHp;
    public float speed;
    public float Money;
}
