// LeetCode 1882: Process Tasks Using Servers
// Uses MinPriorityQueue from @datastructures-js/priority-queue (provided by LeetCode).
// Time: O((n + m) log(n + 1)). Extra space: O(n), excluding output.
function assignTasks(servers: number[], tasks: number[]): number[] {
    type ServerDetails = [weight: number, server: number, freeAt: number];
    const availableServers = new MinPriorityQueue<ServerDetails>({
        compare: (a, b) => a[0] - b[0] || a[1] - b[1],
    });
    const unavailableServers = new MinPriorityQueue<ServerDetails>(
        server => server[2]
    );
    const results = new Array<number>(tasks.length);

    for (let i = 0; i < servers.length; i++) {
        availableServers.enqueue([servers[i], i, 0]);
    }

    function makeServersAvailable(time: number): void {
        while (!unavailableServers.isEmpty() && time >= unavailableServers.front()![2]) {
            availableServers.enqueue(unavailableServers.dequeue()!);
        }
    }

    let currentTime = 0;
    for (let i = 0; i < tasks.length; i++) {
        currentTime = Math.max(currentTime, i);
        makeServersAvailable(currentTime);

        if (availableServers.isEmpty()) {
            currentTime = unavailableServers.front()![2];
            makeServersAvailable(currentTime);
        }

        const [weight, server] = availableServers.dequeue()!;
        results[i] = server;
        unavailableServers.enqueue([weight, server, currentTime + tasks[i]]);
    }

    return results;
}
