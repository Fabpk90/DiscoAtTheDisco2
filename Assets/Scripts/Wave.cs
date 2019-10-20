using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Wave : MonoBehaviour
    {
        public float alpha = 1.0f;
        private SpriteRenderer sprite;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            Vector3 scale = transform.localScale;
            scale.x += Time.deltaTime;
            scale.y += Time.deltaTime;

            transform.localScale = scale;

            alpha -= Time.deltaTime / 3;
            var spriteColor = sprite.color;
            spriteColor.a = alpha;
            sprite.color = spriteColor;
        }
    }
}