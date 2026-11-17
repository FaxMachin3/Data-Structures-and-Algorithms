// Frontend Challenges #630: Dedupe In-flight Requests

export function dedupe<Args extends unknown[], R>(
    fn: (...args: Args) => Promise<R>,
    getKey: (...args: Args) => string = (...args) => JSON.stringify(args),
): (...args: Args) => Promise<R> {
    const pending = new Map<string, Promise<R>>();

    return function (...args: Args): Promise<R> {
        const key = getKey(...args);
        const existing = pending.get(key);

        if (existing) return existing;

        try {
            const request = fn(...args).finally(() => pending.delete(key));
            pending.set(key, request);
            return request;
        } catch (e) {
            return Promise.reject(e);
        }
    };
}
