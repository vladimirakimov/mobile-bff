using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Reflection;

namespace ITG.Brix.Mobile.Bff.Application.JsonContractResolvers
{
    public class IgnoreEmptyEnumerablesResolver : CamelCasePropertyNamesContractResolver
    {
        public new static readonly IgnoreEmptyEnumerablesResolver Instance = new IgnoreEmptyEnumerablesResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType != typeof(string) &&
                typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                property.ShouldSerialize = instance =>
                {
                    IEnumerable enumerable = null;

                    switch (member.MemberType)
                    {
                        case MemberTypes.Property:
                            enumerable = instance
                                .GetType()
                                .GetProperty(member.Name)
                                .GetValue(instance, null) as IEnumerable;
                            break;
                        case MemberTypes.Field:
                            enumerable = instance
                                .GetType()
                                .GetField(member.Name)
                                .GetValue(instance) as IEnumerable;
                            break;
                        default:
                            break;

                    }

                    if (enumerable != null)
                    {
                        return enumerable.GetEnumerator().MoveNext();
                    }
                    else
                    {
                        return true;
                    }

                };
            }

            return property;
        }
    }
}
