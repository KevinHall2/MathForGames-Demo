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
            Vector2 newScale = new Vector2(25, 25);
            Actor playerActor = Actor.Instantiate(new PlayerActor(), null, "Player", new Vector2(200, 200), 3.14f/4);
            playerActor.Transform.Scale(newScale);
            playerActor.Collider = new CircleCollider(playerActor, 100);

            Actor childActor = Actor.Instantiate(new ChildActor(), playerActor.Transform, "Child", new Vector2(15, 15), 3.14f/4);
           

            Component rotationComponent = new RotationComponent(playerActor);
            playerActor.AddComponent(rotationComponent);

            Component scalingComponent = new ScalingComponent(playerActor);
            playerActor.AddComponent(scalingComponent);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}
