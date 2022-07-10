using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField]
    private Transform leftEdge;
    [SerializeField]
    private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField]
    private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField]
    private float speed;
    private Vector3 initScale;



    private void Awake()
    {
        initScale = enemy.localScale;
    }


    private void Update()
    {
        MoveInDirection(1);
    }
    private void MoveInDirection(int _direction)
    {
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs( initScale.x) * _direction, initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
           enemy.position.y, enemy.position.z);
    }
}
