using UnityEngine;

public class SpikeEnemy : MonoBehaviour, IEnemy
{
    public void IdleMovement()
    {   }
    
    public void AttackMovement()
    {   }

    public int DealDamage()
    {
        return 50;
    }
}
