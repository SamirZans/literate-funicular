/**
 * Solves binomials of the form (a + b)^n.
 *
 * @param {number} a - The first term of the binomial.
 * @param {number} b - The second term of the binomial.
 * @param {number} n - The exponent of the binomial.
 * @returns {string} The expanded form of the binomial.
 */
function solveBinomials(a, b, n) {
    let result = "";

    // Check if the exponent is a non-negative integer
    if (Number.isInteger(n) && n >= 0) {
        // Iterate from 0 to n to calculate each term of the expanded form
        for (let i = 0; i <= n; i++) {
            let coefficient = binomialCoefficient(n, i);
            let term = "";

            // Calculate the term based on the binomial coefficients and exponents
            if (coefficient !== 1) {
                term += coefficient;
            }

            if (i > 0) {
                term += `*${a}^${n - i}`;
            }

            if (i < n) {
                term += `*${b}^${i}`;
            }

            // Add the term to the result
            result += term;

            // Add a plus sign if there are more terms to come
            if (i < n) {
                result += " + ";
            }
        }
    } else {
        throw new Error("The exponent should be a non-negative integer.");
    }

    return result;
}

/**
 * Calculates the binomial coefficient (n choose k).
 *
 * @param {number} n - The total number of items.
 * @param {number} k - The number of items to choose.
 * @returns {number} The binomial coefficient.
 */
function binomialCoefficient(n, k) {
    if (k === 0 || k === n) {
        return 1;
    } else {
        return binomialCoefficient(n - 1, k - 1) + binomialCoefficient(n - 1, k);
    }
}

// Usage Example

const binomial = solveBinomials(2, 3, 4);
console.log(binomial);  // Output: 16*2^0*3^4 + 12*2^1*3^3 + 6*2^2*3^2 + 2*2^3*3^1 + 1*2^4*3^0
