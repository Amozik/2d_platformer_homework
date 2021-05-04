using Platformer.Interfaces;
using UnityEngine;

namespace Platformer.Physics
{
    public class ContactsPoller : IFixedUpdate
    {
        private const float COLLISION_THRESH = 0.6f;

        private ContactPoint2D[] _contacts = new ContactPoint2D[10];
        private int _contactsCount;
        private readonly Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContacts { get; private set; }
        public bool HasRightContacts { get; private set; }

        public ContactsPoller(Collider2D  collider2D)
        {
            _collider2D = collider2D;
        }

        public void FixedUpdate(float deltaTime)
        {
            IsGrounded = false;
            HasLeftContacts = false;
            HasRightContacts = false;
            
            _contactsCount = _collider2D.GetContacts(_contacts);
            
            for (int i = 0; i < _contactsCount; i++)
            {
                var normal = _contacts[i].normal;
                var rigidBody = _contacts[i].rigidbody;

                if (normal.y > COLLISION_THRESH) IsGrounded = true;
                if (normal.x > COLLISION_THRESH && rigidBody == null) 
                    HasLeftContacts = true;
                if (normal.x < -COLLISION_THRESH && rigidBody == null) 
                    HasRightContacts = true;
            }
        }

    }
}