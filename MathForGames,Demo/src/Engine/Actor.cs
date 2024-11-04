using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames_Demo
{
    internal class Actor
    {

        private bool _started = false;
        private bool _enabled = true;

        private Component[] _components; 

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
            _components = new Component[0];
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

        public static void Destroy(Actor actor)
        {
            //removes all children
            foreach (Transform2D child in actor.Transform.Children)
            {
                actor.Transform.RemoveChild(child);
            }

            //unchild from parent
            if (actor.Transform.Parent != null)
            {
                actor.Transform.Parent.RemoveChild(actor.Transform);
            }

            Game.CurrentScene.RemoveActor(actor);
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
            foreach (Component component in _components)
            {
                if (!component.Started)
                {
                    component.Start();
                }
                component.Update(deltaTime);
            }
        }

        public virtual void End()
        {
            foreach (Component component in _components)
            {
                component.End();
            }
        }

        public virtual void OnCollision(Actor other)
        {

        }

        //add a component
        public T AddComponent<T>(T component) where T : Component
        {
            //creates a temporary array that is one slot larger than the original
            Component[] temp = new Component[_components.Length + 1];
            //deep copies _components into the temp variable
            for (int i = 0; i < _components.Length; i++)
            {
                temp[i] = _components[i];
            }

            //set the last index in temp to the component we wish to add
            temp[temp.Length - 1] = component;

            //store temp in _components
            _components = temp;

            return component;
        }

        public T AddComponent<T>() where T : Component
        {
            //makes a new component that is owned by this actor that is then cast to the type given with T
            T component = (T)new Component(this);
            return AddComponent(component);
        }

        //remove a component
        public bool RemoveComponent<T>(T component) where T : Component
        {
            //edge case for an empty component array
            if (_components.Length <= 0)
            {
                return false;
            }
            //edge case for only having one component
            if (_components.Length == 1 && _components[0] == component)
            {
                _components = new Component[0];
                return true;
            }
            //creates a temp array that is one slot smaller than the original _components
            Component[] temp = new Component[_components.Length - 1];
            bool componentRemoved = false;
            //deep copies _component into the temp variable minus the one component
            int j = 0;
            for (int i = 0; j < _components.Length -1; i++)
            {
                if (_components[i] != component)
                {
                    temp[j] = _components[i];
                    j++;
                }
                else
                {
                    componentRemoved = true;
                }
            }
            //if a component was removed, assign the temp variable to _components
            if (componentRemoved)
            {
                _components = temp;
            }
            return componentRemoved;
        }

        public bool RemoveComponent<T>() where T : Component
        {
            T component = GetComponent<T>();
            if (component != null)
            {
                return RemoveComponent(component);
            }
            return false;
        }

        //get one component
        public T GetComponent<T>() where T : Component
        {
            foreach(Component component in _components)
            {
                if (component is T)
                {
                    return (T)component;
                }
            }
            return null;
        }

        //get multiple components
        public T[] GetComponents<T>() where T : Component
        {
            //creates a temp array that is the same size as _components
            T[] temp = new T[_components.Length];

            //copies all elements that are of type T into temp
            int count = 0;
            for (int i = 0; i < _components.Length; i++)
            {
                if (_components[i] is T)
                {
                    temp[count] = (T)_components[i];
                    count++;
                }
            }
            // trims the array
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }

            return result;
        }
    }
}
