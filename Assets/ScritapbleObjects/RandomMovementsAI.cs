using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomMovementsAI", menuName = "FixIt/AI/RandomAI")]
public class RandomMovementsAI : AI
{
    public float actionsDelay = .25f;
    public float restDelay = 1.5f;
    public int restAfterMoves = 5;

    [NonSerialized]
    public float waiting = 0;
    [NonSerialized]
    public int currentMoves = 0;
    public void Awake() {
        waiting = 0;
        currentMoves = 0;
    }

    // Update is called once per frame
    public override void Think(EnemyController enemyController)
    {
        if (waiting - Time.time > 0) {
            return;
        }

        waiting = Time.time + actionsDelay;

        int randomCommand = UnityEngine.Random.Range(1, 3); // Move left, right
        enemyController.Move(randomCommand);
        enemyController.Move(EnemyController.MOVE_FIRE); // Fire
        if (++currentMoves >= restAfterMoves) {
            waiting = Time.time + restDelay;
            currentMoves = 0;
        }
    }
}
