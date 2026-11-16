// LeetCode 1209: Remove All Adjacent Duplicates in String II

function removeDuplicates(s: string, k: number): string {
    const stack = [];
    const charCount = new Map<string, number>();

    for (let i = 0; i < s.length; i++) {
        const chr = s[i];
        stack.push(chr);

        const count = (charCount.get(chr) ?? 0) + 1;
        charCount.set(chr, count);

        if (count < k) continue;

        // is adjacent
        let notAdj = false;
        for (let j = stack.length - 1; j > 0 && j > (stack.length - 1) - k; j--) {
            if (chr !== stack[j]) {
                notAdj = true;
                break;
            }
        }

        if (notAdj) continue;
        for (let j = 0; j < k; j++) {
            stack.pop();
        }

        charCount.set(chr, count-k);
    }

    return stack.join("");
};
