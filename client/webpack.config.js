const { resolve } = require("@angular/compiler-cli");

module.exports = {
  resolve: {
    fallback: {
      "util": require.resolve("util/"),
    }
  }
}
