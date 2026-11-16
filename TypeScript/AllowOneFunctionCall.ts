// LeetCode 2666: Allow One Function Call

type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type OnceFn = (...args: JSONValue[]) => JSONValue | undefined;

function once(fn: Function): OnceFn {
    let called = false;

    return function (this: unknown, ...args: JSONValue[]) {
        if (called) return;

        called = true;
        return fn.apply(this, args);
    };
}

/**
 * let fn = (a, b, c) => (a + b + c)
 * let onceFn = once(fn)
 *
 * onceFn(1, 2, 3); // 6
 * onceFn(2, 3, 6); // returns undefined without calling fn
 */
