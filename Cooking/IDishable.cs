using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDishable
{
    Transform TargetPos { get; set; }
    string DishName { get; set; }
    public GameObject ObjectToStack { get; set; }
    string SecondDishName { get; set; }
    string ThirdDishName { get; set; }


    Transform GetStackPos();
    bool Stacked();
    GameObject GetGameObject();
    void ChangeStacked();
    void SpawnStack(GameObject prefab);
    void ChangeSecondName(string newName);
    bool SecondStacked();
    void ChangeSecondStacked();
    void SpawnThirdStack(GameObject prefab);

    void ChangeThirdName(string newName);

}