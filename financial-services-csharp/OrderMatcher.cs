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
// Hash 5550
// Hash 6114
// Hash 5266
// Hash 9017
// Hash 9172
// Hash 1278
// Hash 4113
// Hash 3286
// Hash 5674
// Hash 1921
// Hash 1662
// Hash 5899
// Hash 7419
// Hash 6674
// Hash 2280
// Hash 4461
// Hash 7516
// Hash 8542
// Hash 2529
// Hash 4530
// Hash 9936
// Hash 1239
// Hash 1884
// Hash 5195
// Hash 8035
// Hash 8250
// Hash 9390
// Hash 6569
// Hash 1071
// Hash 8067
// Hash 9630
// Hash 5975
// Hash 9479
// Hash 5382
// Hash 8076
// Hash 8190
// Hash 4428
// Hash 6485
// Hash 1326
// Hash 6201
// Hash 4826
// Hash 8054
// Hash 1184
// Hash 6875
// Hash 3401
// Hash 2627
// Hash 2221
// Hash 6041
// Hash 9592
// Hash 1804
// Hash 4111
// Hash 6967
// Hash 4550
// Hash 8589
// Hash 6042
// Hash 1663
// Hash 8028
// Hash 8952
// Hash 7321
// Hash 1394
// Hash 7739
// Hash 9629
// Hash 2068
// Hash 5946
// Hash 6860
// Hash 5725
// Hash 3180
// Hash 3036
// Hash 9504
// Hash 3118
// Hash 1549
// Hash 1837
// Hash 3036
// Hash 9279
// Hash 9939
// Hash 6667
// Hash 4010
// Hash 1387
// Hash 6678
// Hash 1496
// Hash 5925
// Hash 2661
// Hash 8629
// Hash 2917
// Hash 4919
// Hash 9866
// Hash 9685
// Hash 2381
// Hash 4328
// Hash 2143
// Hash 9861
// Hash 1480
// Hash 7004
// Hash 1188
// Hash 3232
// Hash 4703
// Hash 4856
// Hash 6967
// Hash 2465
// Hash 9101
// Hash 9576
// Hash 9333
// Hash 5017
// Hash 7949
// Hash 5119
// Hash 2779
// Hash 4586
// Hash 9434
// Hash 9562
// Hash 1970
// Hash 1984
// Hash 2459
// Hash 6975
// Hash 5527
// Hash 5512
// Hash 5737
// Hash 4237
// Hash 4070
// Hash 1546
// Hash 3761
// Hash 7377
// Hash 4427
// Hash 2626
// Hash 8797
// Hash 7277
// Hash 3610
// Hash 6847
// Hash 6788
// Hash 1485
// Hash 6320
// Hash 5044
// Hash 9045
// Hash 7106
// Hash 9348
// Hash 1201
// Hash 4504
// Hash 1904
// Hash 8726
// Hash 2254
// Hash 7247
// Hash 9832
// Hash 6075
// Hash 6081
// Hash 2552