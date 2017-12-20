using UnityEngine;
using System.Collections;

public class HealthBarTest : MonoBehaviour
{
    [SerializeField] float deduction = 10f;
    [SerializeField] float increment = 10f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Healthbar.instance.ReduceValue(deduction);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Healthbar.instance.IncreaseValue(increment);
        }
    }
}
