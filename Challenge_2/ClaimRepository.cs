using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepository
    {
        public Queue<Claim> _queueOfClaims = new Queue<Claim>();

        public void AddItemToClaim(Claim item)
        {
            _queueOfClaims.Enqueue(item);
        }

        public Queue<Claim> GetClaimsQueue()
        {
            return _queueOfClaims;
        }
    }
}
