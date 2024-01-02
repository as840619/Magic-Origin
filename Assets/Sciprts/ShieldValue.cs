using UnityEngine;
using TMPro;

public class ShieldValue : MonoBehaviour
{
    public int shieldCurrent;  //當前血量
    private TextMeshProUGUI shieldRemain;

    void Start()
    {
        shieldCurrent = transform.GetComponentInParent<PlayerHealth>().health;
    }

    void Update()
    {
        shieldCurrent = transform.GetComponentInParent<PlayerHealth>().health;
        //shieldCurrent = shieldRemain; //TODO 修改判斷 起始點 增加護盾
    }
}
