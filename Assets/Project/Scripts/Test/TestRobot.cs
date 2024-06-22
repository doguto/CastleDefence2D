using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRobot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.gameObject.tag = "Untagged";
        }
    }
}
