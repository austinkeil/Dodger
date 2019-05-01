using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


namespace Tests
{
    //boiler plate code from unity manuel
    public class TestMono{
    [UnityTest]
        public IEnumerator MonoBehaviourTest_Works()
        {
            yield return new MonoBehaviourTest<MyMonoBehaviourTest>();

        }
    }
    
    public class MyMonoBehaviourTest : MonoBehaviour, IMonoBehaviourTest
    { 
        //boiler plate code from unity manuel
        
        public float timeLeft = 5f;
        
        private int frameCount;
        public bool IsTestFinished
        {
          //  get { return frameCount > 10; }
           get { return timeLeft < 0; }
        }

         void Update()
         {
            frameCount++;
            
            timeLeft -= Time.deltaTime;
            
         }
        
        [UnityTest]
        public IEnumerator TestNewHighScore()
        {
            //loads the leaderboard scene
            SceneManager.LoadScene("LeaderBoard", LoadSceneMode.Single);
            
            //wait for first frame to load
            yield return null;
            
            //get current difficulty
            int previousDifficulty = PlayerPrefs.GetInt("Difficulty");
            
            for (int i = 0; i < 3; i++){
                
                //test setting a new high score for each difficulty
                PlayerPrefs.SetInt("Difficulty", i);
                PlayerPrefs.SetInt("LeaderBoard", i);
                //Debug.Log("i for run #" + i.ToString() + " difficulty: " + PlayerPrefs.GetInt("Difficulty").ToString());
                
                //get current high score/name
                string TestPlayerName = "TestPlayer";
                int prevHighScore = Convert.ToInt32(PlayerPrefs.GetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Score1"));
                string prevName = PlayerPrefs.GetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Name1");
                
                
                
                //set expected new high score (just one more than the previous high score) and names
                int expectedNewHighScore = prevHighScore + 1;
                PlayerPrefs.SetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Score1", expectedNewHighScore.ToString());
                PlayerPrefs.SetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Name1", TestPlayerName);
                PlayerPrefs.SetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Score2", prevHighScore.ToString());
                PlayerPrefs.SetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Name2", prevName);
                
                //get new scores of first & second place
                int newHighScore = Convert.ToInt32(PlayerPrefs.GetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Score1"));
                int new2ndPlaceHighScore = Convert.ToInt32(PlayerPrefs.GetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Score2"));
                
                //compare new high score & expected high score
                Assert.AreEqual(newHighScore, expectedNewHighScore, "New high score read doesnt match expected high score");
                
                //compare new 2nd place score & expected 2nd place score
                Assert.AreEqual(new2ndPlaceHighScore, prevHighScore, "New second place score doesnt match expected second place score");
                
                //get names of first & second place
                string newHighScoreName = PlayerPrefs.GetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Name1");
                string new2ndPlaceScoreName = PlayerPrefs.GetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Name2");
                
                //compare new high score name & expected high score name
                Assert.AreEqual(newHighScoreName, TestPlayerName, "New high score name read doesnt match expected high score name");
                //compare new 2nd place name & expected 2nd place name
                Assert.AreEqual(new2ndPlaceScoreName, prevName, "New second place name doesnt match expected second place name");
            }
            //set the difficulty back to the previous difficulty
            PlayerPrefs.SetInt("Difficulty", previousDifficulty);
        }
        
        [UnityTest]
        public IEnumerator TestPlayerStartingLocation()
        {
            //load the main game scene
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            
            //wait for first frame to load
            yield return null;
            
            //the expected start position
            Vector3 expectedPosition = new Vector3(-45.0f, 2.5f, 0.0f);
            
            //get the player's position
            var player = GameObject.FindGameObjectWithTag("Player");
            var transform = player.GetComponent<Transform>();
            Vector3 position = transform.position;
            //Debug.Log(position);
            
            //assert that the player's position == the expected position
            Assert.AreEqual(position, expectedPosition);
                      
        }
        [UnityTest]
        public IEnumerator TestStartGameWorks()
        {
            Debug.Log("test has started");
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
            yield return null;
            Debug.Log("loaded menu scene");
            var startButton = GameObject.FindGameObjectWithTag("StartButton").GetComponent<Button>();
            Debug.Log("found start button");
            Debug.Log(startButton);
            yield return null;
            startButton.onClick.Invoke();
            yield return null;
            Scene current = SceneManager.GetActiveScene();
            String currentName = current.name;
            String expectedName = "GameScene";
            Assert.AreEqual(expectedName, currentName);

        }
        
        
        [UnityTest]
        public IEnumerator TestSkinChanged()
        {
            SceneManager.LoadScene("GameScene");
            
            yield return null;

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.GetComponent<Rigidbody>().isKinematic = true;
            
            Material playerMaterial = player.GetComponent<MeshRenderer>().material;

            yield return null;

            GameObject evilProjectile;
            while (GameObject.FindGameObjectWithTag("EvilProjectile") == null)
            {
                

                yield return new WaitForSeconds(1);

            }
            
            evilProjectile = GameObject.FindGameObjectWithTag("EvilProjectile");

            Material projectileMaterial = evilProjectile.GetComponent<MeshRenderer>().material;
            
            SceneManager.LoadScene("SettingsMenu");
            yield return null;

            Dropdown skinDropdown = GameObject.FindGameObjectWithTag("SkinDropdown").GetComponent<Dropdown>();

            // change the dropdown menu to the next item mod # of items on menu
            skinDropdown.onValueChanged.Invoke(PlayerPrefs.GetInt("Skin") + 1 % skinDropdown.options.Count);          
            
            SceneManager.LoadScene("GameScene");
            
            yield return null;
            
            player = GameObject.FindGameObjectWithTag("Player");


            while (GameObject.FindGameObjectWithTag("EvilProjectile") == null)
            {
                

                yield return new WaitForSeconds(1);

            }
            evilProjectile = GameObject.FindGameObjectWithTag("EvilProjectile");
            
            Assert.AreNotEqual(playerMaterial, player.GetComponent<MeshRenderer>().material);

            Assert.AreNotEqual(projectileMaterial, evilProjectile.GetComponent<MeshRenderer>().material);

        }

    }
    
    //boiler plate code generated with the test script
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
        
        
        
        
    }

    /*public class TestSkin : MonoBehaviour, IMonoBehaviourTest
    {

        public float timeLeft = 30f;
        public bool IsTestFinished
        {
            get { return timeLeft > 10; }
        }
        

     
        void Update()
        {
            timeLeft -= Time.deltaTime;
        }

        


    }
*/

}
