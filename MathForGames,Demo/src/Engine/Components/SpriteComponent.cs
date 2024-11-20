using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using MathLibrary;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames_Demo
{
    internal class SpriteComponent : Component
    {
        private Texture2D _texture;
        private string _path;

        public SpriteComponent(Actor owner, string path = "") : base(owner)
        {
            _path = path;
        }

        public override void Start()
        {
            base.Start();
            _texture = Raylib.LoadTexture(_path);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Vector2 offset = new Vector2(_texture.Width / 2, _texture.Height / 2);
            Raylib.DrawTextureV(_texture, Owner.Transform.GlobalPosition - offset, Color.White);
        }

        public override void End()
        {
            base.End();
            Raylib.UnloadTexture(_texture);
        }

    }
}
