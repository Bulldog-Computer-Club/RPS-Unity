using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPS
{
    public class Weapon : MonoBehaviour
    {
        private Transform trs;
        private Animator anim;
        private GameManager gm;
        private GameObject[] otherWeapons;

        void Start()
        {
            trs = GetComponent<Transform>();
            anim = GetComponent<Animator>();
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            otherWeapons = CreateOtherWeaponArray();
        }

        public string weaponType;

        void OnMouseEnter()
        {
            if(gm.getWasClicked() == true) return;
            trs.localScale += new Vector3(0.35f, 0.35f, 0f);
        }

        void OnMouseExit()
        {
            if(gm.getWasClicked() == true) return;
            trs.localScale -= new Vector3(0.35f, 0.35f, 0f);
        }

        void OnMouseDown()
        {
            if(gm.getWasClicked() == true) return;
            
            gm.setWasClicked(true);
            anim.SetTrigger("Move");
            foreach(GameObject g in otherWeapons)
            {
                g.GetComponent<Animator>().SetBool("Fadeout", true);
                DisableAfterTime(0.25f, g);
            }
            gm.MainRPS(weaponType);
        }

        private GameObject[] CreateOtherWeaponArray()
        {
            List<GameObject> tList = new List<GameObject>(); 
            foreach(GameObject item in GameObject.FindGameObjectsWithTag("Weapon"))
            {
                if(item.name != gameObject.name) tList.Add(item);
            }

            return tList.ToArray();
        }

        IEnumerator DisableAfterTime(float time, GameObject g)
        {
            yield return new WaitForSeconds(time);
            g.SetActive(false);
        }
    }   
}
