using System;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Infrastructure
{
    internal class ViewEnlisterOrderItem4Proxy<VW, TKey>
    {
        public bool Descending { set; get; }                                                                                                                                                                                                                                                                            
        public Expression< Func<VW,TKey> > OrderPredicate { set; get; }
    }
}
