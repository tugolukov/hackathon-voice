module.exports = (api) => {
  api.cache(false);

  return {
    presets: [
      '@babel/react',
      [
        '@babel/preset-env',
        {
          useBuiltIns: 'usage',
          modules: false,
        },
      ],
    ],
    plugins: [
      '@babel/plugin-proposal-class-properties',
      '@babel/plugin-proposal-object-rest-spread',
      '@babel/plugin-syntax-dynamic-import',
    ],
  };
};
