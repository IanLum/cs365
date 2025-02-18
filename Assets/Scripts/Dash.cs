using System.Collections;
using UnityEngine;

public class Dash : MorseNote
{
    // time it takes for a dash to complete
    public const float DURATION = 0.5f;
    public const float DEFAULT_GLOW_WIDTH = 10f;
    // Width of the dash
    private float dash_width;
    private RectTransform glowRectTransform;
    private bool filling = false;


    protected override void Start()
    {
        dash_width = GetComponent<RectTransform>().rect.width;
        glowRectTransform = glowObj.GetComponent<RectTransform>();
        base.Start();
    }


    void Update()
    {
        if (filling)
        {
            float addedWidth = (dash_width - DEFAULT_GLOW_WIDTH) / DURATION * Time.deltaTime;
            glowRectTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Horizontal,
                glowRectTransform.rect.width + addedWidth
            );
        }
    }

    public override bool Activate()
    {
        if (filling)
        {
            CancelInvoke("Complete");
            return false;
        }

        base.Activate();
        // dashes complete after 3 seconds
        Invoke("Complete", DURATION);
        filling = true;
        return true;
    }

    // stop filling
    protected override void Complete()
    {
        base.Complete();
        filling = false;
    }

    // stop filling, reset glow width
    public override void Reset()
    {
        filling = false;
        base.Reset();
    }

    protected override IEnumerator Fade()
    {
        yield return base.Fade();
        glowRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, DEFAULT_GLOW_WIDTH);
    }
}
