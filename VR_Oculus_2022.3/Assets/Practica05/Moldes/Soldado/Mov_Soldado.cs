using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Mov_Soldado : MonoBehaviour
{
    public Transform user;
    private NavMeshAgent enemyAgent;
    public bool UserDetect, UserPunch, UserStun;
    private Animator enemyAnimator;
    public string nombreEscenaACargar;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {



        if (other.CompareTag("PlayerRun"))
        {
            UserDetect = true;
        }
       
        if (other.CompareTag("PlayerPunch"))
        {
            UserPunch = true;
        }
       
        if (other.CompareTag("PlayerStun"))
        {
            UserStun = true;
        }
      
    }
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (UserDetect)
        {
            enemyAgent.destination = user.position;
            enemyAnimator.SetBool("Accion", true);

            if (UserPunch)
            {
                enemyAgent.destination = transform.position;
                enemyAnimator.SetBool("Golpe", true);
                Invoke("EndPunch", 3f);
            }

            if (UserStun)
            {
                enemyAgent.destination = transform.position;
                enemyAnimator.SetBool("Stun", true);
                Invoke("EndStun", 5f);
            }
        }

        


    }

    void EndPunch()
    {
        SceneManager.LoadScene(nombreEscenaACargar);
        UserPunch = false;
        enemyAnimator.SetBool("Golpe", false);
        PlayerPrefs.SetInt("Game", 0);
        PlayerPrefs.Save();


    }   

    void EndStun()
    {
        UserStun = false;
        enemyAnimator.SetBool("Stun", false);
    }

}
