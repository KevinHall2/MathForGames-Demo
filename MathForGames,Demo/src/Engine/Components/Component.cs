﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames_Demo
{
    internal class Component
    {
        private Actor _owner;
        private bool _enabled;
        private bool _started;
        public Actor Owner { get => _owner; }
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

        public bool Started { get => _started; }

        public Component(Actor owner)
        {
            _owner = owner;
            _enabled = true;
            _started = false;
        }

        public virtual void Start() { _started = true; }

        public virtual void Update() { }
       
        public virtual void End() { }

        public virtual void OnEnable() { }

        public virtual void OnDisable() { }

    }
}
