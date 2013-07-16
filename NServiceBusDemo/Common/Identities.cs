using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public sealed class CustomerId : AbstractIdentity<long>
    {
        public const string TagValue = "customer";

        public CustomerId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; protected set; }

        public CustomerId() { }
    }

    public sealed class MaterialId : AbstractIdentity<long>
    {
        public const string TagValue = "material";

        public MaterialId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; protected set; }

        public MaterialId() { }
    }

    public sealed class ResourceId : AbstractIdentity<long>
    {
        public const string TagValue = "resource";

        public ResourceId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; protected set; }

        public ResourceId() { }
    }

    public sealed class RouteId : AbstractIdentity<long>
    {
        public const string TagValue = "route";

        public RouteId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; protected set; }

        public RouteId() { }
    }

    public sealed class RouteStepId : AbstractIdentity<long>
    {
        public const string TagValue = "routestep";

        public RouteStepId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; protected set; }

        public RouteStepId() { }
    }
      
    public sealed class WipId : AbstractIdentity<long>
    {
        public const string TagValue = "wip";

        public WipId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; protected set; }

        public WipId() { }
    }

    /// <summary>
    /// Strongly-typed identity class. Essentially just an ID with a 
    /// distinct type. It introduces strong-typing and speeds up development
    /// on larger projects. 
    /// </summary>
    public interface IIdentity
    {
        /// <summary>
        /// Gets the id, converted to a string. Only alphanumerics and '-' are allowed.
        /// </summary>
        /// <returns></returns>
        string GetId();

        /// <summary>
        /// Unique tag (should be unique within the assembly) to distinguish
        /// between different identities, while deserializing.
        /// </summary>
        string GetTag();

        int GetStableHashCode();
    }

    /// <summary>
    /// Base implementation of <see cref="IIdentity"/>, which implements
    /// equality and ToString once and for all.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public abstract class AbstractIdentity<TKey> : IIdentity
    {
        public abstract TKey Id { get; protected set; }

        public string GetId()
        {
            return Id.ToString();
        }

        public bool IsEmpty()
        {
            return Id.Equals(default(TKey));
        }

        public abstract string GetTag();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var identity = obj as AbstractIdentity<TKey>;

            if (identity != null)
            {
                return Equals(identity);
            }

            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", GetType().Name.Replace("Id", ""), Id);
        }

        public override int GetHashCode()
        {
            return (Id.GetHashCode());
        }

        public int GetStableHashCode()
        {
            // same as hash code, but works across multiple architectures 
            var type = typeof(TKey);
            if (type == typeof(string))
            {
                return CalculateStringHash(Id.ToString());
            }
            return Id.GetHashCode();
        }

        static AbstractIdentity()
        {
            var type = typeof(TKey);
            if (type == typeof(int) || type == typeof(long) || type == typeof(uint) || type == typeof(ulong))
                return;
            if (type == typeof(Guid) || type == typeof(string))
                return;
            throw new InvalidOperationException("Abstract identity inheritors must provide stable hash. It is not supported for:  " + type);
        }

        static int CalculateStringHash(string value)
        {
            if (value == null) return 42;
            unchecked
            {
                var hash = 23;
                foreach (var c in value)
                {
                    hash = hash * 31 + c;
                }
                return hash;
            }
        }

        public bool Equals(AbstractIdentity<TKey> other)
        {
            if (other != null)
            {
                return other.Id.Equals(Id) && other.GetTag() == GetTag();
            }

            return false;
        }

        public static bool operator ==(AbstractIdentity<TKey> left, AbstractIdentity<TKey> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AbstractIdentity<TKey> left, AbstractIdentity<TKey> right)
        {
            return !Equals(left, right);
        } 
    }
}
