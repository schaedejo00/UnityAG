using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Helper
{
    public enum States { NONE, BLUE, RED };
    struct Cooldown
    {
        public bool enabled;
        public float nextEvent;
        public float delay;
        public float calcNextEvent()
        {
            nextEvent = Time.time + delay;
            return nextEvent;
        }
        public bool isNextEvent() {
            return Time.time > nextEvent;
        }
    }
    struct DualCooldown
    {
        public bool enabled;
        private float nextEvent;
        private float endBlock;
        public float normalDelay;
        private bool block;
        public float blockedDelay;
        public float calcNextEvent()
        {
            nextEvent = Time.time + normalDelay;
            if (block) {
                nextEvent += tillEndofBlock(); 
            }
            return nextEvent;
        }
        public void blockCooldown()
        {
            endBlock = Time.time + blockedDelay;
            Debug.Log("blocked for "+endBlock+" at "+Time.time);
            block = true;
            
        }
        private float tillEndofBlock()
        {
            if (Time.time - endBlock > 0) {
                return Time.time - endBlock;
            }
            block = false;
            return 0;
        }
        public bool isNextEvent()
        {
            if (tillEndofBlock() == 0) {
                block = false;
            }
            Debug.Log(block);
            return Time.time > nextEvent;
        }
    }
    class Helpers {
        public static States StateFromGameObject(GameObject gameObject)
        {
            if (gameObject.transform.parent.GetComponent<TowerClient>() == null) {
                Debug.LogError("Towerclient is null");
                Debug.LogError(gameObject.name);    
                return States.NONE;
            }
            if (gameObject.tag == "Player")
            {
                return gameObject.transform.parent.GetComponent<TowerClient>().state;
            }
            return States.NONE;
        }
    }
    
}
