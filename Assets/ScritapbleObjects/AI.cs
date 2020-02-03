using UnityEngine;

public abstract class AI : ScriptableObject
{
    public abstract void Think(EnemyController enemyController);
}
