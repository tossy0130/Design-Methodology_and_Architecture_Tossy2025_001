#define MAX_ITEMS 10

/*
■Aggregate（集約）

一貫性の境界を定めるルートオブジェクト（Aggregate Root）と、それに属するエンティティや値オブジェクトの集合。


*/

typedef struct {
    int item_id;
    int quantity;
} OrderItem;

typedef struct {
    int order_id;
    OrderItem items[MAX_ITEMS];
    int item_count;
} Order;

void AddOrderItem(Order* order, OrderItem item) {
    if(order->item_count < MAX_ITEMS) {
        order->items[order->item_count++] = item;
    }
}