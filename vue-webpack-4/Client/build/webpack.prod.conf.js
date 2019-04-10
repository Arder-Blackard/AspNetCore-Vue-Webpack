const baseConfig = require("./webpack.base.conf");
const merge = require("webpack-merge");

const HtmlWebpackPlugin = require("html-webpack-plugin");

module.exports = merge(baseConfig, {
    mode: "production",
    plugins: [
        //  HTML Plugin.
        new HtmlWebpackPlugin({
            title: "Vue-2-Webpack-4",
            filename: "index.html",
            template: "Client/index.html",
            inject: true
        })
    ]
});