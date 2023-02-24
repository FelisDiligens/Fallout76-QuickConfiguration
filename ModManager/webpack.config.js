const path = require("path");
const webpack = require("webpack");
const HtmlWebpackPlugin = require("html-webpack-plugin");

module.exports = function (_env, argv) {
    const isProduction = argv.mode === "production";
    const isDevelopment = !isProduction;
    const port = process.env.PORT || 3000;

    return {
        mode: "development",
        module: {
            rules: [
                {
                    test: /\.js$/,
                    exclude: /node_modules/,
                    use: ["babel-loader"],
                },
                {
                    test: /\.css$/,
                    use: [
                        {
                            loader: "style-loader",
                        },
                        {
                            loader: "css-loader",
                            options: {
                                modules: true,
                                localsConvention: "camelCase",
                                sourceMap: true,
                            },
                        },
                    ],
                },
            ],
        },
        resolve: {
            extensions: ["", ".js", ".jsx"],
        },
        entry: [path.resolve(__dirname, "./src/index.js")],
        output: {
            path: path.resolve(__dirname, "dist"),
            filename: "bundle.js",
            publicPath: "/",
        },
        devtool: isDevelopment && "inline-source-map",
        plugins: [
            new HtmlWebpackPlugin({
                template: "public/index.html",
            }),
        ],
        devServer: {
            host: "localhost",
            port: port,
            historyApiFallback: true,
            open: true,
        },
    };
};
