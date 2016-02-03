using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Notifier : MonoBehaviour {

    [System.Serializable]
    public class GameObjectCallback : UnityEvent<GameObject> {}

    public UnityEvent notify;
    public GameObjectCallback notifyGameObject;

    public void Notify() {
        notify.Invoke();
        notifyGameObject.Invoke(gameObject);
    }

}
