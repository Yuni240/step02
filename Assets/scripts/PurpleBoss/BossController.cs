using UnityEngine;

public enum BossState
{
    enter,
    fire,
    special,
    death
}
public class BossController : MonoBehaviour
{
    [SerializeField] private bool test;
    [SerializeField] private BossState testState;
    [SerializeField] private BossEnter bossEnter;
    [SerializeField] private BossFire bossFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(test)
            ChangeState(testState);
    }
    public void ChangeState(BossState state)
    {
        switch (state)
        {

            case BossState.enter:
                // Debug.Log("Do something");
                bossEnter.RunState();
                break;
            case BossState.fire:
                // Debug.Log("Do something");
                bossFire.RunState();
                break;
            case BossState.special:
                Debug.Log("Do something");
                break;
            case BossState.death:
                Debug.Log("Do something");
                break;
        }
    }
  

}
