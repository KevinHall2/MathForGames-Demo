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
        private Component[] _componentsToRemove;

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
            _componentsToRemove = new Component[0];
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

            //removes components that should be removed
            RemoveComponentsToBeRemoved();
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

        public T AddComponent<T>() where T : Component, new()
        {
            //makes a new component that is owned by this actor that is then cast to the type given with T
            T component = new T();
            component.Owner = this;
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

            if (_components.Length == 1 && _components[0] == component)
            {
                //adds a component to _componentsToRemove
                AddComponentToRemove(component);
                return true;
            }

            //loops through _component
            foreach (Component comp in _components)
            {
                if (comp == component)
                {
                    //adds a component to _componentsToRemove
                    AddComponentToRemove(comp);

                    return true;
                }
            }

            return false;
            ////edge case for only having one component
            //if (_components.Length == 1 && _components[0] == component)
            //{
            //    _components = new Component[0];
            //    return true;
            //}
            ////creates a temp array that is one slot smaller than the original _components
            //Component[] temp = new Component[_components.Length - 1];
            //bool componentRemoved = false;
            ////deep copies _component into the temp variable minus the one component
            //int j = 0;
            //for (int i = 0; j < _components.Length -1; i++)
            //{
            //    if (_components[i] != component)
            //    {
            //        temp[j] = _components[i];
            //        j++;
            //    }
            //    else
            //    {
            //        componentRemoved = true;
            //    }
            //}
            ////if a component was removed, assign the temp variable to _components
            //if (componentRemoved)
            //{
            //    _components = temp;
            //}
            //return componentRemoved;
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

        private void AddComponentToRemove(Component comp)
        {
            //ensure the component is not already being removed
            foreach (Component component in _componentsToRemove)
            {
                if (component == comp)
                {
                    return;
                }
            }
            //creates a temporary array that is one slot larger than the original
            Component[] temp = new Component[_componentsToRemove.Length + 1];
            //deep copies _componentsToRemove into the temp variable
            for (int i = 0; i < _componentsToRemove.Length; i++)
            {
                temp[i] = _componentsToRemove[i];
            }

            //set the last index in temp to the component we wish to add
            temp[temp.Length - 1] = comp;

            //store temp in _componentsToRemove
            _componentsToRemove = temp;
        }

        private void RemoveComponentsToBeRemoved()
        {
            //temporary array for _components
            Component[] tempComponents = new Component[_components.Length];

            //deep copies the array, removing the elements in _componentsToRemove

            int j = 0;
            for(int i = 0; i < _components.Length; i++)
            {
                //loops through components to remove and check if any of them are equal to this one
                bool removed = false;
                foreach (Component component in _componentsToRemove)
                {
                    if (_components[i] == component)
                    {
                        removed = true;
                        break;
                    }
                }
                //if a component to remove wasn't found, copy the item and incrememnt the temp array
                if (!removed)
                {
                    tempComponents[j] = _components[i];
                    j++;
                }
            }

            //trims the array
            Component[] result = new Component[_components.Length - _componentsToRemove.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = tempComponents[i];
            }

            //sets _components
            _components = result;
        }
    }
}
