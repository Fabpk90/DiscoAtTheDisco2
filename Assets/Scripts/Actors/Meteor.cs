using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("PARAMETERS")]
    public float damages;
    //STORAGE
    public int hp;
    //REFERENCES
    private Rigidbody2D rigidBody;

    //SOUNDS
    [Header("SOUNDS")]
    public AK.Wwise.Event hitSound;
    public AK.Wwise.Event reduceSound;
    public AK.Wwise.Event moveSound;

    public void Init(Vector2 direction, float speed, int tHp) {
        Debug.Log("Instantiate meteor " + tHp);
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = direction * speed;
        hp = tHp;
        transform.localScale = new Vector3(GameManager.instance.meteorScales[hp], GameManager.instance.meteorScales[hp], GameManager.instance.meteorScales[hp]);
        //moveSound.Post(gameObject);
    }

    private void FixedUpdate() {
        Vector3 tmp = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(tmp.x, tmp.y, tmp.z + 1);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ship")) {
            GameManager.instance.ApplyDamages(damages * hp);
            Destroy(gameObject);
            hitSound.Post(gameObject);
        }
    }

    public bool Damage(int value) {
        hp -= value;

        print(hp);
        if(hp >= 0) {
            transform.localScale = new Vector3(GameManager.instance.meteorScales[hp], GameManager.instance.meteorScales[hp], GameManager.instance.meteorScales[hp]);
            reduceSound.Post(gameObject);
            return true;
        } else {
            print("destroyed");
            return false;
        }
    }
}
