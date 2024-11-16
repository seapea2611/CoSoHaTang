using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using Asd.Hrm.Queries.Container;
using System;

namespace Asd.Hrm.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}