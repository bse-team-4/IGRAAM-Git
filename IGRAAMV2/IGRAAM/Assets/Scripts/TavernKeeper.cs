using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavernKeeper : MonoBehaviour
{
    Vector3 TavernKeeperToPlayer;
    public GameObject thePlayer;
    public GameObject PartyMember;
    Player playerscript;
    float DistanceToPlayer;
    public Canvas TavernKeeperCanvas1;
    public Canvas TavernKeeperCanvas2;
    public Button Btn1, Btn2, Btn3;
    bool BoughtMem1, BoughtMem2, BoughtMem3;
     
    // Start is called before the first frame update
    void Start()
    {
        BoughtMem1 = BoughtMem2 = BoughtMem3 = false;
        //thePlayer = GameObject.Find("Player");
        playerscript = thePlayer.GetComponent<Player>();
        TavernKeeperCanvas1.gameObject.SetActive(false);
        TavernKeeperCanvas2.gameObject.SetActive(false);
        Btn1.onClick.AddListener(BuyingPartyMem1);
        Btn2.onClick.AddListener(BuyingPartyMem2);
        Btn3.onClick.AddListener(BuyingPartyMem3);

    }

    // Update is called once per frame
    void Update()
    {
        TavernKeeperToPlayer = this.transform.position - thePlayer.transform.position;
        DistanceToPlayer = TavernKeeperToPlayer.magnitude;
        if (DistanceToPlayer <= 5)
        {
            //Display UI (press space to talk)
            TavernKeeperCanvas1.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Display tavern keeper UI
                TavernKeeperCanvas2.gameObject.SetActive(true);
            }

        }
        else
        {
            //Clear UI
            TavernKeeperCanvas1.gameObject.SetActive(false);
            TavernKeeperCanvas2.gameObject.SetActive(false);
        }
    }

    void BuyingPartyMem1()
    {
        if(BoughtMem1 == false && playerscript.GoldAmount >= 100)
        {
            //Buying PartyMember 1
            //Should spawn a party member with low health?

            BoughtMem1 = true;
            playerscript.GoldAmount -= 100;
            return;
        }
    }

    void BuyingPartyMem2()
    {
        if (BoughtMem2 == false && playerscript.GoldAmount >= 200)
        {
            //Buying PartyMember 2
            //Should spawn a party member with med health?
            BoughtMem2 = true;
            playerscript.GoldAmount -= 200;
            GameObject PartyMember1 = Instantiate(PartyMember, new Vector3(3.95f, 0.76f, -8.3f), Quaternion.identity);
            PartyMemberControl PartyMemberCon1 = PartyMember1.GetComponent<PartyMemberControl>();
            PartyMemberCon1.Health = 150;
            PartyMemberCon1.Damage = 75;
            //test if code is working
            PartyMember1.transform.localScale = new Vector3(2,2,2);
            return;

        }
    }

    void BuyingPartyMem3()
    {
        if (BoughtMem3 == false && playerscript.GoldAmount >= 300)
        {
            //Buying PartyMember 3
            //Should spawn a party member with high health?
            BoughtMem3 = true;
            playerscript.GoldAmount -= 300;
            return;
        }
    }
}


