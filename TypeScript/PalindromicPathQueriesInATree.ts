// LeetCode 3841: Palindromic Path Queries in a Tree
// https://leetcode.com/problems/palindromic-path-queries-in-a-tree/
// Character parity masks + Euler tour + XOR Fenwick tree + binary-lifting LCA.
// Time: O((n + queries.length) * log n). Extra space: O(n * log n), excluding output.
function palindromePath(
    n: number,
    edges: number[][],
    s: string,
    queries: string[]
): boolean[] {
    const graph: number[][] = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        graph[u].push(v);
        graph[v].push(u);
    }

    const masks = Int32Array.from(s, c => 1 << (c.charCodeAt(0) - 97));
    const parent = new Int32Array(n);
    const depth = new Int32Array(n);
    const tin = new Int32Array(n);
    const size = new Int32Array(n).fill(1);
    const prefix = new Int32Array(n);
    const order: number[] = [];

    // Iterative DFS avoids stack overflow on a long chain.
    const stack = [0];
    prefix[0] = masks[0];

    while (stack.length > 0) {
        const u = stack.pop()!;
        tin[u] = order.length;
        order.push(u);

        for (const v of graph[u]) {
            if (v === parent[u]) continue;
            parent[v] = u;
            depth[v] = depth[u] + 1;
            prefix[v] = prefix[u] ^ masks[v];
            stack.push(v);
        }
    }

    for (let i = n - 1; i > 0; i--) {
        const u = order[i];
        size[parent[u]] += size[u];
    }

    const levels = Math.floor(Math.log2(n)) + 1;
    const up: Int32Array[] = [parent];

    for (let k = 1; k < levels; k++) {
        up[k] = new Int32Array(n);
        for (let u = 0; u < n; u++) {
            up[k][u] = up[k - 1][up[k - 1][u]];
        }
    }

    function lca(u: number, v: number): number {
        if (depth[u] < depth[v]) [u, v] = [v, u];

        const diff = depth[u] - depth[v];
        for (let k = 0; k < levels; k++) {
            if (diff & (1 << k)) u = up[k][u];
        }

        if (u === v) return u;

        for (let k = levels - 1; k >= 0; k--) {
            if (up[k][u] !== up[k][v]) {
                u = up[k][u];
                v = up[k][v];
            }
        }

        return parent[u];
    }

    // XOR difference Fenwick tree: subtree updates, point queries.
    const bit = new Int32Array(n + 1);

    function add(index: number, delta: number): void {
        for (; index <= n; index += index & -index) {
            bit[index] ^= delta;
        }
    }

    function rootMask(u: number): number {
        let result = prefix[u];
        for (let index = tin[u] + 1; index > 0; index -= index & -index) {
            result ^= bit[index];
        }
        return result;
    }

    const answer: boolean[] = [];

    for (const query of queries) {
        const [type, first, second] = query.split(" ");
        const u = Number(first);

        if (type === "update") {
            const nextMask = 1 << (second.charCodeAt(0) - 97);
            const delta = masks[u] ^ nextMask;
            masks[u] = nextMask;

            // Subtree interval: [tin[u], tin[u] + size[u] - 1].
            add(tin[u] + 1, delta);
            add(tin[u] + size[u] + 1, delta);
        } else {
            const v = Number(second);
            const ancestor = lca(u, v);
            const mask = rootMask(u) ^ rootMask(v) ^ masks[ancestor];

            answer.push((mask & (mask - 1)) === 0);
        }
    }

    return answer;
}
