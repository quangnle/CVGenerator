"use strict";

module.exports = {
    entry: {
        app: './app/app.module.ts',
        theme: './Content/Main/js/theme.js'
    },
    output: {
        filename: './dist/[name].bundle.js'
    },
    resolve: {
        extensions: ['.Webpack.js', '.web.js', '.ts', '.js', '.tsx']
    },
    module: {
        loaders: [
            {
                test: /\.tsx?$/,
                exclude: /(node_modules|bower_components)/,
                loader: 'ts-loader'
            }
        ]
    },
    target: "node"
};