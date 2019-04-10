const baseConfig = require("./webpack.base.conf");
const merge = require("webpack-merge");
const webpack = require("webpack");

const HtmlWebpackPlugin = require("html-webpack-plugin");
const FriendlyErrorsPlugin = require("friendly-errors-webpack-plugin");

module.exports = merge(baseConfig, {
    mode: "development",
    devtool: "eval-source-map",
    module: {
        rules: [{
            test: /\.css$/,
            use: [
                {
                    loader: "vue-style-loader"
                },
                {
                    loader: "css-loader",
                    options: { sourceMap: false }
                }
            ]
            // loader: MiniCssExtractPlugin.loader                
        }]
    },
    plugins: [
        new webpack.HotModuleReplacementPlugin(),
        new FriendlyErrorsPlugin(),

        //  HTML Plugin.
        new HtmlWebpackPlugin({
            title: "Vue-2-Webpack-4",
            filename: "index-dev.html",
            template: "Client/index.html",
            inject: true
        })
    ]
});