// BFE.dev 2: Implement curry() with placeholder support

function curry(fn) {
  return function curried(...args) {
    let flag = false;
    for (let i = 0; i < fn.length; i++) {
      if (args[i] === curry.placeholder) {
        flag = true;
      }
    }

    if (!flag && args.length >= fn.length) return fn.apply(this, args);

    return function (...nextArgs) {
      let j = 0;
      const allArgs = [...args];

      for (let i = 0; i < allArgs.length && j < nextArgs.length; i++) {
        if (allArgs[i] === curry.placeholder) {
          allArgs[i] = nextArgs[j++];
        }
      }

      while (j < nextArgs.length) {
        allArgs.push(nextArgs[j++]);
      }

      return curried.apply(this, allArgs);
    };
  };
}

curry.placeholder = Symbol("curry.placeholder");
