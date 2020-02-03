using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchValue : MonoBehaviour
{
    public string format = "Score: {0}";
    public IntegerValue score;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = string.Format(format, score.value);
    }
}
