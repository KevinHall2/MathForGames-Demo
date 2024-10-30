using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames_Demo
{
    internal class Actor
    {
        private bool _started = false;

        public bool Started { get => _started; }

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
    }
}
