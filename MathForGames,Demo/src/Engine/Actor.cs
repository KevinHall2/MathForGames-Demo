using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames_Demo
{
    internal class Actor
    {

        private bool _started = false;
        private bool _enabled = true;

        public bool Started { get => _started; }

        public string Name { get; set; }

        public bool Enabled
        {
            get => _enabled;
            set
            {
                //if enabled would not change, do nothing
                if (_enabled == value) return;

                _enabled = value;
                //if value is true, call OnEnabled
                if (_enabled)
                    OnEnable();
                //if value is false, call OnDisabled
                else
                    OnDisable();
            }
        }


        public Collider Collider { get; set; }

        public Transform2D Transform { get; protected set; }


        public Actor(string name = "Actor")
        {
            Name = name;
           Transform = new Transform2D(this);
        }
        
        public static Actor Instantiate(Actor actor, Transform2D parent = null, string name = "Actor", Vector2 position = new Vector2(), float rotation = 0)
        {
            //sets an actor's transform values
            actor.Transform.LocalPosition = position;
            actor.Transform.Rotate(rotation);
            actor.Name = name;
            if (parent != null)
                parent.AddChild(actor.Transform);
            //adds that actor to the current scene
            Game.CurrentScene.AddActor(actor);

            return actor;
        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }
        
        public virtual void Start()
        {
            _started = true;
            
        }

        public virtual void Update(double deltaTime)
        {

        }

        public virtual void End()
        {

        }

        public virtual void OnCollision(Actor other)
        {

        }
    }
}
