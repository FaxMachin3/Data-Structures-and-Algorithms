// LeetCode 2721: Execute Asynchronous Functions in Parallel

type Fn<T> = () => Promise<T>;

function promiseAll<T>(functions: Fn<T>[]): Promise<T[]> {
    return new Promise((res, rej) => {
        let index = 0;
        const n = functions.length;
        const result = new Array(functions.length);

        for (let i = 0; i < n; i++) {
            const fn = functions[i];
            fn().then(d => {
                result[i] = d;
                index++;
                if (index === n) res(result);
            }, rej);
        }
    });
}
