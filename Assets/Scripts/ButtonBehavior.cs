using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private Transform container;
    private Transform craftItemTemplate;

    public int woodAmount;
    public int oreAmount;

    public int woodCost = 0;
    public int oreCost = 0;

    public bool axeOwned = false;
    public bool shieldOwned = false;
    public bool bowOwned = false;

    public void OnAxeCraftClick()
    {
        woodAmount = PlayerControl.woodCount;
        oreAmount = PlayerControl.oreCount;

        if (woodAmount > woodCost && oreAmount > oreCost)
        {
            axeOwned = true;
        }
    }
    public void OnShieldCraftClick()
    {
        woodAmount = PlayerControl.woodCount;
        oreAmount = PlayerControl.oreCount;

        if (woodAmount > woodCost && oreAmount > oreCost)
        {
            shieldOwned = true;
        }
    }
    public void OnBowCraftClick()
    {
        woodAmount = PlayerControl.woodCount;
        oreAmount = PlayerControl.oreCount;

        if (woodAmount > woodCost && oreAmount > oreCost)
        {
            bowOwned = true;
        }
    }
}
