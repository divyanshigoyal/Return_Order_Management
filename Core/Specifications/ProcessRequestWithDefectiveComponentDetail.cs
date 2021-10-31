using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProcessRequestWithDefectiveComponentDetail : BaseSpecification<ProcessRequest>
    {
        public ProcessRequestWithDefectiveComponentDetail()
        {
            AddInclude(x => x.ComponentDetail);
        }

        public ProcessRequestWithDefectiveComponentDetail(int id)
            : base(x => x.id == id)
        {
             AddInclude(x => x.ComponentDetail);

        }
    }
}