function minimumChanges(s: string, k: number): number {
    const n = s.length;

    const mismatchPrefix = Array.from(
        { length: n },
        () => new Int32Array(n + 1)
    );

    for (let gap = 1; gap < n; gap++) {
        const prefix = mismatchPrefix[gap];

        for (let i = 0; i + gap < n; i++) {
            prefix[i + 1] = prefix[i] + (s[i] === s[i + gap] ? 0 : 1);
        }
    }

    const cost = Array.from(
        { length: n },
        () => new Int32Array(n + 1).fill(n)
    );

    for (let d = 1; 2 * d <= n; d++) {
        const evenCosts = new Int32Array(n + 1);
        const oddCosts = new Int32Array(n + 1);

        for (let blocks = 2; blocks * d <= n; blocks++) {
            const length = blocks * d;
            const prefix = mismatchPrefix[length - d];
            const costsForDivisor = blocks % 2 === 0 ? evenCosts : oddCosts;

            for (let start = 0; start + length <= n; start++) {
                const end = start + length;
                const outerCost = prefix[start + d] - prefix[start];

                const innerCost = costsForDivisor[start + d];
                const changes = outerCost + innerCost;

                costsForDivisor[start] = changes;
                cost[start][end] = Math.min(cost[start][end], changes);
            }
        }
    }

    let previous = new Int32Array(n + 1).fill(n);
    previous[0] = 0;

    for (let parts = 1; parts <= k; parts++) {
        const current = new Int32Array(n + 1).fill(n);
        const lastEnd = n - 2 * (k - parts);

        for (let end = 2 * parts; end <= lastEnd; end++) {
            for (let start = 2 * (parts - 1); start <= end - 2; start++) {
                current[end] = Math.min(
                    current[end],
                    previous[start] + cost[start][end]
                );
            }
        }

        previous = current;
    }

    return previous[n];
}
