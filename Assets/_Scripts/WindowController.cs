using UnityEngine;

public class WindowController : MonoBehaviour
{
    public MainLoop facade;
    public GameObject brokenWindow;

    // Start is called before the first frame update
    void Start()
    {
        facade = GameObject.Find("Facade").GetComponent<MainLoop>();

        //Reset();
    }
    public void fixIt()
    {
        if (brokenWindow.activeSelf)
        {
            brokenWindow.SetActive(false);
            if (MainLoop.isRunning) { 
                facade.SendMessage("WindowUpdate", false);
            }
        }
    }
    public void breakIt()
    {
        if (!brokenWindow.activeSelf)
        {
            brokenWindow.SetActive(true);
            if (MainLoop.isRunning)
            {
                facade.SendMessage("WindowUpdate", true);
            }
        }
    }
    public void Reset()
    {
        brokenWindow.SetActive(false);
    }
    /*
    public void toggle()
    {
        brokenWindow.SetActive(!brokenWindow.activeSelf);
    }
    */
}
