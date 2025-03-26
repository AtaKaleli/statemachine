using UnityEngine;

public class FlipController : MonoBehaviour
{
    public void Flip(Vector2 input)
    {
        if(Mathf.Abs(input.x) > 0)
            transform.parent.localScale = new Vector2(Mathf.Abs(transform.parent.localScale.x) * input.x, transform.parent.localScale.y);
    }
}
