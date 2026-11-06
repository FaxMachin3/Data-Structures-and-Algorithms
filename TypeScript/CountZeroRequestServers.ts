// LeetCode 2747: Count Zero Request Servers
// https://leetcode.com/problems/count-zero-request-servers/
// Sort logs and indexed queries, then maintain per-server window frequencies.
// Time: O(L log L + Q log Q + L + Q), assuming average O(1) Map operations.
// Extra space: O(Q + min(n, L)), excluding sorting workspace.
// Sorts logs in place.
function countServers(n: number, logs: number[][], x: number, queries: number[]): number[] {
    const result = new Array<number>(queries.length);
    logs.sort((logA, logB) => logA[1] - logB[1]);
    const sortedQueries = queries.map((q, i) => [q, i])
                                 .sort((a, b) => a[0] - b[0]);
    const serverCounts = new Map<number, number>();
    let pLeft = 0;
    let pRight = 0;

    function calculateServersInRange(left: number, right: number): number {
        while (pLeft < logs.length && logs[pLeft][1] < left) {
            const server = logs[pLeft][0];
            if (serverCounts.get(server)) {
                if (serverCounts.get(server) === 1) {
                    serverCounts.delete(server);
                } else {
                    serverCounts.set(server, serverCounts.get(server)! - 1);
                }
            }
            pLeft++;
        }
        while (pRight < logs.length && logs[pRight][1] <= right) {
            if (pRight >= pLeft) {
                const server = logs[pRight][0];
                if (!serverCounts.get(server)) {
                    serverCounts.set(server, 0);
                }
                serverCounts.set(server, serverCounts.get(server)! + 1);
            }
            pRight++;
        }
        return serverCounts.size;
    }

    for (let i = 0; i < sortedQueries.length; i++) {
        const queryIndex = sortedQueries[i][1];
        const right = sortedQueries[i][0];
        const left = right - x;
        const serverCountsInRange = calculateServersInRange(left, right);
        result[queryIndex] = n - serverCountsInRange;
    }

    return result;
}
