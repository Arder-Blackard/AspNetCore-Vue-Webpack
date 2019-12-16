const path = require("path");

const VueLoaderPlugin = require("vue-loader/lib/plugin");

const wwwroot = path.resolve(__dirname, "../../wwwroot");

module.exports = {

    output: {
        path: wwwroot,
        filename: "[name].js",
        publicPath: "/"
    },
    resolve: {
        extensions: [".js", ".vue"],
        alias: {
            "@": path.join(__dirname, "../src")
        }
    },
    module: {
        rules: [
            {
                test: /\.(js|vue)$/,
                loader: "eslint-loader",
                enforce: "pre",
                include: [path.join(__dirname, "../src"), path.join(__dirname, "../test")],
                options: {
                    formatter: require("eslint-formatter-friendly")
                }
            },
            { test: /\.vue$/, loader: "vue-loader" },
            { test: /\.js$/, loader: "babel-loader" },
            {
                test: /\.(png|jpe?g|gif|svg)(\?.*)?$/,
                loader: "url-loader",
                options: {
                    limit: 10000,
                    name: "static/img/[name].[hash:7].[ext]"
                }
            },
            {
                test: /\.(mp4|webm|ogg|mp3|wav|flac|aac)(\?.*)?$/,
                loader: "url-loader",
                options: {
                    limit: 10000,
                    name: "static/media/[name].[hash:7].[ext]"
                }
            },
            {
                test: /\.(woff2?|eot|ttf|otf)(\?.*)?$/,
                loader: "url-loader",
                options: {
                    limit: 10000,
                    name: "static/fonts/[name].[hash:7].[ext]"
                }
            }
        ]
    },
    plugins: [
        new VueLoaderPlugin()
    ]
};
