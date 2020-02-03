using UnityEngine;

public class EnemyInputController : MonoBehaviour
{
    private EnemyController enemyController;
    public AI ai;
    public AI playerAI;

    public bool isPlayer = false; //move to so

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public void togglePlayer() {
        isPlayer = !isPlayer;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            playerAI.Think(enemyController);
        }
        else
        {
            ai.Think(enemyController);
        }
        
    }
}
