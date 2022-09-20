using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Lib
{
    public struct SingleLayer
    {
        private readonly int _singleLayer;
        public SingleLayer(LayerMask layerMask)
        {
            _singleLayer = 0;
            int layerInt = layerMask;
            while((layerInt & 1) == 0)
            {
                _singleLayer++;
                layerInt >>= 1;
            }
        }

        public int value => _singleLayer;

        public static implicit operator int(SingleLayer layer)
        {
            return layer.value;
        }
    }
}
