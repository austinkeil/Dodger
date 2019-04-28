using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class NewTestScript
    {
        [UnityTest]
        public IEnumerator MonoBehaviourTest_Works()
        {
            yield return new MonoBehaviourTest<MyMonoBehaviourTest>();
        }

        public class MyMonoBehaviourTest : MonoBehaviour, IMonoBehaviourTest
        {
            private int frameCount;
            public bool IsTestFinished
            {
                //get { return Input.GetButton("Jump"); }
                get { return frameCount > 10; }
            }

            void Update()
            {
                frameCount++;
            }
        }
        [UnityTest]
        public IEnumerator PlayerSpawnsAppropriately()
        {
            Debug.Log("it has at least done something");
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            yield return null; //skipps frame
            Debug.Log("loaded Game Scene");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //Debug.Log("player object", player);
            Debug.Log(player);
            Transform trns = player.GetComponent<Transform>();
            Vector3 actualPos = trns.position;
            Debug.Log("position");
            Debug.Log(actualPos);
            Vector3 startPos = new Vector3(-45f, 2.5f, 0f);
            //Vector3 actualPos = new Vector3(self.transform.position.x, self.transform.position.y, self.transform.position.z);
            Assert.AreEqual(startPos, actualPos, "player spawns as expected");
        }/*
        [UnityTest]
        public IEnumerator ProjectileCollisionWorks()
        {

        }*/
    }
}
