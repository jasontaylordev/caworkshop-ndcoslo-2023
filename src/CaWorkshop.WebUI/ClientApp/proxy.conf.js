const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:8771';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/WeatherForecast",
      "/_configuration",
      "/.well-known",
      "/Identity",
      "/connect",
      "/ApplyDatabaseMigrations",
      "/_framework",
      "/api",
      "/swagger",
      "/redoc"
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
