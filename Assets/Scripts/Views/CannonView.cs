using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Views
{
    public class CannonView : MonoBehaviour
    {
        public Transform MuzzleTransform;
        public Transform EmmiterTransform;
        public List<BulletView> BulletViews;
    }
}