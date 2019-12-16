const path = require("path");

const baseConfig = require("./webpack.base.conf");
const merge = require("webpack-merge");
const webpack = require("webpack");

const HtmlWebpackPlugin = require("html-webpack-plugin");
const FriendlyErrorsPlugin = require("friendly-errors-webpack-plugin");

module.exports = merge(baseConfig, {
    mode: "development",
    output: {
        publicPath: "/dist/"
    },
    entry: {
        app: ["./src/index.js"]
    },
    devtool: "eval-source-map",

    devServer: {
        port: 55555,
        contentBase: path.resolve(__dirname, "../../wwwroot")
    },

    optimization: {
        noEmitOnErrors: true
    },

    module: {
        rules: [{
            test: /\.css$/,
            use: [
                {
                    loader: "vue-style-loader",
                    options: { sourceMap: false }
                },
                {
                    loader: "css-loader",
                    options: { sourceMap: false }
                }
            ]
        },
        {
            test: /\.s[ac]ss/,
            use: [
                {
                    loader: "vue-style-loader",
                    options: { sourceMap: false }
                },
                {
                    loader: "css-loader",
                    options: { sourceMap: false }
                },
                {
                    loader: "sass-loader",
                    options: { sourceMap: false }
                }
            ]
        }]
    },

    plugins: [
        new webpack.NoEmitOnErrorsPlugin(),
        new FriendlyErrorsPlugin(),
        //  HTML Plugin.
        new HtmlWebpackPlugin({
            title: "Vue-2-Webpack-4",
            filename: "index-dev.html",
            template: "src/index-template.html",
            inject: true
        })
    ]
});
