// LeetCode 739: Daily Temperatures
// Time: O(n). Extra space: O(n), excluding the result array.

function dailyTemperatures(temperatures: number[]): Int32Array {
    const n = temperatures.length;
    const stack = new Array<number>();
    const result = new Int32Array(n);

    for(let i = 0; i < n; i++) {
        let top = stack[stack.length - 1];

        while(top !== undefined && temperatures[i] > temperatures[top]) {
            const pushedAt = stack.pop();
            result[pushedAt] = i - pushedAt;
            top = stack[stack.length - 1];
        }
        stack.push(i);
    }


    return result;
};
