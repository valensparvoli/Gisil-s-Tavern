using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassAnimationMan : MonoBehaviour
{
    public Animator glassAnimator;

    public void EntregaAnimation()
    {
        glassAnimator.Play("entregarAnim");
    }

    public void DesscarteAnimation()
    {
        glassAnimator.Play("descarteAnim");
    }

}
