using System.Runtime.InteropServices;
using UnityEngine;
public class Dot : MorseNote
{
    // dots complete as soon as they are activated
    public override bool Activate()
    {
        base.Activate();
        // One frame delay on Complete call to allow [MorseeSequence] to
        // sucessfully hear a knock before listening for the next knock.
        // See invoke calls on "ResetSequence"
        Invoke("Complete", 0f);
        return true;
    }
}
