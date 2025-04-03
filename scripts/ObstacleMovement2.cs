using UnityEngine;

public class ObstacleMovement2 : MonoBehaviour
{
    public float speed = 1.4f;
    public float height = 2f;

    private Vector3 StartPosition;

    private void Start()
    {
       StartPosition =  transform.position;
    }

    private void Update()
    {
        float offset = Mathf.PingPong(Time.time *speed, height);
        transform.position = new Vector3(StartPosition.x, StartPosition.y - offset, StartPosition.z);
    }

}
