using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Monster : MonoBehaviour
{
   public void CreateEnemy_UI(GameObject clone)
    {
        UI_Enemy enemyUi = MapManager.Ui.CreateUI<UI_Enemy>("Panel/Monster_Slider", transform);
        enemyUi.SetMyEnemy(clone);
    }
}
