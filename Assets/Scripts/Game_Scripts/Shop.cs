using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Shop : MonoBehaviour
{
    public ObjectPool objectPool;

    public Button DoubleBulletBtn;
    public Button FireRateOneBtn;
    public Button FireRateTwoBtn;
    public Button ShopBtn;

    public RectTransform shopPanel;
    private bool shopPanelBool = true;

    public void ShopOpenClose(){
        if (shopPanelBool)
        {
            shopPanel.DOAnchorPos(Vector2.zero,0.5f);
            shopPanelBool = false;
        }
        else
        {
            shopPanel.DOAnchorPos(new Vector2(500,0),0.5f);
            shopPanelBool = true;
        }
    }

    public void DoubleBullet(){
        objectPool.BulletType(1);
        DoubleBulletBtn.interactable = false;
    }
    
    public void FireRateOne(){
        ShipStats.fireRate = 0.5f;
        FireRateOneBtn.interactable = false;
        FireRateTwoBtn.interactable = true;
    }

    public void FireRateTwo(){
        ShipStats.fireRate = 0.3f;
        FireRateTwoBtn.interactable = false;
    }
}
