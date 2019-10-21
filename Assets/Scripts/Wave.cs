using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Wave : MonoBehaviour
    {
        public float alpha = 0;
        private float timer = 1.0f;
        private SpriteRenderer sprite;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            Vector3 scale = transform.localScale;
            scale.x += Time.deltaTime*1.5f;
            scale.y += Time.deltaTime*1.5f;

            transform.localScale = scale;
            Debug.Log(alpha);
            timer -= Time.deltaTime;
            var spriteColor = sprite.color;
            spriteColor.a = alpha * timer;
            sprite.color = spriteColor;
        }
    }
}