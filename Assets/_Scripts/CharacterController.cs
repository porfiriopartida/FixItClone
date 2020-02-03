using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const int MAX_POSITION = 3; // 4 - 1 
    private const int MIN = 0;
    private int posX = 0, posY = 0;
    public GameObject windows;
    public MainLoop facade;

    public void Move(int command)
    {
        if (!MainLoop.isRunning) {
            return;
        }
        switch (command)
        {
            case 1:
                moveLeft();
                break;
            case 2:
                moveRight();
                break;
            case 3:
                moveUp();
                break;
            case 4:
                moveDown();
                break;
            case 5:
                Fire();
                break;
        }
        MoveTo(posX, posY);
    }

    private void Fire()
    {
        string objName = posX.ToString() + posY.ToString();
        GameObject obj = GameObject.Find(objName);
        WindowController wc = obj.GetComponent<WindowController>();
        wc.fixIt();
        //GameObject.Instantiate(bulletPrefab, gun.transform, false);
    }
    private void MoveTo(int posX, int posY)
    {
        Debug.Log("Moving to: " + posX.ToString() + ", " + posY.ToString());
        string objName = posX.ToString() + posY.ToString();
        GameObject obj = GameObject.Find(objName);
        if (obj != null) { 
            transform.position = obj.transform.position;
        }
    }

    private void moveLeft()
    {
        if (posX > MIN) {
            posX--;
        }
    }
    private void moveRight()
    {
        if (posX < MAX_POSITION)
        {
            posX++;
        }
    }
    private void moveUp()
    {
        if (posY < MAX_POSITION)
        {
            posY++;
        }
    }
    private void moveDown()
    {
        if (posY > MIN)
        {
            posY--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard") { 
            Destroy(collision.gameObject); //some hazard hit the character.

            facade.GameOver();
        }
    }
}
