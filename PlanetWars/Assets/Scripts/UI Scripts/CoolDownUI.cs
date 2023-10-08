using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoolDownUI : MonoBehaviour
{
    public PlayerController player1;

    public TextMeshProUGUI cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player1 != null)
        {
            cooldownTimer.text = player1.dashCooldown.ToString();
        }
    }
}
