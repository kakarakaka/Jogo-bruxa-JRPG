using UnityEngine;

public class ShopTrigger :
    MonoBehaviour
{
    public ShopData shopData;

    public void OpenShop()
    {
        ShopUI.Instance.OpenShop(
            shopData);
    }
}