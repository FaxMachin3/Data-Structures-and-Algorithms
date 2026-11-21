// LeetCode 3331: Find Subtree Sizes After Changes
// Time: O(n). Extra space: O(n).

function findSubtreeSizes(parent: number[], s: string): number[] {
    const chrCodeOfA = 'a'.charCodeAt(0);
    const adjList = new Map<number, number[]>();
    const n = parent.length;
    const children = new Array<number>(n).fill(1);
    const last = new Array<number>(26).fill(-1);

    for (let v = 1; v < n; v++) {
        const u = parent[v];
        const childNodes = adjList.get(u);
        if (childNodes === undefined) {
            adjList.set(u, [v]);
        } else {
            childNodes.push(v);
        }
    }

    function dfs(currNode: number): void {
        const indexOfChr = s.charCodeAt(currNode) - chrCodeOfA;
        const nearestAncestor = last[indexOfChr];
        last[indexOfChr] = currNode;

        const childNodes = adjList.get(currNode) ?? [];
        for (const childNode of childNodes) {
            dfs(childNode);
        }

        last[indexOfChr] = nearestAncestor;

        if (currNode !== 0) {
            const finalParent =
                nearestAncestor === -1 ? parent[currNode] : nearestAncestor;
            children[finalParent] += children[currNode];
        }
    }

    dfs(0);
    return children;
};
