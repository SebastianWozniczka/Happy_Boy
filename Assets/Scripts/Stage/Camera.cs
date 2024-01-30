using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;

    public Vector2 minValues, maxValue;
   
    public float smoothFactor;   
    void Update()
    {
        if (player != null)
        {
            Vector3 boundPosition = new Vector3(Mathf.Clamp(player.position.x, minValues.x, maxValue.x), Mathf.Clamp(player.position.y, minValues.y, maxValue.y), 0);
            Vector2 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = new Vector3(smoothPosition.x, smoothPosition.y, -10);
        }
    }
}
