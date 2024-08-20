/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: August 2024
 * Description: 
 * To control the sound of player's footsteps based on their movements.
 */


using UnityEngine;

/// <summary>
/// Manages the playback of footstep sounds based on the player's movement.
/// </summary>
public class FootstepManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the AudioSource component used to play footstep sounds.
    /// </summary>
    public AudioSource footstepAudioSource;

    /// <summary>
    /// Array of AudioClip objects representing different footstep sounds.
    /// </summary>
    public AudioClip[] footstepClips;

    /// <summary>
    /// Time interval in seconds between consecutive footstep sounds.
    /// </summary>
    public float stepInterval = 0.5f;

    /// <summary>
    /// Timer to track time between footstep sounds.
    /// </summary>
    private float stepTimer;

    /// <summary>
    /// Reference to the CharacterController component attached to the player.
    /// </summary>
    private CharacterController characterController;

    /// <summary>
    /// Initializes the CharacterController reference and sets the initial step timer.
    /// </summary>
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        stepTimer = stepInterval;
    }

    /// <summary>
    /// Updates the step timer and plays a footstep sound if the player is moving.
    /// </summary>
    private void Update()
    {
        // Check if the character is moving
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            // Play footstep sound if enough time has passed
            if (stepTimer <= 0)
            {
                PlayFootstepSound();
                stepTimer = stepInterval; // Reset timer
            }
        }
    }

    /// <summary>
    /// Plays a random footstep sound from the array of footstep clips.
    /// </summary>
    private void PlayFootstepSound()
    {
        if (footstepClips.Length == 0 || footstepAudioSource == null)
            return;

        // Randomly select a footstep sound clip
        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
        footstepAudioSource.PlayOneShot(clip);
    }
}
