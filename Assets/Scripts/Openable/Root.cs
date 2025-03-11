using UnityEngine;

public class Root : Openable
{
    [SerializeField] private Animator rootAnimator;
    [SerializeField] private string rootAnimation = "RootRestore";
    [SerializeField] private ParticleSystem restoreParticles;

    public override void Open()
    {
        if (rootAnimator != null)
        {
            rootAnimator.Play(rootAnimation, 0, 0.0f);
            Debug.Log($"Restoring root: {gameObject.name}");
        }
        else
        {
            Debug.LogWarning($"No animator found for {gameObject.name}.");
        }

        if (restoreParticles != null)
        {
            restoreParticles.Play();
            Debug.Log($"{gameObject.name} is restoring with particle effect!");
        }
    }
}
