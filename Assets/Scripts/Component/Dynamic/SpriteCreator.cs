using UnityEngine;

static public class SpriteCreator {
    static public Sprite Create(Texture2D texture, int pixelsPerUnit = 100) {
        return Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            pixelsPerUnit
        );
    }
}