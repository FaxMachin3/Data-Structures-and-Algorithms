// LeetCode 901: Online Stock Span
// Time: O(1) amortized per call. Space: O(n).

class StockSpanner {
    private stack: Array<[price: number, pushedAt: number]>;
    private pushedAt: number;

    constructor() {
        this.stack = new Array<[price: number,pushedAt: number]>();
        this.pushedAt = 0;
    }

    next(price: number): number {
        while(this.stack[this.stack.length-1]?.[0] <= price) {
            this.stack.pop();
        }
        const days = this.pushedAt - (this.stack[this.stack.length - 1]?.[1] ?? 0)
        this.stack.push([price, ++this.pushedAt]);
        return days+1;
    }
}
