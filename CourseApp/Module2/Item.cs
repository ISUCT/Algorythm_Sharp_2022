using System;

namespace CourseApp.Module2
{
    public class Item : IEquatable<Item>
    {
        public int Number { get; set; }

        public bool Equals(Item other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            int hashProductName = Number.GetHashCode();
            return hashProductName;
        }
    }
}