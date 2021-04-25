using UnityEngine;

public class SpiderEnemy : MonoBehaviour, IEnemy
{
    public float topHeight;
    public float bottomHeight;

    int dir;
    bool goingDown;
    void Start()
    {
        dir = 1;
        goingDown = false;
    }

    void Update()
    {
       AttackMovement();
    }

    public void AttackMovement()
    {  
        if (!goingDown && transform.localPosition.y >= topHeight)
        {
            goingDown = true;
            dir = -1;
        }
        else if (goingDown && transform.localPosition.y <= bottomHeight)
        {
            goingDown = false;
            dir = 1;
        }

        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + 0.05f * dir);
    }

    public int DealDamage()
    {
        return 10;
    }
}
