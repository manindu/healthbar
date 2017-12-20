using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public static Healthbar instance;

    [SerializeField] Image barFill;
    [SerializeField] float transitionDuration = 0.5f;

    float health = 100f;

    void Awake()
    {
        instance = this;
    }

    public void ReduceValue(float deduction)
    {
        float targetValue = Mathf.Max(0, (health - deduction));
        StartCoroutine(LerpValue(health, targetValue, transitionDuration));
    }

    public void IncreaseValue(float increment)
    {
        float targetValue = Mathf.Min(100, (health + increment));
        StartCoroutine(LerpValue(health, targetValue, transitionDuration));
    }

    IEnumerator LerpValue(float currentValue, float targetValue, float duration)
    {
        float elapsed = 0f;
        while(elapsed < duration)
        {
            health = Mathf.Lerp(currentValue, targetValue, (elapsed / duration));
            barFill.fillAmount = health / 100f;
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        health = targetValue;
    }
}
