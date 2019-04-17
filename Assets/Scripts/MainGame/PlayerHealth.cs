using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public Text deathText;										// Reference to the text displayed on the screen when the player dies.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 6f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.2f);     // The colour the damageImage is set to, to flash.
	public Color deathTextColor = new Color(.43f, .15f, .15f);	//The color of the death text

    public GameObject playerNamePanel;
	
    public GameObject deathMenu;
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.
    public bool isDead;                                         // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    public Image fill;


    void Awake ()
    {
        // Setting up the references.
        //playerAudio = GetComponent <AudioSource> ();

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }


    void Update ()
    {
        // If the player has just been damaged...
        if(damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play ();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if(currentHealth <= 0 && !isDead)
        {
            // ... they should die.
            Death ();
        }
    }


    void Death ()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
		
		// Change the deathText color to dark red
        deathText.color = deathTextColor;

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play ();

        // Turn off the movement and shooting scripts -- for our project we should figure out something comperable
        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
        fill.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		Debug.Log("You died!");


        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().CheckScore();
        
        Debug.Log("enabling death menu");
        // Ask if they would like to start again or quit
        deathMenu.SetActive(true);
        
    }   

}