// LeetCode 1209: Remove All Adjacent Duplicates in String II

function removeDuplicates(s: string, k: number): string {
    const stack: [string, number][] = [];

    for (let i = 0; i < s.length; i++) {
        const chr = s[i];
        const top = stack[stack.length - 1];

        if(top && top[0] === chr) {
            top[1]++;
        } else {
            stack.push([chr, 1]);
        }

        if(stack[stack.length - 1][1] === k) {
            stack.pop();
        }
    }

    return stack.map(([chr, count]) => chr.repeat(count)).join("");
};
