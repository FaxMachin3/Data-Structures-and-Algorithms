// LeetCode 1606: Find Servers That Handled Most Number of Requests
import { AvlTree } from "@datastructures-js/binary-search-tree";
import { MinPriorityQueue } from "@datastructures-js/priority-queue";

function busiestServers(k: number, arrival: number[], load: number[]): number[] {
    const result = new Array<number>();
    const serverConfig = new Array<[freeAt: number, count: number]>(k);
    const serverWithMinLoad = new MinPriorityQueue<[serverNumber: number, freeAt: number]>({
        compare: (a, b) => a[1] - b[1] || a[0] - b[0]
    });
    const freeServers = new AvlTree<number>((a, b) => a - b);

    // The first k requests each prefer a different, unused server.
    function freeServersAtCurrentArrivalTime(arrivalTime: number): void {
        while (!serverWithMinLoad.isEmpty() &&
               serverWithMinLoad.front()![1] <= arrivalTime) {
            const [serverNumber] = serverWithMinLoad.dequeue()!;
            freeServers.insert(serverNumber);
        }
    }

    for (let i = 0; i < arrival.length; i++) {
        const arrivalTime = arrival[i] - 1;
        const loadTime = load[i];
        const nextFreeAt = arrivalTime + loadTime;

        freeServersAtCurrentArrivalTime(arrivalTime);

        const desiredServerIndex = i % k;
        const desiredServer = serverConfig[desiredServerIndex];

        if (!desiredServer) {
            serverConfig[desiredServerIndex] = [nextFreeAt, 1];
            serverWithMinLoad.enqueue([desiredServerIndex, nextFreeAt]);
        } else {
            const [freeAt, count] = desiredServer;
            if (freeAt <= arrivalTime) {
                serverConfig[desiredServerIndex] = [nextFreeAt, count + 1];
                serverWithMinLoad.enqueue([desiredServerIndex, nextFreeAt]);
                freeServers.remove(desiredServerIndex);
            } else {
                const next = freeServers.upperBound(desiredServerIndex, true) ?? freeServers.min();
                const serverId = next?.getValue();
                if (serverId !== undefined) {
                    const [, count] = serverConfig[serverId];
                    serverConfig[serverId] = [nextFreeAt, count + 1];
                    serverWithMinLoad.enqueue([serverId, nextFreeAt]);
                    freeServers.remove(serverId);
                }
            }
        }
    }

    let maxLoadsOnAServer = 0;
    for (let i = 0; i < k; i++) {
        maxLoadsOnAServer = Math.max(maxLoadsOnAServer, serverConfig[i]?.[1] ?? 0);
    }

    if (maxLoadsOnAServer === 0) return result;

    for (let i = 0; i < k; i++) {
        if (serverConfig[i]?.[1] === maxLoadsOnAServer) result.push(i);
    }

    return result;
}
