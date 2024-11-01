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

            Actor actor = new TestActor();
            actor.Transform.LocalPosition = new Vector2(200, 200);
            AddActor(actor);
            actor.Collider = new CircleCollider(actor, 100);

            _theLad = Actor.Instantiate(new Actor("Lad"), null, new Vector2(100, 100), 0);
            _theLad.Collider = new CircleCollider(_theLad, 50);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}
