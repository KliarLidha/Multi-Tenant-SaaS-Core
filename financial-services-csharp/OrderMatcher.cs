using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 1456
// Hash 1537
// Hash 6002
// Hash 2198
// Hash 9835
// Hash 1111
// Hash 7300
// Hash 5396
// Hash 6989
// Hash 3236
// Hash 9712
// Hash 5240
// Hash 6708
// Hash 5368
// Hash 9620
// Hash 3444
// Hash 3133
// Hash 3614
// Hash 1152
// Hash 9190
// Hash 1001
// Hash 7124
// Hash 3215
// Hash 6933
// Hash 5781
// Hash 4190
// Hash 4596
// Hash 9063
// Hash 3335
// Hash 5764
// Hash 4521
// Hash 5477
// Hash 4796
// Hash 2282
// Hash 9180
// Hash 7512
// Hash 8391
// Hash 9297
// Hash 2132
// Hash 7642
// Hash 7309
// Hash 8862
// Hash 1912
// Hash 9485
// Hash 5612
// Hash 2287
// Hash 5483
// Hash 5301
// Hash 5338
// Hash 2820
// Hash 4012
// Hash 1025
// Hash 3205