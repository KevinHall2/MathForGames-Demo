using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames_Demo
{
    internal class TestScene : Scene
    {
        public override void Start()
        {
            base.Start();
            Actor playerActor = Actor.Instantiate(new PlayerActor(), null, "Player", new Vector2(200, 200), 3.14f/4);
            playerActor.Collider = new CircleCollider(playerActor, 100);

            Component rotationComponent = new RotationComponent(playerActor);
            playerActor.AddComponent(rotationComponent);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}
