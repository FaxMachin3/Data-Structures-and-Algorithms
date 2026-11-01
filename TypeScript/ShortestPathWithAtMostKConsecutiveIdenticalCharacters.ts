// LeetCode 3970: Shortest Path With At Most K Consecutive Identical Characters
// https://leetcode.com/problems/shortest-path-with-at-most-k-consecutive-identical-characters/
// Dijkstra states: [distance, node, current identical-character run length].
// A settled state dominates later states at that node with an equal or larger
// run length: its distance is no greater and it permits every continuation.
// done[u] stores the smallest settled run length; k + 1 also rejects runs > k.
// With E edges: O(n + E + k * E * log(2 + k * E)) time,
// O(n + E + k * E) space, including the heap.
function shortestPath(n: number, edges: number[][], labels: string, k: number): number {
    type Edge = [number, number, boolean];
    type State = [number, number, number];

    const graph: Edge[][] = Array.from({ length: n }, () => []);

    for (const [u, v, w] of edges) {
        graph[u].push([v, w, labels[u] === labels[v]]);
    }

    const done: number[] = Array(n).fill(k + 1);
    const heap: State[] = [];

    function less(a: State, b: State): boolean {
        if (a[0] !== b[0]) return a[0] < b[0];
        if (a[1] !== b[1]) return a[1] < b[1];
        return a[2] < b[2];
    }

    function push(value: State): void {
        let i = heap.length;
        heap.push(value);

        while (i > 0) {
            const p = Math.floor((i - 1) / 2);
            if (!less(value, heap[p])) break;

            heap[i] = heap[p];
            i = p;
        }

        heap[i] = value;
    }

    function pop(): State {
        const result = heap[0];
        const last = heap.pop()!;

        if (heap.length === 0) return result;

        let i = 0;

        while (2 * i + 1 < heap.length) {
            let child = 2 * i + 1;

            if (
                child + 1 < heap.length &&
                less(heap[child + 1], heap[child])
            ) {
                child++;
            }

            if (!less(heap[child], last)) break;

            heap[i] = heap[child];
            i = child;
        }

        heap[i] = last;
        return result;
    }

    push([0, 0, 1]);

    while (heap.length > 0) {
        const [d, u, r] = pop();

        if (r >= done[u]) continue;
        done[u] = r;

        if (u === n - 1) return d;

        for (const [v, w, same] of graph[u]) {
            const nr = same ? r + 1 : 1;

            if (nr < done[v]) {
                push([d + w, v, nr]);
            }
        }
    }

    return -1;
}
