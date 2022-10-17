using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace WebApi.Common.Repositories
{
    public class AutomappingConfig : DefaultAutomappingConfiguration
    {
        public override bool IsComponent(Type type)
        {
            return false;
        }

        public override string GetComponentColumnPrefix(Member member)
        {
            return "";
        }

        public override bool ShouldMap(Member member)
        {
            if (member.IsProperty && !member.CanWrite)
            {
                return false;
            }
            return base.ShouldMap(member);
        }

        public override bool ShouldMap(Type type)
        {
            return type.IsClass && !type.IsAbstract && type.Namespace != null && type.Namespace.EndsWith("Models");
        }
    }
}