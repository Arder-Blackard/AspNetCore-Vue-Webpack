const path = require("path");
const config = require("../config");

const VueLoaderPlugin = require("vue-loader/lib/plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: {
        app: "./Client/src/index.js"
    },
    output: {
        path: config.wwwroot,
        filename: "[name].js",
        publicPath: "/"
    },
    resolve: {
        extensions: [ ".js", ".vue" ],
        alias: {
            "@": path.join(__dirname, "../src")
        }
    },
    module: {
        rules: [
            { test: /\.vue$/, loader: "vue-loader" },
            { test: /\.js$/, loader: "babel-loader" }
        ]
    },
    plugins: [
        new VueLoaderPlugin(),
        new MiniCssExtractPlugin({
            filename: "[name].css",
            chunkFilename: "[id].css"
        })
    ]
};