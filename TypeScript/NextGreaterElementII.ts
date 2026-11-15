// LeetCode 503: Next Greater Element II
// Time: O(n). Extra space: O(n).

function nextGreaterElements(nums: number[]): number[] {
    const n = nums.length;
    const nge = new Array<number>(n);
    const posStack = new Array<number>();
    posStack.push(0);

    let i = 1;
    while(i < 2*n) {
        const modI = i%n;
        if(nums[posStack.at(-1)] < nums[modI]) {
            const pos = posStack.pop();
            nge[pos] = nums[modI];
        } else {
            if (i < n) posStack.push(modI);
            i++;
        }
    }

    while(posStack.length > 0) {
        const pos = posStack.pop();
        nge[pos] = -1;
    }

    return nge;
};
