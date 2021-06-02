using UnityEngine;

namespace Platformer.AI
{
    public interface IProtector
    {
        void StartProtection(GameObject invader);
        void FinishProtection(GameObject invader);
    }

}
