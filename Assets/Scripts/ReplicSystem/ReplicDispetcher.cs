using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
public class ReplicDispetcher : MonoBehaviour
{
    [SerializeField] private GameObject replicPanel;
    [SerializeField] private Text replicText;

    private List<ReplicItem> replicas;
    private AudioSource source;
    private ReplicItem bufer;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        replicas = new List<ReplicItem>();
        source = GetComponent<AudioSource>();
        replicText.CrossFadeAlpha(0, 0, false);
        replicPanel.SetActive(false);
    }

    public void AddInList(List<ReplicItem> items)
    {
        replicas.AddRange(items);
        if(bufer == null)
        {
            replicPanel.SetActive(true);
          //  skipImage.enabled = false;
            StartCoroutine(CheckReplicas(0));
        }
    }
    public IEnumerator CheckReplicas(float time)
    {
        yield return new WaitForSeconds(time);
        bufer?.afterReplicaAction?.Invoke();
        source.Stop();

        if (replicas.Count > 0)
            StartReplica();
        else
        {
            bufer = null;
            replicText.CrossFadeAlpha(0, 0.5f, true);
            yield return new WaitForSeconds(0.6f);
            replicText.text = string.Empty;
            replicPanel.SetActive(false);
        }
    }
    private void StartReplica()
    {
        bufer = replicas[0];
        source.clip = bufer.clip;
        replicText.text = bufer.replicText;
        replicText.color = bufer.role.roleTextColor;
        source.Play();
        StartCoroutine(CheckReplicas(source.clip.length + 0.3f));
        replicas.Remove(replicas[0]);
    }
}

[Serializable]
public class ReplicItem
{
    public ReplicaRole role;
   // public Transform playerTarget;
    public AudioClip clip;
    public string replicText;
    public UnityEvent afterReplicaAction;
}

