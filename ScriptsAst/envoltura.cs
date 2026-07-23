using UnityEngine;

public class envoltura : MonoBehaviour
{
    private void Update()
    {
        Vector3 vewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveAdJustment = Vector3.zero;
        if (vewportPosition.x < 0)
        {
            moveAdJustment.x += 1;
        }
        else if (vewportPosition.x > 1)
        {
            moveAdJustment.x -= 1;
        }
        else if (vewportPosition.y < 0)
        {
            moveAdJustment.y += 1;
        }
        else if (vewportPosition.y > 1)
        {
            moveAdJustment.y -= 1;
        }


        transform.position = Camera.main.ViewportToWorldPoint(vewportPosition + moveAdJustment);
    }
}
