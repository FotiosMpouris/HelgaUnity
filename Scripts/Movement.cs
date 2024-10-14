
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem boosterParticles;
    [SerializeField] ParticleSystem lBoosterParticles;
    [SerializeField] ParticleSystem rBoosterParticles;

    // [SerializeField] float rotationSpeed = 100f;
    Rigidbody rb;
    AudioSource audioSource;
    ParticleSystem playParticleSystem;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        playParticleSystem = GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessMovement();

    }

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            audioSource.Stop();
        }

    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
            boosterParticles.Play();
            
        }
    }

    void ProcessMovement()
    {
        StartThrustingRightLeft();
    }

    void StartThrustingRightLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb.AddRelativeForce(Vector3.left * mainThrust * Time.deltaTime);
            lBoosterParticles.Play();



        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddRelativeForce(Vector3.right * mainThrust * Time.deltaTime);
            rBoosterParticles.Play();
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            rBoosterParticles.Play();
            //Debug.Log("Playing mainEngine sound");
            //audioSource.PlayOneShot(mainEngine);
        }
    }


}
