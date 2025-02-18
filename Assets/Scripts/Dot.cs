using UnityEngine;
public class Dot : MorseNote
{
    // dots complete as soon as they are activated
    public override void Activate()
    {
        base.Activate();
        Complete();
    }
}
