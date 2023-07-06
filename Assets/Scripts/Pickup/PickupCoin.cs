using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : Pickup
{
    public override void PickMeUp()
    {
        Inventory.currenCoins++;
        UIManager.UpdateCoins();
        gameObject.SetActive(false);
    }
}
