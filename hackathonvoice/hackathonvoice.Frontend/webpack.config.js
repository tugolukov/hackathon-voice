const path = require('path');
const webpack = require('webpack');
const merge = require('webpack-merge');
const TerserPlugin = require('terser-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const safePostCssParser = require('postcss-safe-parser');
const postcssFlexbugsFixes = require('postcss-flexbugs-fixes');
const postcssPresetEnv = require('postcss-preset-env');
const postcssInlineSvg = require('postcss-inline-svg');
const FaviconsWebpackPlugin = require('favicons-webpack-plugin');
const { BundleAnalyzerPlugin } = require('webpack-bundle-analyzer');

module.exports = (env) => {
  const { NODE_ENV = 'development', profile } = env;
  const { RELEASE_STAGE = 'local' } = process.env;
  const isProduction = NODE_ENV === 'production';

  console.info(`Application stage: ${RELEASE_STAGE}`);
  console.info(`Build mode: ${NODE_ENV}`);

  const common = {
    target: 'web',
    entry: {
      main: path.resolve(__dirname, 'src', 'index.jsx'),
    },
    output: {
      path: path.join(__dirname, '..', 'hackathonvoice.API', 'wwwroot'),
      filename: '[name].[chunkhash].js',
      publicPath: '/',
    },
    module: {
      rules: [
        {
          test: /\.jsx?$/,
          exclude: /node_modules\/(?!(astralnalog))/,
          use: ['babel-loader'],
        },
        {
          test: /\.s?[ac]ss$/,
          use: [
            MiniCssExtractPlugin.loader,
            'css-loader',
            {
              loader: 'postcss-loader',
              options: {
                sourceMap: true,
                plugins: () => [
                  postcssInlineSvg,
                  postcssFlexbugsFixes,
                  postcssPresetEnv({
                    autoprefixer: {
                      flexbox: 'no-2009',
                    },
                    stage: 3,
                  }),
                ],
              },
            },
            'resolve-url-loader',
            { loader: 'sass-loader', options: { sourceMap: true } },
          ],
        },
        {
          test: /\.(png|jpe?g|gif)$/i,
          use: [
            {
              loader: 'url-loader',
              options: {
                limit: 10 * 1024,
              },
            },
          ],
        },
        {
          test: /\.svg$/,
          use: ['svg-inline-loader'],
        },
        {
          test: /\.(jpe?g|png|gif)$/,
          loader: 'image-webpack-loader',
          enforce: 'pre',
        },
        {
          test: /\.(woff|woff2|eot|ttf|otf)$/,
          use: ['file-loader'],
        },
        {
          test: /\.(pdf)$/,
          use: ['file-loader?minetype=application/pdf'],
        },
      ],
    },

    plugins: [
      new webpack.DefinePlugin({
        'process.env': {
          NODE_ENV: JSON.stringify(NODE_ENV),
          RELEASE_STAGE: JSON.stringify(RELEASE_STAGE),
        },
      }),
      new HtmlWebpackPlugin({
        cache: true,
        minify: isProduction && {
          removeComments: true,
          collapseWhitespace: true,
          removeRedundantAttributes: true,
          useShortDoctype: true,
          removeEmptyAttributes: true,
          removeStyleLinkTypeAttributes: true,
          keepClosingSlash: true,
          minifyJS: true,
          minifyCSS: true,
          minifyURLs: true,
        },
        template: path.join('src', 'index.html'),
        title: 'hackathonvoice',
      }),
      new MiniCssExtractPlugin({
        filename: isProduction ? '[name].[contenthash].css' : '[name].css',
        chunkFilename: isProduction ? '[name].[contenthash].chunk.css' : '[name].chunk.css',
      }),
    ],

    resolve: {
      extensions: ['.js', '.jsx', '.css', '.scss'],
    },

    devServer: {
      stats: 'minimal',
      historyApiFallback: true,
      contentBase: path.resolve(__dirname, 'dist'),
      host: '0.0.0.0',
      proxy: {
        '/api': {
          target: 'http://localhost:5000',
          pathRewrite: { '^/api': '' },
        },
      },
    },
  };

  let config = {};

  if (isProduction) {
    config = merge(common, {
      mode: 'production',
      devtool: 'hidden-source-map',
      output: {
        filename: '[name].[chunkhash].js',
      },
      plugins: [
        new webpack.HashedModuleIdsPlugin(),
        new FaviconsWebpackPlugin('./src/images/favicon.ico'),
      ],
      optimization: {
        minimize: true,
        occurrenceOrder: true,
        runtimeChunk: true,
        splitChunks: {
          chunks: 'all',
        },
        minimizer: [
          new TerserPlugin({
            cache: true,
            parallel: true,
            sourceMap: true,
            terserOptions: {
              parse: {
                ecma: 8,
              },
              compress: {
                ecma: 5,
                warnings: false,
                comparisons: false,
                inline: 2,
              },
              mangle: {
                safari10: true,
              },
              output: {
                ecma: 5,
                comments: false,
                ascii_only: true,
              },
            },
          }),
          new OptimizeCSSAssetsPlugin({
            cssProcessorOptions: {
              parser: safePostCssParser,
              discardUnused: { fontFace: false },
              discardComments: { removeAll: true },
            },
          }),
        ],
      },
    });
  }

  if (!isProduction) {
    config = merge(common, {
      mode: 'development',
      devtool: 'cheap-module-source-map',
      output: {
        filename: '[name].js',
      },
      plugins: [new webpack.NamedModulesPlugin()],
    });
  }

  if (profile) {
    config = merge(config, {
      plugins: [new BundleAnalyzerPlugin()],
    });
  }

  return config;
};
