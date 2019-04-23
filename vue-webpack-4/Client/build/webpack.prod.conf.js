const baseConfig = require("./webpack.base.conf");
const merge = require("webpack-merge");
const path = require("path");

const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyWebpackPlugin = require("copy-webpack-plugin");

module.exports = merge(baseConfig, {
    mode: "production",
    entry: {
        app: "./src/index.js"
    },
    output: {
        filename: "js/[name].[chunkhash].js",
        chunkFilename: "js/[id].[chunkhash].js"
    },
    module: {
        rules: [{
            test: /\.css$/,
            use: [
                {
                    loader: MiniCssExtractPlugin.loader
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
                    loader: MiniCssExtractPlugin.loader
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
        //  HTML Plugin.
        new HtmlWebpackPlugin({
            title: "Vue-2-Webpack-4",
            filename: "index.html",
            template: "src/index-template.html",
            inject: true
        }),
        new MiniCssExtractPlugin({
            filename: "css/[name].[chunkhash].css",
            chunkFilename: "css/[id].[chunkhash].css"
        }),
        new CopyWebpackPlugin([
            {
                from: path.resolve(__dirname, "../static"),
                to: "static",
                ignore: [".*"]
            }
        ])
    ]
});
