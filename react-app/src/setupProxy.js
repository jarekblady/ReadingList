const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/book",
    "/category",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7187',
        secure: false
    });

    app.use(appProxy);
};
