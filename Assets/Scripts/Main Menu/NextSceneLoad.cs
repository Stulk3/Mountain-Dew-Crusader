using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class NextSceneLoad : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Õףי");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
