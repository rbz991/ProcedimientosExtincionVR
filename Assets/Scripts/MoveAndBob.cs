using UnityEngine;
using System.Collections;

public class MoveAndBob : MonoBehaviour
{

    public int MaxHP;
    public int VI_Value;
    public float moveSpeed = 2f;       // Speed of the initial upward movement
    public float targetY = 5f;         // Target y-position to move to after spawning
    public float targetDeathY = 20f;
    public float bobbingAmount = 0.5f; // Amplitude of the bobbing motion
    public float bobbingSpeed = 1f;    // Speed of the bobbing motion
    private float currentIteration;
    private float originalY;           // Original y-position for reference
    private bool reachedTarget;        // Flag to check if the initial move is completed
    private bool startBobbing;         // Flag to start bobbing after the delay
    private float phaseOffset;         // Offset to synchronize the start of the bobbing
    public int TargetHP;
    public bool isKillable = false;
    private int initialPhase;
    public Vector3 m_Velocity;
    void OnEnable()
    {
        // Initialize variables whenever the object is enabled (important for pooled objects)
        InitializeBobbing();
    }

    void Start()
    {
        // Ensure initialization even if not pooled
        initialPhase = PhaseManager.currentPhase;
        TargetHP = Random.Range(MaxHP - 2, MaxHP + 3);
       // Debug.Log("Target HP: " + TargetHP);


        if (PhaseManager.currentPhase == 1 || PhaseManager.currentPhase == 3 || PhaseManager.currentPhase == 5 || PhaseManager.currentPhase == 7 || PhaseManager.currentPhase == 9 || PhaseManager.currentPhase == 11)
        {
            if (Utilidades.startRich == true)
            {
                currentIteration = Utilidades.VIGen1(VI_Value) / 1000;
            }
            else
            {
                currentIteration = Utilidades.VIGen2(VI_Value) / 1000;
            }

         
        }
        if (PhaseManager.currentPhase == 2 || PhaseManager.currentPhase == 4 || PhaseManager.currentPhase == 6 || PhaseManager.currentPhase == 8 || PhaseManager.currentPhase == 10 || PhaseManager.currentPhase == 12)
        {
            if (Utilidades.startRich == true)
            {
                currentIteration = Utilidades.VIGen2(VI_Value) / 1000;
            }
            else
            {
                currentIteration = Utilidades.VIGen1(VI_Value) / 1000;
            }
        }

        StartCoroutine(CountVI_Value(currentIteration));
                InitializeBobbing();
    }

    IEnumerator CountVI_Value(float iteration)
    {
        yield return new WaitForSeconds(iteration);
        isKillable = true;
       // Debug.Log(isKillable);
    }




    void InitializeBobbing()
    {
        originalY = transform.position.y; // Store the current y position as the original
        reachedTarget = false;            // Reset the target reached flag
        startBobbing = false;             // Reset the bobbing start flag
        phaseOffset = 0f;                 // Reset the phase offset
    }

    void Update()
    {
        transform.Rotate(m_Velocity * Time.deltaTime);

        if (initialPhase == PhaseManager.currentPhase) 
        {
              if (!reachedTarget)
              {
                 MoveTowardsTarget();
              }
              else if (startBobbing)
              {
                  ContinueBobbing();
              }   
        }
        else
        {
            MoveTowardsDeath();
        }

    }

    void MoveTowardsTarget()
    {
        float newY = Mathf.MoveTowards(transform.position.y, originalY + targetY, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (Mathf.Abs(transform.position.y - (originalY + targetY)) < 0.01f)
        {
            reachedTarget = true;
            StartCoroutine(StartBobbingAfterDelay(0.1f)); // Start bobbing after a 0.5 second delay
        }
    }

    IEnumerator StartBobbingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        originalY = transform.position.y;
        startBobbing = true; // Enable bobbing
        phaseOffset = Time.time * bobbingSpeed + Mathf.PI ; // Correctly calculate phase offset to ensure smooth transition
    }

    void ContinueBobbing()
    {
        float bobbingY = originalY + Mathf.Sin(Time.time * bobbingSpeed - phaseOffset) * bobbingAmount;
        transform.position = new Vector3(transform.position.x, bobbingY, transform.position.z);
    }


    void MoveTowardsDeath()
    {
        float newY = Mathf.MoveTowards(transform.position.y, originalY + targetDeathY, (moveSpeed * 3) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (Mathf.Abs(transform.position.y - (originalY + targetDeathY)) < 0.01f)
        {
           Destroy(gameObject);
        }
    }

}
