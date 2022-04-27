using UnityEngine;

public class Moving : MonoBehaviour
{
    bool move, _combine;
    int _x2, _y2;

    void Update() { if (move) Move(_x2, _y2, _combine); }

    public void Move(int x2, int y2, bool combine)
    {
        move = true; _x2 = x2; _y2 = y2; _combine = combine;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.2f * x2 - 1.8f, 1.2f * y2 - 1.8f, 0), 0.3f);
        if (transform.position == new Vector3(1.2f * x2 - 1.8f, 1.2f * y2 - 1.8f, 0))
        {
            move = false;
            if (combine) { _combine = false; Destroy(gameObject); }
        }
    }
}
