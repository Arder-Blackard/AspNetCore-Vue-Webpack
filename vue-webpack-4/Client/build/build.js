const config = require("../config");

const ora = require("ora");
const rm = require("rimraf");
const path = require("path");
const webpack = require("webpack");

const webpackConfig = require("./webpack.prod.conf");

const spinner = ora("Production build...");
spinner.start();

rm(path.join(config.wwwroot), err => {
    spinner.stop();
    if (err) throw err;

    webpack(webpackConfig, (err, stats) => {
        if (err) throw err;
        process.stdout.write(
            stats.toString({
                colors: true,
                modules: false,
                children: false,
                chunks: false,
                chunkModules: false
            }) + "\n\n");

        console.log("Build complete");
    });
});