//
// This is only a SKELETON file for the 'Wordy' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

import { parse } from "path";

export const answer = (problem) => {
  
  // Define the operations
  const operations = {
    'plus': (a, b) => a + b,
    'minus': (a, b) => a - b,
  };

  // Strip what if and ?
  problem = problem.slice(8,-1).trim();
  const tokens = problem.split(' ');

  if (tokens.length == 1) {
    return parseInt(tokens[0]);
  }

  if (tokens.length == 3) {
    return operations[tokens[1]](parseInt(tokens[0]), parseInt(tokens[2]));
  }

  return 99;
};