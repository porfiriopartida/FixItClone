using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public const int MOVE_LEFT = 1;
    public const int MOVE_RIGHT = 2;
    public const int MOVE_FIRE = 3;

    private const int MAX_POSITION = 3; // 4 - 1 
    private const int MIN = 0;
    private int posX = 0, posY = 0;
    public GameObject bulletPrefab;
    public GameObject gun;

    public void Move(int command)
    {
        if (!MainLoop.isRunning)
        {
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
                Fire();
                break;
        }

        MoveTo(posX);
    }
    private void Fire() {
        GameObject go = GameObject.Instantiate(bulletPrefab);
        go.transform.position = gun.transform.position;
    }

    private void moveLeft()
    {
        if (posX > MIN)
        {
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
    /*
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
    private void MoveTo(int posX, int posY)
    {
        Debug.Log("Moving to: " + posX.ToString() + ", " + posY.ToString());
        string objName = posX.ToString() + posY.ToString();
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            transform.position = obj.transform.position;
        }
    }
    */
    private void MoveTo(int posX)
    {
        Debug.Log("Moving to: " + posX.ToString() + ", " + posY.ToString());
        string objName = posX.ToString() + posY.ToString();
        GameObject obj = GameObject.Find(objName);
        if (obj != null)
        {
            Vector2 newPosition = new Vector2(obj.transform.position.x, transform.position.y);
            transform.position = newPosition;
        }
    }
}
