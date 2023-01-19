using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Unlock Data", menuName = "ScriptableObjects/UnlockData", order = 1)]
public class UnlockData : ScriptableObject
{

    public string unlockableName;

    public int price;
    public int CollectedPrice;
    public int RemainingPrice => price - CollectedPrice;
    

}
