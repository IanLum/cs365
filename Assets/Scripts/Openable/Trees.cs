using UnityEngine;

public class Trees : Openable
{
    [SerializeField] private Animator treeAnimator;
    [SerializeField] private string restoreAnimation = "TreeRestore";
    [SerializeField] private ParticleSystem restoreParticles;

    public override void Open()
    {
        if (treeAnimator != null)
        {
            treeAnimator.Play(restoreAnimation, 0, 0.0f);
            Debug.Log($"Restoring tree: {gameObject.name}");
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
