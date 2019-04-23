const ora = require("ora");
const rm = require("rimraf");
const path = require("path");
const webpack = require("webpack");

const webpackConfig = require("./webpack.prod.conf");

const spinner = ora("Production build...");
spinner.start();

rm(path.resolve(__dirname, "../../wwwroot"), err => {
    if (err) {
        throw err;
    }
    webpack(webpackConfig, (err, stats) => {
        spinner.stop();
        if (err) {
            throw err;
        }
        console.log("Build complete");
    });
});
