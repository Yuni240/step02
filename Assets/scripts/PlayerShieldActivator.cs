using UnityEngine;

public class PlayerShieldActivator : MonoBehaviour
{
    [SerializeField] private Shield shield;

    public void ActivateShield()
    {
        Debug.Log("ActivateShield inaitwa!");
        Debug.Log("Shield active: " + shield.gameObject.activeSelf);

        if (shield.gameObject.activeSelf == false)
        {
            shield.gameObject.SetActive(true);
            Debug.Log("Shield imewashwa!");
        }
        else
        {
            shield.RepairShield();
            Debug.Log("Shield imerepairwa!");
        }
    }
}
