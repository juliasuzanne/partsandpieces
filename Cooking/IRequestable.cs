using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRequestable
{
    GameObject CurrentDish { get; set; }
    //     string DishName { get; set; }
    //     public GameObject ObjectToStack { get; set; }



    //     Transform GetStackPos();
    //     bool Stacked();
    void ResetChoice();
    void ChooseDish();

    //     void SpawnStack(GameObject prefab);
    //     void ChangeSecondName(string newName);
    //     bool SecondStacked();
    //     void ChangeSecondStacked();
    //     void SpawnThirdStack(GameObject prefab);

    //     void ChangeThirdName(string newName);

}