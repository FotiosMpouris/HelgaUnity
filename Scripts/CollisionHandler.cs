using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticles;
    //[SerializeField] ParticleSystem obstacleParticles;

    SceneManager sceneManager;
    AudioSource audioSource;
    ParticleSystem playParticleSystem;
    Rigidbody rb;

    bool isTransitioning = false;
    //bool collisionDisable = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playParticleSystem = GetComponent<ParticleSystem>();
        // obstacleParticles.Play();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        LKeyPress();
        //CKeyPress();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                //Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                
                break;
            case "Ground":
                StartCrashSequence();
                break;
            default:
                StartCrashSequence();
                break;

        }
    }
    void StartSuccessSequence()
    {
        SuccessStartMethod();
    }

    void SuccessStartMethod()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        isTransitioning = true;
        successParticles.Play();
        
       
    }

    void StartCrashSequence()
    {
        CrashStartSequence();

    }

    private void CrashStartSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        isTransitioning = true;
        crashParticle.Play();
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        
    }
    void LKeyPress()
    {

        if (Input.GetKey(KeyCode.L))
        {
            //Debug.Log("left key pressed");
            LoadNextLevel();
        }

    }

}
