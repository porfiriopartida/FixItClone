using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControlledAI", menuName = "FixIt/AI/PlayerControlledAI")]
public class EnemyPlayerAI : AI
{
    // Update is called once per frame
    public override void Think(EnemyController enemyController)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            enemyController.Move(1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //networkHandler.move(2);
            enemyController.Move(2);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //networkHandler.move(2);
            enemyController.Move(3);
        }
    }
}
