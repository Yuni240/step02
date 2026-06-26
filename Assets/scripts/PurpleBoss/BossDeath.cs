using UnityEngine;
public class BossDeath : BossBaseState
{
    public override void RunState()
    {
        Debug.Log("BossDeath State");

        EndGameManager.endManager.StartResolveSequence();

        gameObject.SetActive(false);
    }
}