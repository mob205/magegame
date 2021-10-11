using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] float uptime;
    [SerializeField] float downtime;

    private GameObject _activationObject;
    // Start is called before the first frame update
    void Start()
    {
        _activationObject = transform.GetChild(0).gameObject;
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        while (true)
        {
            yield return new WaitForSeconds(downtime);
            _activationObject.SetActive(true);
            yield return new WaitForSeconds(uptime);
            _activationObject.SetActive(false);
        }
    }
}
