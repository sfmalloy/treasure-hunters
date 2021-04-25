using UnityEngine;

public class SpiderEnemy : MonoBehaviour, IEnemy
{
    public float topHeight;
    public float bottomHeight;
    [Range(0.01f, 0.03f)]
    public float speed = 0.01f;

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

        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + speed * dir);
    }

    public int DealDamage()
    {
        return 10;
    }
}
