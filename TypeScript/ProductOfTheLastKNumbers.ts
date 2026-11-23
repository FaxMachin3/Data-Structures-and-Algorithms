// LeetCode 1352: Product of the Last K Numbers
// add: O(1) amortized. getProduct: O(1). Extra space: O(n) worst case.

class ProductOfNumbers {
    private prodOfS: Array<number>;
    constructor() {
        this.prodOfS = [1];
    }

    add(num: number): void {
        if(num === 0) {
            this.prodOfS = [1];
            return;
        }
        const lastProduct = this.prodOfS[this.prodOfS.length - 1];
        this.prodOfS.push(lastProduct*num);
    }

    getProduct(k: number): number {
        const n = this.prodOfS.length - 1;
        if(k>n) return 0;
        return this.prodOfS[n] / (this.prodOfS[n-k] || 1);
    }
}

// [3,0,2,5,4]

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * var obj = new ProductOfNumbers()
 * obj.add(num)
 * var param_2 = obj.getProduct(k)
 */
