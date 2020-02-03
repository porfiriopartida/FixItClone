using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour
{
    public static bool isRunning = false;
    public int initialBrokenWindows = 5;
    private int currentBrokenWindows = 0;
    public GameObject windowsParent;

    public IntegerValue score;

    // Start is called before the first frame update
    void Start()
    {
        MainLoop.isRunning = false;

        setupBrokenWindows();

        score.value = 0;

        Time.timeScale = 1f;

        //MainLoop.isRunning = true;
    }

    void WindowUpdate(bool state) {
        if (state) {
            currentBrokenWindows++;
        } else {
            currentBrokenWindows--;
            if (MainLoop.isRunning)
            {
                score.value++;
            }
            checkWinCondition();
        }
    }
    private void checkWinCondition() {
        if (currentBrokenWindows == 0) {
            MainLoop.isRunning = false;
            setupBrokenWindows();
        }
    }

    private void setupBrokenWindows()
    {
        windowsParent.SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
        List<string> brokenWindows = new List<string>();
        while (brokenWindows.Count < initialBrokenWindows) {
            int x = UnityEngine.Random.Range(0, 4);
            int y = UnityEngine.Random.Range(0, 4);

            string objName = x.ToString() + y.ToString();
            if (!brokenWindows.Contains(objName)) {
                brokenWindows.Add(objName);
            }
        }

        for (int i = 0; i< brokenWindows.Count; i++) {
            GameObject window = GameObject.Find(brokenWindows[i]);
            WindowController wc = window.GetComponent<WindowController>();
            wc.breakIt();
            currentBrokenWindows++;
        }

        MainLoop.isRunning = true;
    }
    public void GameOver()
    {
        MainLoop.isRunning = false;

        Time.timeScale = 0.0f;

        StartCoroutine(waiter());


    }
    // Update is called once per frame
    public System.Collections.IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);

        SceneManager.LoadScene("Main");
    }
}
