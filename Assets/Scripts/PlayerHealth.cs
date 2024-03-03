using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100f;
    private float _maxValue;
    public RectTransform valueRectTransform;
    public GameObject GameOverUI;
    public GameObject GameplayUI;

    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }
    public void DealDamage(float Damage)
    {
        value -= Damage;

        if (value <= 0)
        {
            PlayerIsDead();
        }

        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    private void PlayerIsDead()
    {
        GameOverUI.SetActive(true);
        GameplayUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

}
